using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper.GameField
{
    internal sealed partial class CellOfGameField : Button
    {
        private bool _isFlag;
        private GameField _senderGameField;

        internal bool EnabledClick = true;
        internal bool IsPressed;
        internal bool IsBomb;
        internal int CountSurroundingCellsWithBomb;
        internal System.Collections.Generic.List<CellOfGameField> SurroundingCells =
            new System.Collections.Generic.List<CellOfGameField>();

        internal bool IsHp { get; set; } = false;

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
            this.IsHp = false;

            this.CountSurroundingCellsWithBomb = 0;

            this.Image = Properties.Textures.Win7.win7_close;
        }

        internal void SetSenderGameField(GameField sender)
        {
            _senderGameField = sender;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (false == _senderGameField.GetSenderForm.GetTimerEnabled && false == _senderGameField.GetSenderForm.GetThisGameStop)
                _senderGameField.GetSenderForm.TimerStart();

            if (false == this.IsPressed && true == this.EnabledClick && false == this.IsFlag)
            {
                this.IsPressed = true;
                this.EnabledClick = false;

                if (true == this.IsBomb)
                    ClickBomb();
                else if (true == this.IsHp)
                    ClickHp();
                else if (0 == this.CountSurroundingCellsWithBomb)
                    ClickNullCell();             
                else
                    ClickNotNullCell();
            }
            if ((null != _senderGameField.GetSenderForm) && (0 == _senderGameField.CountNoBombsCells))
                _senderGameField.GetSenderForm.GameWin();

            _senderGameField.GetSenderForm.GetFocus();
        }

        private void ClickBomb()
        {
            int chanceOfExplosionBomb = _senderGameField.GetSenderForm.GetChanceOfExplosionBombs;
            Random random = new Random();

            int currentChance = random.Next(100); // maximal chance - 100%

            if (currentChance < chanceOfExplosionBomb &&
                false == _senderGameField.GetSenderForm.GetThisGameStop)
            {
                this.Image = Properties.Textures.Win7.win7_bombLose;
                _senderGameField.GetSenderForm.GameLose();
            }
            else
            {
                this.Image = Properties.Textures.Win7.win7_bomb;
                this.IsFlag = true;
            }
        }
        private void ClickNullCell()
        {
            --_senderGameField.CountNoBombsCells;

            if (false == this.IsHp)
                this.Image = Properties.Textures.Win7.win7_0;
            else
                this.Image = Properties.Textures.Win7.win7_hp;

            for (int i = 0; i < this.SurroundingCells.Count; i++)
            {
                if (null == SurroundingCells.ToArray()[i])
                    break;
                SurroundingCells.ToArray()[i].PerformClick();
            }
        }
        private void ClickNotNullCell()
        {
            --_senderGameField.CountNoBombsCells;

            try
            {
                if (false == this.IsHp)
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
                else
                {
                    switch (this.CountSurroundingCellsWithBomb)
                    {
                        case 1:
                            this.Image = Properties.Textures.Win7.win7_1_hp;
                            break;
                        case 2:
                            this.Image = Properties.Textures.Win7.win7_2_hp;
                            break;
                        case 3:
                            this.Image = Properties.Textures.Win7.win7_3_hp;
                            break;
                        case 4:
                            this.Image = Properties.Textures.Win7.win7_4_hp;
                            break;
                        case 5:
                            this.Image = Properties.Textures.Win7.win7_5_hp;
                            break;
                        case 6:
                            this.Image = Properties.Textures.Win7.win7_6_hp;
                            break;
                        case 7:
                            this.Image = Properties.Textures.Win7.win7_7_hp;
                            break;
                        case 8:
                            this.Image = Properties.Textures.Win7.win7_8_hp;
                            break;

                        default:
                            throw new ArgumentException("ERROR_TEXTURES_LOAD");
                    }
                }
            }
            catch (ArgumentException exeption)
            {
                MessageBox.Show(exeption.Message);
            }
        }
        private void ClickHp()
        {
            ++_senderGameField.GetSenderForm.HpPlayer;

            if (0 == this.CountSurroundingCellsWithBomb)
                ClickNullCell();
            else
                ClickNotNullCell();
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
