using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        private static Sapper.Forms.MainForm _senderForm;

        private System.Collections.Generic.List<CellOfGameField> _surroundingCells =
            new System.Collections.Generic.List<CellOfGameField>();
        private static System.Collections.Generic.List<CellOfGameField> _noBombsCells =
            new System.Collections.Generic.List<CellOfGameField>();

        private bool _isPressed;
        private bool _isFlag;
        private bool _enabled;

        public static System.Collections.Generic.List<CellOfGameField> NoBombsCells => _noBombsCells;
        public int CountSurroundingCellsWithBomb { get; set; }
        public bool IsBomb { get; set; }
        private bool IsFlag
        {
            get
            {
                return _isFlag;
            }
            set
            {
                if (false == this._isPressed)
                    this._isFlag = value;
            }
        }

        public CellOfGameField() : this(false) { }
        public CellOfGameField(bool isBomb) : base()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.IsBomb = isBomb;
            this._isPressed = false;

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

        public static void SetSenderForm(Form senderForm)
        {
            _senderForm = senderForm as Sapper.Forms.MainForm;
        }
        public static void GameFieldBuild()
        {
            GameFieldCreateButtons();
            GameFieldChangeSize();
            GameFieldPlacingBombs();
            SetRefSurroundingCells();
            SetCountSurroundingCellsWithBomb();
            SetNoBombSells();
        }
        public static void GameFieldRebuild()
        {
            GameFieldClear();

            GameFieldPlacingBombs();
            SetCountSurroundingCellsWithBomb();
            SetNoBombSells();
        }
        public static void GameFieldLock()
        {
            foreach (CellOfGameField field in _senderForm.GameFieldButtons)
                field._enabled = false;
        }
        public static void GameFieldUnlock()
        {
            foreach (CellOfGameField field in _senderForm.GameFieldButtons)
                field._enabled = true;
        }
        public static void GameFieldOpen()
        {
            if (null == _senderForm) return;

            foreach (var field in _senderForm?.GameFieldButtons)
                if (false == field._isPressed)
                    field.PerformClick();
        }
        public static void GameFieldClose()
        {
            if (null == _senderForm) return;

            foreach (var field in _senderForm.GameFieldButtons)
                field.ClearField();
        }

        private static void SetRefSurroundingCells()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {
                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                        {
                            if ((0 == k) && (0 == l)) { continue; }

                            try
                            {
                                _senderForm.GameFieldButtons[i, j].
                                    _surroundingCells.Add(_senderForm.GameFieldButtons[i - k, j - l]);
                            }
                            catch { continue; }
                        }
                }
        }
        private static void SetCountSurroundingCellsWithBomb()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {

                    for (int k = -1; k < 2; k++)
                        for (int l = -1; l < 2; l++)
                        {
                            if ((0 == k) && (0 == l)) { continue; }

                            try
                            {
                                if (_senderForm.GameFieldButtons[i - k, j - l].IsBomb)
                                    _senderForm.GameFieldButtons[i, j].CountSurroundingCellsWithBomb++;
                            }
                            catch { continue; }
                        }


                }
        }
        private static void SetNoBombSells()
        {
            if (null == _senderForm) return;

            foreach (var field in _senderForm.GameFieldButtons)
                if (false == field.IsBomb)
                    _noBombsCells.Add(field);
        }
        private static void GameFieldChangeSize()
        {
            if (_senderForm?.GameFieldWidth > 0 && _senderForm.GameFieldHeight > 0)
                _senderForm.Size =
                    new System.Drawing.Size(
                        (_senderForm.GameFieldButtons[_senderForm.GameFieldWidth - 1,
                            _senderForm.GameFieldHeight - 1].Location.X) + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                        (_senderForm.GameFieldButtons[_senderForm.GameFieldWidth - 1,
                            _senderForm.GameFieldHeight - 1].Location.Y) + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
        private static void GameFieldCreateButtons()
        {
            if (null == _senderForm) return;

            for (int i = 0; i < _senderForm.GameFieldWidth; i++)
                for (int j = 0; j < _senderForm.GameFieldHeight; j++)
                {
                    _senderForm.GameFieldButtons[i, j] = new CellOfGameField();
                    _senderForm.GameFieldButtons[i, j].Location =
                        new System.Drawing.Point(
                            Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)),
                            Sapper.Forms.MainForm.FORM_PADDING_UP + (j * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)));

                    _senderForm.Controls.Add(_senderForm.GameFieldButtons[i, j]);
                }
        }
        private static void GameFieldPlacingBombs()
        {
            if (null == _senderForm) return;

            Random random = new Random();

            for (int i = 0; i < _senderForm.CountOfBombs; i++)
            {
                int tempRandomWidth = random.Next(_senderForm.GameFieldWidth);
                int tempRandomHeight = random.Next(_senderForm.GameFieldHeight);

                if (false == _senderForm.GameFieldButtons[tempRandomWidth, tempRandomHeight].IsBomb)
                    _senderForm.GameFieldButtons[tempRandomWidth, tempRandomHeight].IsBomb = true;
                else
                    --i;
            }
        }
        private static void GameFieldClear()
        {
            foreach (var field in _senderForm.GameFieldButtons)
            {
                field.ClearField();
            }
        }
        private void ClearField()
        {
            this._isPressed = false;
            this._isFlag = false;
            this.IsBomb = false;

            this.CountSurroundingCellsWithBomb = 0;

            this.Image = Properties.Textures.Win7.win7_close;
        }

        private void OnClick(object sender, EventArgs e)
        {
            _senderForm?.TimerStart();

            if (false == this._isPressed && false == this.IsFlag)
            {
                this._isPressed = true;
                this._enabled = false;

                try { _noBombsCells.RemoveAt(_noBombsCells.IndexOf(this)); }
                catch { }

                if (true == this.IsBomb)
                {
                    this.Image = Properties.Textures.Win7.win7_bombLose;
                    _senderForm?.GameLose();
                }
                else if (0 == this.CountSurroundingCellsWithBomb)
                {
                    this.Image = Properties.Textures.Win7.win7_0;

                    for (int i = 0; i < this._surroundingCells.Count; i++)
                    {
                        if (null == _surroundingCells.ToArray()[i])
                            break;
                        _surroundingCells.ToArray()[i].PerformClick();
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
            if ((null != _senderForm) && (0 == _noBombsCells.Count))
                _senderForm.GameWin();
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                if (false == this._isPressed)
                {
                    this.IsFlag = !(this.IsFlag);
                    if (true == this.IsFlag && false == this._isPressed)
                    {
                        this.Image = Properties.Textures.Win7.win7_flag;
                        _senderForm?.SetCounterBombsDecrease(1);
                    }
                    else if (false == this._isPressed)
                    {
                        this.Image = Properties.Textures.Win7.win7_close;
                        _senderForm?.SetCounterBombsIncrease(1);
                    }
                }
                else
                {
                    int countSurroundingFlag = 0;

                    foreach (var field in this._surroundingCells)
                        if (field._isFlag)
                            countSurroundingFlag++;

                    if (countSurroundingFlag == this.CountSurroundingCellsWithBomb)
                        for (int i = 0; i < _surroundingCells.Count; i++)
                        {
                            if (null == _surroundingCells.ToArray()[i])
                                break;
                            _surroundingCells.ToArray()[i].PerformClick();
                        }
                }
            }
        }
    }
}
