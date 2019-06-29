using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        private bool _isFlag;
        private bool _enabled;
        private static Sapper.Forms.MainForm _senderForm;

        internal bool IsPressed;
        internal bool IsBomb;
        internal int CountSurroundingCellsWithBomb;
        internal System.Collections.Generic.List<CellOfGameField> SurroundingCells =
            new System.Collections.Generic.List<CellOfGameField>();
        internal static System.Collections.Generic.List<CellOfGameField> NoBombsCells =
            new System.Collections.Generic.List<CellOfGameField>();


        
        private bool IsFlag
        {
            get
            {
                return _isFlag;
            }
            set
            {
                if (false == this.IsPressed)
                    this._isFlag = value;
            }
        }

        internal CellOfGameField() : this(false) { }
        internal CellOfGameField(bool isBomb) : base()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.IsBomb = isBomb;
            this.IsPressed = false;

            if (false == this.IsBomb)
                this.CountSurroundingCellsWithBomb = 0;
            else
                this.CountSurroundingCellsWithBomb = -1;

            this.FlatAppearance.BorderSize = 0; // delete border
            this.Image = Properties.Textures.Win7.win7_close;
            this.Size = new Size(Sapper.Forms.MainForm.FIELD_SIZE_GAME, Sapper.Forms.MainForm.FIELD_SIZE_GAME);

            this.Click += new EventHandler(OnClick);
            this.MouseDown += new MouseEventHandler(OnMouseDown);
        }

        internal void ClearField()
        {
            this.IsPressed = false;
            this._isFlag = false;
            this.IsBomb = false;

            this.CountSurroundingCellsWithBomb = 0;

            this.Image = Properties.Textures.Win7.win7_close;
        }

        internal static void SetSenderForm(Sapper.Forms.MainForm sender)
        {
            _senderForm = sender;
        }

        private void OnClick(object sender, EventArgs e)
        {
            _senderForm?.TimerStart();

            if (false == this.IsPressed && false == this.IsFlag)
            {
                this.IsPressed = true;
                this._enabled = false;

                try { NoBombsCells.RemoveAt(NoBombsCells.IndexOf(this)); }
                catch { }

                if (true == this.IsBomb)
                {
                    this.Image = Properties.Textures.Win7.win7_bombLose;
                    _senderForm?.GameLose();
                }
                else if (0 == this.CountSurroundingCellsWithBomb)
                {
                    this.Image = Properties.Textures.Win7.win7_0;

                    for (int i = 0; i < this.SurroundingCells.Count; i++)
                    {
                        if (null == SurroundingCells.ToArray()[i])
                            break;
                        SurroundingCells.ToArray()[i].PerformClick();
                    }
                }
                else
                {
                    try
                    {
                        switch (this.CountSurroundingCellsWithBomb)
                        {
                            case 1:
                                this.Image = Properties.Textures.Win7.win7_1;
                                break;
                            case 2:
                                this.Image = Properties.Textures.Win7.win7_2;
                                break;
                            case 3:
                                this.Image = Properties.Textures.Win7.win7_3;
                                break;
                            case 4:
                                this.Image = Properties.Textures.Win7.win7_4;
                                break;
                            case 5:
                                this.Image = Properties.Textures.Win7.win7_5;
                                break;
                            case 6:
                                this.Image = Properties.Textures.Win7.win7_6;
                                break;
                            case 7:
                                this.Image = Properties.Textures.Win7.win7_7;
                                break;
                            case 8:
                                this.Image = Properties.Textures.Win7.win7_8;
                                break;

                            default:
                                throw new ArgumentException("ERROR_TEXTURES_LOAD");
                        }
                    }
                    catch (ArgumentException exeption)
                    {
                        MessageBox.Show(exeption.Message);
                    }

                }
            }
            if ((null != _senderForm) && (0 == NoBombsCells.Count))
                _senderForm.GameWin();
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                if (false == this.IsPressed)
                {
                    this.IsFlag = !(this.IsFlag);
                    if (true == this.IsFlag && false == this.IsPressed)
                    {
                        this.Image = Properties.Textures.Win7.win7_flag;
                        _senderForm?.SetCounterBombsDecrease(1);
                    }
                    else if (false == this.IsPressed)
                    {
                        this.Image = Properties.Textures.Win7.win7_close;
                        _senderForm?.SetCounterBombsIncrease(1);
                    }
                }
                else
                {
                    int countSurroundingFlag = 0;

                    foreach (var field in this.SurroundingCells)
                        if (field._isFlag)
                            countSurroundingFlag++;

                    if (countSurroundingFlag == this.CountSurroundingCellsWithBomb)
                        for (int i = 0; i < SurroundingCells.Count; i++)
                        {
                            if (null == SurroundingCells.ToArray()[i])
                                break;
                            SurroundingCells.ToArray()[i].PerformClick();
                        }
                }
            }
        }
    }
}
