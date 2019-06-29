using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper.Forms
{
    public partial class MainForm : Form
    {
        private readonly StarterForm _starterForm;
        private int _gameFieldWidth;
        private int _gameFieldHeight;
        private int _countOfBombs;

        public int GameFieldWidth => _gameFieldWidth;
        public int GameFieldHeight => _gameFieldHeight;
        public int CountOfBombs => _countOfBombs;
        internal GameField GameField => _gameField;

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
            _timerThisGame.Stop();
            this._resetButton.Image = Properties.Textures.Win7.win7_resetGameWin;
            _gameField.Lock();
        }
        public void GameLose()
        {
            _timerThisGame.Stop();
            _gameField.Open();
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
            
            this.GameFieldRebuild();

            this._timerThisGame.Reset();
            this._countBombsRemains.SetCountBombs(_countOfBombs);
        }
        public void ChangeSize()
        {
            if (GameFieldWidth > 0 && GameFieldHeight > 0)
                this.Size =
                    new System.Drawing.Size(
                        _gameField.SizeX + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_WIDTH,
                        _gameField.SizeY + Sapper.Forms.MainForm.FORM_PADDING_LAST_FIELD_BUTTON_HEIGHT);
        }
    }
}
