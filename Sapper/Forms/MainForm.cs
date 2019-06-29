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

        public MainForm()
        {
            InitializeComponent();

            _starterForm = new StarterForm(this);
        }
        
        public void SetPropertiesGameField (int gameFieldWidth, int gameFieldHeight, int countOfBombs)
        {
            this._gameFieldWidth = gameFieldWidth;
            this._gameFieldHeight = gameFieldHeight;
            this._countOfBombs = countOfBombs;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            _starterForm.ShowDialog();
        }
        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (true == this.Visible)
                this.GameFieldCreate(_gameFieldWidth, _gameFieldHeight, _countOfBombs);
            else
                this.GameFieldDelete(_gameFieldWidth, _gameFieldHeight);
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _starterForm.Show();
            this.Hide();
        }
    }
}
