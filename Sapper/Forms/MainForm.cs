using System;
using System.Windows.Forms;

namespace Sapper.Forms
{
    public partial class MainForm : Form
    {
        private readonly StarterForm _starterForm;
        public MainForm()
        {
            InitializeComponent();

            _starterForm = new StarterForm(this);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();   
            _starterForm.ShowDialog();
        }
        public MainForm GetRefMainForm => this;
        public StarterForm GetRefStarterForm => _starterForm;
    }
}
