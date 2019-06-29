using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        private bool _isFlag;
        private GameField _senderGameField;

        internal bool EnabledClick = true;
        internal bool IsPressed;
        internal bool IsBomb;
        internal int CountSurroundingCellsWithBomb;
        internal System.Collections.Generic.List<CellOfGameField> SurroundingCells =
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

            // Remove focus
            this.TabStop = false;
        }

        internal void ClearField()
        {
            this.IsPressed = false;
            this._isFlag = false;
            this.IsBomb = false;

            this.CountSurroundingCellsWithBomb = 0;

            this.Image = Properties.Textures.Win7.win7_close;
        }

        internal void SetSenderGameField(GameField sender)
        {
            _senderGameField = sender;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (false == _senderGameField.GetSenderForm.ThisGameStop)
                _senderGameField.GetSenderForm.TimerStart();

            if (false == this.IsPressed && true == this.EnabledClick && false == this.IsFlag)
            {
                this.IsPressed = true;
                this.EnabledClick = false;
                
                --_senderGameField.CountNoBombsCells;

                if (true == this.IsBomb)
                {
                    if (false == _senderGameField.GetSenderForm.ThisGameStop)
                    {
                        this.Image = Properties.Textures.Win7.win7_bombLose;
                        _senderGameField.GetSenderForm.GameLose();
                    }
                    else
                        this.Image = Properties.Textures.Win7.win7_bomb;
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
            if ((null != _senderGameField.GetSenderForm) && (0 == _senderGameField.CountNoBombsCells))
                _senderGameField.GetSenderForm.GameWin();

            _senderGameField.GetSenderForm.Focus();
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
                        _senderGameField.GetSenderForm.SetCounterBombsDecrease(1);
                    }
                    else if (false == this.IsPressed)
                    {
                        this.Image = Properties.Textures.Win7.win7_close;
                        _senderGameField.GetSenderForm.SetCounterBombsIncrease(1);
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
