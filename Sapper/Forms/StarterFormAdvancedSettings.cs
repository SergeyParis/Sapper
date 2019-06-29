using System;

namespace Sapper.Forms
{
    partial class StarterForm
    {
        private int _chanceOfExplosionBombs = 100;
        internal int ChanceOfExplosionBombs => _chanceOfExplosionBombs;

        private const int ADVANCED_SETTINGS_LOCATION_Y_FORM = 100;

        private const int ADVANCED_SETTINGS_LOCATION_X_FIRST_COLUMN = 15;
        private const int ADVANCED_SETTINGS_LOCATION_Y_FIRST_COLUMN = 120;
        private const int ADVANCED_SETTINGS_LOCATION_Y_FIRST_COLUMN_DELTA = 20;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_X_FIRST_COLUMN = 200;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_Y_FIRST_COLUMN = 20;

        private const int ADVANCED_SETTINGS_LOCATION_X_SECOND_COLUMN = 215;
        private const int ADVANCED_SETTINGS_LOCATION_Y_SECOND_COLUMN = 120;
        private const int ADVANCED_SETTINGS_LOCATION_Y_SECOND_COLUMN_DELTA = 20;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_X_SECOND_COLUMN = 100;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_Y_SECOND_COLUMN = 20;

        private System.Windows.Forms.CheckBox _chanceOfExplosionCheckBox;
        private System.Windows.Forms.TextBox _chanceOfExplosionTextBox;

        private void ShowAdvancedSettings()
        {
            BuildAdvancedControls();
        }

        private void BuildAdvancedControls()
        {
            _chanceOfExplosionCheckBox = new System.Windows.Forms.CheckBox();
            _chanceOfExplosionTextBox = new System.Windows.Forms.TextBox();

            // Form
            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height + ADVANCED_SETTINGS_LOCATION_Y_FORM);

            // CheckBox_chanceExplosion
            _chanceOfExplosionCheckBox.Text = "Advanced change of explosion bombs";
            _chanceOfExplosionCheckBox.Size = new System.Drawing.Size(ADVANCED_SETTINGS_SIZE_CONTROLS_X_FIRST_COLUMN,
                                                                      ADVANCED_SETTINGS_SIZE_CONTROLS_Y_FIRST_COLUMN);
            _chanceOfExplosionCheckBox.Location = new System.Drawing.Point(ADVANCED_SETTINGS_LOCATION_X_FIRST_COLUMN,
                                                                           ADVANCED_SETTINGS_LOCATION_Y_FIRST_COLUMN);
            _chanceOfExplosionCheckBox.CheckedChanged += new System.EventHandler(this.ChanceOfExplosionCheckBox_CheckedChanged);

            // TextBox_chanceExplosion
            _chanceOfExplosionTextBox.Size = new System.Drawing.Size(ADVANCED_SETTINGS_SIZE_CONTROLS_X_SECOND_COLUMN,
                                                                      ADVANCED_SETTINGS_SIZE_CONTROLS_Y_SECOND_COLUMN);
            _chanceOfExplosionTextBox.Location = new System.Drawing.Point(ADVANCED_SETTINGS_LOCATION_X_SECOND_COLUMN,
                                                                           ADVANCED_SETTINGS_LOCATION_Y_SECOND_COLUMN);
            _chanceOfExplosionTextBox.Enabled = false;
            _chanceOfExplosionTextBox.Text = "100%";
            _chanceOfExplosionTextBox.LostFocus += new System.EventHandler(this.ChanceOfExplosionTextBox_LostFocus);

            this.Controls.Add(_chanceOfExplosionCheckBox);
            this.Controls.Add(_chanceOfExplosionTextBox);
        }
        private void ChanceOfExplosionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this._chanceOfExplosionCheckBox.Checked)
                this._chanceOfExplosionTextBox.Enabled = true;
            else
                this._chanceOfExplosionTextBox.Enabled = false;
        }
        private void ChanceOfExplosionTextBox_LostFocus(object sender, EventArgs e)
        {
            string text;
            if ('%' == this._chanceOfExplosionTextBox.Text[this._chanceOfExplosionTextBox.Text.Length - 1])
                text = this._chanceOfExplosionTextBox.Text.Remove(this._chanceOfExplosionTextBox.Text.Length - 1);
            else
                text = this._chanceOfExplosionTextBox.Text;

            foreach (char c in text)
                if (57 < c || c < 48)
                {
                    this._chanceOfExplosionTextBox.Text = Convert.ToString(_chanceOfExplosionBombs); ;
                    this._chanceOfExplosionTextBox.AppendText("%");
                    
                    return;
                }

            if (100 < Convert.ToInt32(text) || 0 > Convert.ToInt32(text))
            {
                this._chanceOfExplosionTextBox.Text = Convert.ToString(_chanceOfExplosionBombs); ;
                this._chanceOfExplosionTextBox.AppendText("%");

                return;
            }
            
            this._chanceOfExplosionTextBox.Text = text;
            this._chanceOfExplosionTextBox.AppendText("%");
            
            _chanceOfExplosionBombs = Convert.ToInt32(text);
        }

        private void HideAdvancedSettings()
        {
            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - ADVANCED_SETTINGS_LOCATION_Y_FORM);

            this.Controls.Remove(_chanceOfExplosionCheckBox);
            this.Controls.Remove(_chanceOfExplosionTextBox);
        }
    }
}

