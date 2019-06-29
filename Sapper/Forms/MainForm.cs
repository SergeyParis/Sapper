using System;
using Sapper.GameField;
using System.Windows.Forms;

namespace Sapper.Forms
{
    public partial class MainForm : Form
    {
        private readonly StarterForm _starterForm;

        private int _gameFieldWidth;
        private int _gameFieldHeight;
        private int _countOfBombs;
        private int _chanceOfExplosionBombs;
        private int _countHpCells;

        private bool _gameStop = false;

        internal int GameFieldWidth => _gameFieldWidth;
        internal int GameFieldHeight => _gameFieldHeight;
        internal int CountOfBombs => _countOfBombs;
        internal int GetChanceOfExplosionBombs => _chanceOfExplosionBombs;
        internal int GetCountHpCells => _countHpCells;
        internal Sapper.GameField.GameField GameField => _gameField;
        internal bool GetThisGameStop  => _gameStop;
        internal bool GetTimerEnabled => _timerThisGame.GetEnabled;
        internal int HpPlayer { get; set; }

        public MainForm()
        {
            InitializeComponent();

            _starterForm = new StarterForm(this);
        }

        public void SetPropertiesGameField(int gameFieldWidth, int gameFieldHeight, int countOfBombs)
        {
            this._gameFieldWidth = gameFieldWidth;
            this._gameFieldHeight = gameFieldHeight;
            this._countOfBombs = countOfBombs;
        }
        public void SetPropertiesAdvancedGameField(int chanceExplosion, int countHpCells, int hpPlayer)
        {
            _chanceOfExplosionBombs = chanceExplosion;
            _countHpCells = countHpCells;
            HpPlayer = hpPlayer;
        }

        public void GetFocus()
        {
            this.label1.Focus();
        }
        
        public void ChangeSize()
        {
            if (GameFieldWidth > 0 && GameFieldHeight > 0)
                this.Size =
                    new System.Drawing.Size(
                        _gameField.SizeX + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                        _gameField.SizeY + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
        
        public void TimerStart()
        {
            this._timerThisGame.Start();
        }
        public void TimerStop()
        {
            this._timerThisGame.Stop();
        }

        public void SetCounterBombsIncrease(int value)
        {
            this._countBombsRemains.SetCountBombs(this._countBombsRemains.GetBombs + value);
        }
        public void SetCounterBombsDecrease(int value)
        {
            this._countBombsRemains.SetCountBombs(this._countBombsRemains.GetBombs - value);
        }

        public void GameWin()
        {
            this._gameStop = true;

            _timerThisGame.Stop();
            this._resetButton.Image = Properties.Textures.Win7.win7_resetGameWin;
            _gameField.Lock();
        }
        public void GameLose()
        {
            this._gameStop = true;

            _timerThisGame.Stop();
            _gameField.OpenBomb();
            _gameField.Lock();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            _starterForm.ShowDialog();
        }
        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (true == this.Visible)
            {
                this.GameFieldCreate();
                this._countBombsRemains.SetCountBombs(_countOfBombs);
            }
            else
                this.GameFieldDelete();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _starterForm.Show();
            this.Hide();
        }
        private void OnClickResetButton(object sender, EventArgs e)
        {
            this._gameStop = false;
            this._gameField.Unlock();

            this.GameFieldRebuild();

            this._timerThisGame.Reset();
            this._countBombsRemains.SetCountBombs(_countOfBombs);

            this._resetButton.Image = Properties.Textures.Win7.win7_resetGame;

            this.GetFocus();
        }
    }
}
