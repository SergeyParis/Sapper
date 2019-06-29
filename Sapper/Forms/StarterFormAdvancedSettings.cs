using System;
using System.Configuration;

namespace Sapper.Forms
{
    partial class StarterForm
    {
        private int _chanceOfExplosionBombs = 100;
        private int _countHpCells;
        private int _countStartHp;
        internal int ChanceOfExplosionBombs => _chanceOfExplosionBombs;
        internal int CountHpCells => _countHpCells;

        private const int ADVANCED_SETTINGS_LOCATION_Y_FORM = 100;

        private const int ADVANCED_SETTINGS_LOCATION_X_FIRST_COLUMN = 15;
        private const int ADVANCED_SETTINGS_LOCATION_Y_FIRST_COLUMN = 120;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_X_FIRST_COLUMN = 200;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_Y_FIRST_COLUMN = 20;

        private const int ADVANCED_SETTINGS_LOCATION_X_SECOND_COLUMN = 245;
        private const int ADVANCED_SETTINGS_LOCATION_Y_SECOND_COLUMN = 120;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_X_SECOND_COLUMN = 50;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_Y_SECOND_COLUMN = 20;

        private const int ADVANCED_SETTINGS_LOCATION_X_THIRD_COLUMN = 295;
        private const int ADVANCED_SETTINGS_LOCATION_Y_THIRD_COLUMN = 120;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_X_THIRD_COLUMN = 50;
        private const int ADVANCED_SETTINGS_SIZE_CONTROLS_Y_THIRD_COLUMN = 20;

        private const int ADVANCED_SETTINGS_LOCATION_Y_DELTA = 20;

        private System.Windows.Forms.CheckBox _chanceOfExplosionCheckBox;
        private System.Windows.Forms.TextBox _chanceOfExplosionTextBox;

        private System.Windows.Forms.CheckBox _enabledHpCellsCheckBox;
        private System.Windows.Forms.TextBox _enabledHpCellsTextBox;
        private System.Windows.Forms.TextBox _enabledHpCellsStarterHpTextBox;

        private void ShowAdvancedSettings()
        {
            // Form
            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height + ADVANCED_SETTINGS_LOCATION_Y_FORM);

            BuildControlsChanceOfExplosion();
            BuildControlsEnabledHpCells();
        }
        private void HideAdvancedSettings()
        {
            HideControlsChanceOfExplosion();
            HideControlsEnabledHpCells();
        }

        private void BuildControlsChanceOfExplosion()
        {
            _chanceOfExplosionCheckBox = new System.Windows.Forms.CheckBox();
            _chanceOfExplosionTextBox = new System.Windows.Forms.TextBox();

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

            _chanceOfExplosionTextBox.Text = _chanceOfExplosionBombs.ToString();
            _chanceOfExplosionTextBox.AppendText("%");

            _chanceOfExplosionTextBox.LostFocus += new System.EventHandler(this.ChanceOfExplosionTextBox_LostFocus);

            this.Controls.Add(_chanceOfExplosionCheckBox);
            this.Controls.Add(_chanceOfExplosionTextBox);
        }
        private void HideControlsChanceOfExplosion()
        {
            this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - ADVANCED_SETTINGS_LOCATION_Y_FORM);

