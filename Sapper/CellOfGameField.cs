using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        private static Form _senderForm;
        public System.Collections.Generic.List<CellOfGameField> SurroundingCells = new List<CellOfGameField>();
        private bool _isPressed;
        private bool _isFlag;
        
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
            _senderForm = senderForm;
        }
        public static void SetCountSurroundingCellsAll()
        {
            Sapper.Forms.MainForm senderForm = _senderForm as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < senderForm.GameFieldWidth; i++)
                    for (int j = 0; j < senderForm.GameFieldHeight; j++)
                    {

                        for (int k = -1; k < 2; k++)
                            for (int l = -1; l < 2; l++)
                            {
                                if ((0 == k) && (0 == l)) { continue; }

                                try
                                {
                                    senderForm.GameFieldButtons[i, j].
                                        SurroundingCells.Add(senderForm.GameFieldButtons[i - k, j - l]);

                                    if (senderForm.GameFieldButtons[i - k, j - l].IsBomb)
                                        senderForm.GameFieldButtons[i, j].CountSurroundingCellsWithBomb++;
                                }
                                catch { continue; }
                            }


                    }
        }
        public static void ChangeSizeGameField()
        {
            Sapper.Forms.MainForm senderForm = _senderForm as Sapper.Forms.MainForm;

            if (null != senderForm)
                if (senderForm.GameFieldWidth > 0 && senderForm.GameFieldHeight > 0)
                    senderForm.Size =
                        new System.Drawing.Size(
                            (senderForm.GameFieldButtons[senderForm.GameFieldWidth - 1, senderForm.GameFieldHeight - 1].Location.X) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                            (senderForm.GameFieldButtons[senderForm.GameFieldWidth - 1, senderForm.GameFieldHeight - 1].Location.Y) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
        public static void CreategameFieldButtons()
        {
            Sapper.Forms.MainForm senderForm = _senderForm as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < senderForm.GameFieldWidth; i++)
                    for (int j = 0; j < senderForm.GameFieldHeight; j++)
                    {
                        senderForm.GameFieldButtons[i, j] = new CellOfGameField();
                        senderForm.GameFieldButtons[i, j].Location =
                            new System.Drawing.Point(
                                Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)),
                                Sapper.Forms.MainForm.FORM_PADDING_UP + (j * (Sapper.Forms.MainForm.FIELD_SIZE_GAME - 2)));

                        senderForm.Controls.Add(senderForm.GameFieldButtons[i, j]);
                    }
        }
        public static void PlacingBombsOnBoard()
        {
            Sapper.Forms.MainForm senderForm = _senderForm as Sapper.Forms.MainForm;

            if (null != senderForm)
            {
                Random random = new Random();

                for (int i = 0; i < senderForm.CountOfBombs; i++)
                {
                    senderForm.GameFieldButtons[
                    random.Next(senderForm.GameFieldWidth),
                    random.Next(senderForm.GameFieldHeight)]
                    .IsBomb = true;
                }
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            ((Sapper.Forms.MainForm)_senderForm).GameContinius = true;
            ((Sapper.Forms.MainForm)_senderForm).TimerStart();

            if (false == this._isPressed && false == this.IsFlag)
            {
                this._isPressed = true;

                if (true == this.IsBomb)
                    this.Image = Properties.Textures.Win7.win7_bomb;
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
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                if (false == this._isPressed)
                {
                    this.IsFlag = !(this.IsFlag);
                    if (true == this.IsFlag && false == this._isPressed)
                        this.Image = Properties.Textures.Win7.win7_flag;
                    else if (false == this._isPressed)
                        this.Image = Properties.Textures.Win7.win7_close;
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

        public static void OpenAllGameField(Form sender)
        {
            ((Sapper.Forms.MainForm) _senderForm).GameContinius = false;
            ((Sapper.Forms.MainForm)_senderForm).TimerStop();

            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                foreach (var field in senderForm.GameFieldButtons)
                    if (false == field._isPressed)
                        field.PerformClick();
        }
    }
}
