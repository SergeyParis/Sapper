using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Sapper.Forms
{
    public partial class StarterForm : Form
    {
        private const int DIFFICULTY_BEGGINER_WIDTH_HEIGHT = 9;
        private const int DIFFICULTY_BEGGINER_MINES = 10;
        private const int DIFFICULTY_INTERMEDIATE_WIDTH_HEIGHT = 16;
        private const int DIFFICULTY_INTERMEDIATE_MINES = 40;
        private const int DIFFICULTY_PROFESSIONAL_WIDTH = 30;
        private const int DIFFICULTY_PROFESSIONAL_HEIGHT = 16;
        private const int DIFFICULTY_PROFESSIONAL_MINES = 99;

        public readonly Form SenderForm;

        public StarterForm(Form senderForm)
        {
            InitializeComponent();
            this.SenderForm = senderForm;

            this.difficultyComboBox.SelectedIndex = 0;
        }

        private void difficultyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.difficultyComboBox.SelectedIndex)
            {
                case 0:
                    fieldWidthTxtBox.ReadOnly =
                        fieldHeightTxtBox.ReadOnly =
                            countMinesTxtBox.ReadOnly = true;

                    fieldWidthTxtBox.Text = fieldHeightTxtBox.Text =
                        Convert.ToString(DIFFICULTY_BEGGINER_WIDTH_HEIGHT);
                    countMinesTxtBox.Text =
                        Convert.ToString(DIFFICULTY_BEGGINER_MINES);
                    break;
                case 1:
                    fieldWidthTxtBox.ReadOnly =
                        fieldHeightTxtBox.ReadOnly =
                            countMinesTxtBox.ReadOnly = true;

                    fieldWidthTxtBox.Text = fieldHeightTxtBox.Text =
                        Convert.ToString(DIFFICULTY_INTERMEDIATE_WIDTH_HEIGHT);
                    countMinesTxtBox.Text =
                        Convert.ToString(DIFFICULTY_INTERMEDIATE_MINES);
                    break;
                case 2:
                    fieldWidthTxtBox.ReadOnly =
                        fieldHeightTxtBox.ReadOnly =
                            countMinesTxtBox.ReadOnly = true;

                    fieldWidthTxtBox.Text =
                        Convert.ToString(DIFFICULTY_PROFESSIONAL_WIDTH);
                    fieldHeightTxtBox.Text =
                        Convert.ToString(DIFFICULTY_PROFESSIONAL_HEIGHT);
                    countMinesTxtBox.Text =
                        Convert.ToString(DIFFICULTY_PROFESSIONAL_MINES);
                    break;
                case 3:
                    fieldWidthTxtBox.ReadOnly =
                        fieldHeightTxtBox.ReadOnly =
                            countMinesTxtBox.ReadOnly = false;
                    break;

            }

        }
        private void goBtn_Click(object sender, EventArgs e)
        {
            this.goBtn.Enabled = false;
            this.Hide();
            
            ((MainForm)SenderForm).SetPropertiesGameField(Convert.ToInt32(this.fieldWidthTxtBox.Text),
                                                          Convert.ToInt32(this.fieldHeightTxtBox.Text),
                                                          Convert.ToInt32(this.countMinesTxtBox.Text));
            ((MainForm)SenderForm).SetChanceOfExplosionBombs(_chanceOfExplosionBombs);

            SenderForm.Show();
        }
        private void StarterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void StarterForm_VisibleChanged(object sender, EventArgs e)
        {
            if (true == this.Visible)
                this.goBtn.Enabled = true;
        }

        private void advancedSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this.advancedSettings.Checked)
            {
                ShowAdvancedSettings();
            }
            else
            {
                HideAdvancedSettings();
            }
        }
    }
}
