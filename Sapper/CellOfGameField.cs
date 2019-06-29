using System;
using System.Collections.Generic;
using System.Drawing;
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

        public CellOfGameField () : this(false) { }
        public CellOfGameField (bool isThisBomb) : base()
        {
            this.FlatStyle = FlatStyle.Flat;
            
            this.IsThisBomb = isThisBomb;
            this._isPressed = false;

            if (false == this.IsThisBomb)
                this.SurroundingCellsWithBomb = 0;
            else
                this.SurroundingCellsWithBomb = -1;

            this.Size = new Size(Sapper.Forms.MainForm.SIZE_GAME_FIELD, Sapper.Forms.MainForm.SIZE_GAME_FIELD);
            this.Click += new EventHandler(OnClick);
        }


        public static void SetCountSurroundingCellsAll (int gameFieldWidth, int gameFieldHeight, Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < gameFieldWidth; i++)
                    for (int j = 0; j < gameFieldHeight; j++)
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
        public static void ChangeSizeGameField (int gameFieldWidth, int gameFieldHeight, Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                if (gameFieldWidth > 0 && gameFieldHeight > 0)
                    senderForm.Size =
                        new System.Drawing.Size(
                            (senderForm.GameFieldButtons[gameFieldWidth - 1, gameFieldHeight - 1].Location.X) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                            (senderForm.GameFieldButtons[gameFieldWidth - 1, gameFieldHeight - 1].Location.Y) +
                            Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
        public static void PlacingBombsOnBoard (int gameFieldWidth, int gameFieldHeight, Form sender)
        {
            Sapper.Forms.MainForm senderForm = sender as Sapper.Forms.MainForm;

            if (null != senderForm)
                for (int i = 0; i < gameFieldWidth; i++)
                    for (int j = 0; j < gameFieldHeight; j++)
                    {
                        senderForm.GameFieldButtons[i, j] = new CellOfGameField();
                        senderForm.GameFieldButtons[i, j].Location =
                            new System.Drawing.Point(
                                Sapper.Forms.MainForm.FORM_PADDING_SIDE + (i * (Sapper.Forms.MainForm.SIZE_GAME_FIELD - 2)),
                                Sapper.Forms.MainForm.FORM_PADDING_UP + (j * (Sapper.Forms.MainForm.SIZE_GAME_FIELD - 2)));

                        senderForm.Controls.Add(senderForm.GameFieldButtons[i, j]);
                    }
        }

        void OnClick (object sender, EventArgs e)
        {
            // gameStart = true;

            if (true == this.Enabled)
            {
                this.Enabled = false;

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
                else this.Text = Convert.ToString(SurroundingCellsWithBomb);
            }
        }
    }
}
