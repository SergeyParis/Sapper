using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper.Forms
{
    public partial class MainForm : Form
    {
        private readonly StarterForm _starterForm;
        private int _getGameFieldWidth;
        private int _getGameFieldHeight;
        private int _getCountOfBombs;
        private int _chanceOfExplosionBombs;
        private bool _gameStop = false;
        
        internal int GetGameFieldWidth => _getGameFieldWidth;
        internal int GetGameFieldHeight => _getGameFieldHeight;
        internal int GetCountOfBombs => _getCountOfBombs;
        internal int GetChanceOfExplosionBombs => _chanceOfExplosionBombs;
        internal GameField GameField => _gameField;
        internal bool GetThisGameStop  => _gameStop;
        internal bool GetTimerEnabled => _timerThisGame.GetEnabled;

        public MainForm()
        {
            InitializeComponent();

            _starterForm = new StarterForm(this);
        }

        public void SetPropertiesGameField(int gameFieldWidth, int gameFieldHeight, int countOfBombs)
        {
            this._getGameFieldWidth = gameFieldWidth;
            this._getGameFieldHeight = gameFieldHeight;
            this._getCountOfBombs = countOfBombs;
        }
        public void SetChanceOfExplosionBombs(int chance)
        {
            _chanceOfExplosionBombs = chance;
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
                this._countBombsRemains.SetCountBombs(_getCountOfBombs);
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
            this._countBombsRemains.SetCountBombs(_getCountOfBombs);

            this._resetButton.Image = Properties.Textures.Win7.win7_resetGame;
        }
        public void ChangeSize()
        {
            if (GetGameFieldWidth > 0 && GetGameFieldHeight > 0)
                this.Size =
                    new System.Drawing.Size(
                        _gameField.SizeX + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                        _gameField.SizeY + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }

        public void GetFocus()
        {
            this.label1.Focus();
        }
    }
}