            this.Controls.Remove(_chanceOfExplosionCheckBox);
            this.Controls.Remove(_chanceOfExplosionTextBox);
        }

        private void BuildControlsEnabledHpCells()
        {
            // CheckBox_enabledHpCells
            _enabledHpCellsCheckBox = new System.Windows.Forms.CheckBox();
            _enabledHpCellsTextBox = new System.Windows.Forms.TextBox();
            _enabledHpCellsStarterHpTextBox = new System.Windows.Forms.TextBox();

            _enabledHpCellsCheckBox.Text = "HP Cells / HP Start";
            _enabledHpCellsCheckBox.Size = new System.Drawing.Size(ADVANCED_SETTINGS_SIZE_CONTROLS_X_FIRST_COLUMN,
                                                                      ADVANCED_SETTINGS_SIZE_CONTROLS_Y_FIRST_COLUMN);
            _enabledHpCellsCheckBox.Location = new System.Drawing.Point(ADVANCED_SETTINGS_LOCATION_X_FIRST_COLUMN,
                                                                           ADVANCED_SETTINGS_LOCATION_Y_FIRST_COLUMN + ADVANCED_SETTINGS_LOCATION_Y_DELTA);
            _enabledHpCellsCheckBox.CheckedChanged += new System.EventHandler(this.EnabledHpCellsCheckBox_CheckedChanged);

            // TextBox_enabledHpCells
            _enabledHpCellsTextBox.Size = new System.Drawing.Size(ADVANCED_SETTINGS_SIZE_CONTROLS_X_SECOND_COLUMN,
                                                                      ADVANCED_SETTINGS_SIZE_CONTROLS_Y_SECOND_COLUMN);
            _enabledHpCellsTextBox.Location = new System.Drawing.Point(ADVANCED_SETTINGS_LOCATION_X_SECOND_COLUMN,
                                                                           ADVANCED_SETTINGS_LOCATION_Y_SECOND_COLUMN + ADVANCED_SETTINGS_LOCATION_Y_DELTA);
            _enabledHpCellsTextBox.Enabled = false;
            _enabledHpCellsTextBox.Text = _countHpCells.ToString();
            _enabledHpCellsTextBox.LostFocus += new System.EventHandler(this.EnabledHpCellsTextBox_LostFocus);

            // TextBox_enabledHpCellsStarterHp
            _enabledHpCellsStarterHpTextBox.Size = new System.Drawing.Size(ADVANCED_SETTINGS_SIZE_CONTROLS_X_THIRD_COLUMN,
                                                                      ADVANCED_SETTINGS_SIZE_CONTROLS_Y_THIRD_COLUMN);
            _enabledHpCellsStarterHpTextBox.Location = new System.Drawing.Point(ADVANCED_SETTINGS_LOCATION_X_THIRD_COLUMN,
                                                                           ADVANCED_SETTINGS_LOCATION_Y_THIRD_COLUMN + ADVANCED_SETTINGS_LOCATION_Y_DELTA);
            _enabledHpCellsStarterHpTextBox.Enabled = false;
            _enabledHpCellsStarterHpTextBox.Text = _countStartHp.ToString();
            _enabledHpCellsStarterHpTextBox.LostFocus += new System.EventHandler(this.EnabledHpCellsStartHpTextBox_LostFocus);

            this.Controls.Add(_enabledHpCellsCheckBox);
            this.Controls.Add(_enabledHpCellsTextBox);
            this.Controls.Add(_enabledHpCellsStarterHpTextBox);
        }
        private void HideControlsEnabledHpCells()
        {
            this.Controls.Remove(_enabledHpCellsCheckBox);
            this.Controls.Remove(_enabledHpCellsTextBox);
            this.Controls.Remove(_enabledHpCellsStarterHpTextBox);
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

        private void EnabledHpCellsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this._enabledHpCellsCheckBox.Checked)
            {
                this._enabledHpCellsTextBox.Enabled = true;
                this._enabledHpCellsStarterHpTextBox.Enabled = true;
            }
            else
            {
                this._enabledHpCellsTextBox.Enabled = false;
                this._enabledHpCellsStarterHpTextBox.Enabled = false;
            }
        }
        private void EnabledHpCellsTextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(this._enabledHpCellsTextBox.Text);

                // count empty cells
                int maxCountHpCells = (Convert.ToInt32(this.fieldWidthTxtBox.Text) *
                                       Convert.ToInt32(this.fieldHeightTxtBox.Text)) -
                                      Convert.ToInt32(this.countMinesTxtBox.Text);
                if ( (maxCountHpCells + _countHpCells) < value)
                    throw new FormatException();

                _countHpCells = value;
            }
            catch (FormatException) { }
            catch { System.Windows.Forms.MessageBox.Show("EXCEPTION_COUNT_HP_CELLS"); }
            finally { this._enabledHpCellsTextBox.Text = _countHpCells.ToString(); }
        }
        private void EnabledHpCellsStartHpTextBox_LostFocus(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(this._enabledHpCellsStarterHpTextBox.Text);

                // count empty cells
                int maxCountHpCells = (Convert.ToInt32(this.fieldWidthTxtBox.Text) *
                                       Convert.ToInt32(this.fieldHeightTxtBox.Text)) -
                                      Convert.ToInt32(this.countMinesTxtBox.Text);
                if ((maxCountHpCells + _countHpCells) < value)
                    throw new FormatException();

                _countStartHp = value;
            }
            catch (FormatException) { }
            catch { System.Windows.Forms.MessageBox.Show("EXCEPTION_COUNT_START_HP_CELLS"); }
            finally { this._enabledHpCellsStarterHpTextBox.Text = _countStartHp.ToString(); }
        }
    }
}

