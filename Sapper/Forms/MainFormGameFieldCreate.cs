namespace Sapper.Forms
{
    partial class MainForm 
    {
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

        internal const int FORM_PADDING_LAST_FIELD_BUTTON_WIDTH = 60;    // kostuli
        internal const int FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT = 80;   // kostuli

        private Sapper.GameField.GameField _gameField;
        private System.Windows.Forms.Button _resetButton;
        private Sapper.Controls.UserTimer _timerThisGame;
        private Sapper.Controls.CountBombsRemains _countBombsRemains;
        public void GameFieldCreate()
        {
            _gameField = new Sapper.GameField.GameField(this, _gameFieldWidth, _gameFieldHeight);

            _gameField.Build();

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
                    this.Controls.Remove(GameField[i, j]);

            this.Controls.Remove(_resetButton);
            this.Controls.Remove(_timerThisGame);
            this.Controls.Remove(_countBombsRemains);
        }
        public void GameFieldRebuild()
        {
            _gameField.Clear();
            _timerThisGame.Reset();
            _countBombsRemains.Reset();

            _gameField.Rebuild();
        }

        
    }
}
