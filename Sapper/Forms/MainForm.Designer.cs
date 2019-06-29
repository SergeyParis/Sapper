namespace Sapper.Forms
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
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
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

        internal const int FIELD_SIZE_GAME = 18;
        internal const int FORM_PADDING_UP = 80;
        internal const int FORM_PADDING_DOWN = 50;
        internal const int FORM_PADDING_SIDE = 25;

        private const int RESET_BUTTON_GAME_SIZE = 21;
        private const int RESET_BUTTON_PADDING_HEIGHT = 40;

        private const int TIMER_LOCATION_PADDING_WIDTH = 25;
        private const int TIMER_LOCATION_PADDING_HEIGHT = 40;

        private const int COUNT_BOMBS_REMAINS_LOCATION_PADDING_WIDTH = 25 + 55; // + size control
        private const int COUNT_BOMBS_REMAINS_LOCATION_PADDING_HEIGHT = 40;

        internal const int FORM_PADDING_LAST_FIELD_BUTTON_WIDTH = 67;    // kostuli
        internal const int FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT = 87;   // kostuli

        private CellOfGameField[,] _gameFieldButtons;
        private System.Windows.Forms.Button _resetButton;
        private Sapper.Controls.UserTimer _timerThisGame;
        private Sapper.Controls.CountBombsRemains _countBombsRemains;
        public void GameFieldCreate()
        {
            _gameFieldButtons = new CellOfGameField[_gameFieldWidth, _gameFieldHeight];

            Sapper.CellOfGameField.SetSenderForm(this);
            Sapper.CellOfGameField.GameFieldBuild();

            /* Reset button */
            _resetButton = new System.Windows.Forms.Button();
            _resetButton.Size = new System.Drawing.Size(RESET_BUTTON_GAME_SIZE, RESET_BUTTON_GAME_SIZE);
            _resetButton.Location = new System.Drawing.Point(this.Size.Width / 2 - RESET_BUTTON_GAME_SIZE,
                                                            RESET_BUTTON_PADDING_HEIGHT);
            _resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            _resetButton.Image = Properties.Textures.Win7.win7_resetGame;
            _resetButton.Click += new System.EventHandler(OnClickResetButton);
            this.Controls.Add(_resetButton);

            /* Timer */
            _timerThisGame = new Sapper.Controls.UserTimer();
            _timerThisGame.Location = new System.Drawing.Point(TIMER_LOCATION_PADDING_WIDTH, TIMER_LOCATION_PADDING_HEIGHT);
            this.Controls.Add(_timerThisGame);

            /* Counter bombs */
            _countBombsRemains = new Sapper.Controls.CountBombsRemains();
            _countBombsRemains.Location = new System.Drawing.Point(this.Size.Width - COUNT_BOMBS_REMAINS_LOCATION_PADDING_WIDTH, COUNT_BOMBS_REMAINS_LOCATION_PADDING_HEIGHT);
            this.Controls.Add(_countBombsRemains);
        }
        private void GameFieldDelete()
        {
            for (int i = 0; i < _gameFieldWidth; i++)
                for (int j = 0; j < GameFieldHeight; j++)
                    this.Controls.Remove(GameFieldButtons[i, j]);

            this.Controls.Remove(_resetButton);
            this.Controls.Remove(_timerThisGame);
            this.Controls.Remove(_countBombsRemains);
        }
        public void GameFieldRebuild()
        {
            Sapper.CellOfGameField.GameFieldClose();
            _timerThisGame.Reset();
            _countBombsRemains.Reset();

            Sapper.CellOfGameField.GameFieldRebuild();
        }

        private System.Windows.Forms.MenuStrip MenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem GameMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}
