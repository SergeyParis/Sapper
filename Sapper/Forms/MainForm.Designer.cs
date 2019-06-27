﻿namespace Sapper.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ()
        {
            this.MenuStripMain = new System.Windows.Forms.MenuStrip();
            this.GameMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripMain
            // 
            this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenuStrip});
            this.MenuStripMain.Location = new System.Drawing.Point(0, 0);
            this.MenuStripMain.Name = "MenuStripMain";
            this.MenuStripMain.Size = new System.Drawing.Size(431, 24);
            this.MenuStripMain.TabIndex = 0;
            this.MenuStripMain.Text = "Game";
            // 
            // GameMenuStrip
            // 
            this.GameMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.GameMenuStrip.Name = "GameMenuStrip";
            this.GameMenuStrip.Size = new System.Drawing.Size(50, 20);
            this.GameMenuStrip.Text = "Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 373);
            this.Controls.Add(this.MenuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.MenuStripMain.ResumeLayout(false);
            this.MenuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private const int SIZE_GAME_FIELD = 25;
        private const int FORM_PADDING_UP = 80;
        private const int FORM_PADDING_DOWN = 50;
        private const int FORM_PADDING_SIDE = 25;

        private const int FORM_PADDING_LAST_FIELD_BUTTON_WIDTH = 67;    // kostuli
        private const int FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT = 87;   // kostuli

        private CellOfGameField[,] _gameFieldButtons;

        private void GameFieldCreate (int gameFieldWidth, int gameFieldHeight, int countOfBomb)
        {
            _gameFieldButtons = new CellOfGameField[gameFieldWidth, gameFieldHeight];
            for (int i = 0; i < gameFieldWidth; i++)
                for (int j = 0; j < gameFieldHeight; j++)
                {
                    _gameFieldButtons[i, j] = new CellOfGameField();
                    _gameFieldButtons[i, j].Location =
                        new System.Drawing.Point(FORM_PADDING_SIDE + (i * (SIZE_GAME_FIELD - 2)),
                            FORM_PADDING_UP + (j * (SIZE_GAME_FIELD - 2)));
                    _gameFieldButtons[i, j].Size = new System.Drawing.Size(SIZE_GAME_FIELD, SIZE_GAME_FIELD);

                    this.Controls.Add(_gameFieldButtons[i, j]);
                }

            if (gameFieldWidth > 0 && gameFieldHeight > 0)
                this.Size =
                    new System.Drawing.Size(
                        (_gameFieldButtons[gameFieldWidth - 1, gameFieldHeight - 1].Location.X) +
                        FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                        (_gameFieldButtons[gameFieldWidth - 1, gameFieldHeight - 1].Location.Y) +
                        FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);


            

            for (int k = 0; k < countOfBomb; k++)
            {
                System.Random tempRandom = new System.Random();

                while (true)
                {
                    int tempHeight = tempRandom.Next(gameFieldHeight - 1);
                    int tempWidth = tempRandom.Next(gameFieldWidth - 1);

                    if (false == _gameFieldButtons[tempHeight, tempWidth].IsThisBomb)
                    {
                        _gameFieldButtons[tempHeight, tempWidth].IsThisBomb = true;
                        break;
                    }
                    else continue;
                }
            }


            for (int i = 0; i < gameFieldWidth; i++)
                for (int j = 0; j < gameFieldHeight; j++)               // every cell
                    if (false == _gameFieldButtons[i, j].IsThisBomb)    // if bomb this cell
                        for (int k = -1; k < 2; k++)                    //every surrounding cell
                            for (int l = -1; l < 2; l++)
                            {
                                try
                                {
                                    if ((null != _gameFieldButtons[i - k, j - l])
                                      && (true == _gameFieldButtons[i - k, j - l].IsThisBomb))
                                        _gameFieldButtons[i, j].SurroundingCells++;
                                }
                                catch { }
                            }
        }

        private void GameFieldDelete (int gameFieldWidth, int gameFieldHeight)
        {
            for (int i = 0; i < _gameFieldWidth; i++)
                for (int j = 0; j < _gameFieldHeight; j++)
                    this.Controls.Remove(_gameFieldButtons[i, j]);
        }

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem GameMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

