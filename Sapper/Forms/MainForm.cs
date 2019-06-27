using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sapper.Forms
{
    public partial class MainForm : Form
    {
        private readonly StarterForm _starterForm;
        private int GameFieldWidth;
        private int GameFieldHeight;
        public MainForm GetRefMainForm => this;
        public StarterForm GetRefStarterForm => _starterForm;

        public MainForm()
        {
            InitializeComponent();

            _starterForm = new StarterForm(this);
        }

        public void SetHeightWidthGameField(int gameFieldWidth, int gameFieldHeight)
        {
            this.GameFieldWidth = gameFieldWidth;
            this.GameFieldHeight = gameFieldHeight;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            _starterForm.ShowDialog();
        }
        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (true == this.Visible)
                this.GameFieldCreate(GameFieldWidth, GameFieldHeight);
            else
                this.GameFieldDelete(GameFieldWidth, GameFieldHeight);
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _starterForm.Show();
            this.Hide();
        }
    }
}
