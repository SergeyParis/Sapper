using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Sapper
{
    internal sealed class CellOfGameField : System.Windows.Forms.Button
    {
        public System.Collections.Generic.List<CellOfGameField> SurroundingCells = new List<CellOfGameField>();
        // private static bool gameStart = false;
        private bool _isPressed;
        public bool IsThisBomb { get; set; }
        public int SurroundingCellsWithBomb { get; set; }

        public CellOfGameField() : this(false) { }
        public CellOfGameField(bool isThisBomb) : base()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.IsThisBomb = isThisBomb;
            this._isPressed = false;

            if (false == this.IsThisBomb)
                this.SurroundingCellsWithBomb = 0;
            else
                this.SurroundingCellsWithBomb = -1;

            this.FlatAppearance.BorderSize = 0; // delete border
            this.Size = new Size(Sapper.Forms.MainForm.SIZE_GAME_FIELD, Sapper.Forms.MainForm.SIZE_GAME_FIELD);
            this.Click += new EventHandler(OnClick);
        }

        public static void SetCountSurroundingCellsAll(Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < senderForm.GameFieldWidth; i++)
                    for (int j = 0; j < senderForm.GameFieldHeight; j++)
                    {
                        try
                        {
                            for (int k = -1; k < 2; k++)
                                for (int l = -1; l < 2; l++)
                                {
                                    if ((0 == k) && (0 == l)) { continue; }

                                    senderForm.GameFieldButtons[i, j].
                                        SurroundingCells.Add(senderForm.GameFieldButtons[i - k, j - l]);

                                    if (senderForm.GameFieldButtons[i - k, j - l].IsThisBomb)
                                        senderForm.GameFieldButtons[i, j].SurroundingCellsWithBomb++;
                                }
                        }
                        catch { continue; }
                    }
        }
        public static void ChangeSizeGameField(Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                if (senderForm.GameFieldWidth > 0 && senderForm.GameFieldHeight > 0)
                    senderForm.Size =
                        new System.Drawing.Size(
                            (senderForm.GameFieldButtons[senderForm.GameFieldWidth - 1, senderForm.GameFieldHeight - 1].Location.X) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                            (senderForm.GameFieldButtons[senderForm.GameFieldWidth - 1, senderForm.GameFieldHeight - 1].Location.Y) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
        public static void CreategameFieldButtons(Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < senderForm.GameFieldWidth; i++)
                    for (int j = 0; j < senderForm.GameFieldHeight; j++)
                    {
                        senderForm.GameFieldButtons[i, j] = new CellOfGameField();
                        senderForm.GameFieldButtons[i, j].Location =
                            new System.Drawing.Point(
                                Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i * (Sapper.Forms.MainForm.SIZE_GAME_FIELD - 2)),
                                Sapper.Forms.MainForm.FORM_PADDING_UP + (j * (Sapper.Forms.MainForm.SIZE_GAME_FIELD - 2)));

                        senderForm.Controls.Add(senderForm.GameFieldButtons[i, j]);
                    }
        }
        public static void PlacingBombsOnBoard(Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
            {
                Random random = new Random();

                for (int i = 0; i < senderForm.CountOfBombs; i++)
                {
                    senderForm.GameFieldButtons[
                    random.Next(senderForm.GameFieldWidth),
                    random.Next(senderForm.GameFieldHeight)]
                    .IsThisBomb = true;
                }
            }
        }

        void OnClick(object sender, EventArgs e)
        {
            // gameStart = true;

            if (false == this._isPressed)
            {
                this._isPressed = true;

                if (true == this.IsThisBomb)
                    this.Text = "B";
                else if (0 == this.SurroundingCellsWithBomb)
                {
                    this.Text = "0";

                    for (int i = 0; i < SurroundingCells.Count; i++)
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
                        switch (this.SurroundingCellsWithBomb)
                        {
                            case 1: this.Image = Properties.Textures.Win7.win7_1; break;
                            case 2: this.Image = Properties.Textures.Win7.win7_2; break;
                            case 3: this.Image = Properties.Textures.Win7.win7_3; break;
                            case 4: this.Image = Properties.Textures.Win7.win7_4; break;
                            case 5: this.Image = Properties.Textures.Win7.win7_5; break;
                            case 6: this.Image = Properties.Textures.Win7.win7_6; break;
                            case 7: this.Image = Properties.Textures.Win7.win7_7; break;
                            case 8: this.Image = Properties.Textures.Win7.win7_8; break;

                            default: throw new ArgumentException("ERROR_TEXTURES_LOAD");
                        }
                    }
                    catch (ArgumentException exeption)
                    {
                        MessageBox.Show(exeption.Message);
                    }
                    
                }
            }
        }

        public static void OpenAllGameField(Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                foreach (var field in senderForm.GameFieldButtons)
                    if (false == field._isPressed)
                        field.PerformClick();
        }
    }
}
