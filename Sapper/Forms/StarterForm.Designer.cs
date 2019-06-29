namespace Sapper.Forms
{
    partial class StarterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.countMinesLbl = new System.Windows.Forms.Label();
            this.fieldHeightLbl = new System.Windows.Forms.Label();
            this.fieldWidthLbl = new System.Windows.Forms.Label();
            this.countMinesTxtBox = new System.Windows.Forms.TextBox();
            this.fieldHeightTxtBox = new System.Windows.Forms.TextBox();
            this.fieldWidthTxtBox = new System.Windows.Forms.TextBox();
            this.difficultyComboBox = new System.Windows.Forms.ComboBox();
            this.difficultyLbl = new System.Windows.Forms.Label();
            this.goBtn = new System.Windows.Forms.Button();
            this.advancedSettings = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // countMinesLbl
            // 
            this.countMinesLbl.AutoSize = true;
            this.countMinesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countMinesLbl.Location = new System.Drawing.Point(245, 13);
            this.countMinesLbl.Name = "countMinesLbl";
            this.countMinesLbl.Size = new System.Drawing.Size(96, 18);
            this.countMinesLbl.TabIndex = 0;
            this.countMinesLbl.Text = "Count mines:";
            this.countMinesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldHeightLbl
            // 
            this.fieldHeightLbl.AutoSize = true;
            this.fieldHeightLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldHeightLbl.Location = new System.Drawing.Point(245, 55);
            this.fieldHeightLbl.Name = "fieldHeightLbl";
            this.fieldHeightLbl.Size = new System.Drawing.Size(86, 18);
            this.fieldHeightLbl.TabIndex = 1;
            this.fieldHeightLbl.Text = "Field height:";
            this.fieldHeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldWidthLbl
            // 
            this.fieldWidthLbl.AutoSize = true;
            this.fieldWidthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldWidthLbl.Location = new System.Drawing.Point(244, 79);
            this.fieldWidthLbl.Name = "fieldWidthLbl";
            this.fieldWidthLbl.Size = new System.Drawing.Size(81, 18);
            this.fieldWidthLbl.TabIndex = 2;
            this.fieldWidthLbl.Text = "Field width:";
            this.fieldWidthLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // countMinesTxtBox
            // 
            this.countMinesTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.countMinesTxtBox.Location = new System.Drawing.Point(344, 17);
            this.countMinesTxtBox.Name = "countMinesTxtBox";
            this.countMinesTxtBox.Size = new System.Drawing.Size(100, 13);
            this.countMinesTxtBox.TabIndex = 1;
            this.countMinesTxtBox.Text = "10";
            // 
            // fieldHeightTxtBox
            // 
            this.fieldHeightTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldHeightTxtBox.Location = new System.Drawing.Point(344, 57);
            this.fieldHeightTxtBox.Name = "fieldHeightTxtBox";
            this.fieldHeightTxtBox.Size = new System.Drawing.Size(100, 13);
            this.fieldHeightTxtBox.TabIndex = 2;
            this.fieldHeightTxtBox.Text = "9";
            // 
            // fieldWidthTxtBox
            // 
            this.fieldWidthTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldWidthTxtBox.Location = new System.Drawing.Point(344, 84);
            this.fieldWidthTxtBox.Name = "fieldWidthTxtBox";
            this.fieldWidthTxtBox.Size = new System.Drawing.Size(100, 13);
            this.fieldWidthTxtBox.TabIndex = 3;
            this.fieldWidthTxtBox.Text = "9";
            // 
            // difficultyComboBox
            // 
            this.difficultyComboBox.FormattingEnabled = true;
            this.difficultyComboBox.Items.AddRange(new object[] {
            "Begginer",
            "Intermediate",
            "Professional",
            "Custom"});
            this.difficultyComboBox.Location = new System.Drawing.Point(97, 10);
            this.difficultyComboBox.MaxDropDownItems = 5;
            this.difficultyComboBox.Name = "difficultyComboBox";
            this.difficultyComboBox.Size = new System.Drawing.Size(121, 21);
            this.difficultyComboBox.TabIndex = 0;
            this.difficultyComboBox.SelectedIndexChanged += new System.EventHandler(this.difficultyComboBox_SelectedIndexChanged);
            // 
            // difficultyLbl
            // 
            this.difficultyLbl.AutoSize = true;
            this.difficultyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.difficultyLbl.Location = new System.Drawing.Point(15, 13);
            this.difficultyLbl.Name = "difficultyLbl";
            this.difficultyLbl.Size = new System.Drawing.Size(67, 18);
            this.difficultyLbl.TabIndex = 4;
            this.difficultyLbl.Text = "Difficulty:";
            this.difficultyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(15, 79);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(203, 23);
            this.goBtn.TabIndex = 5;
            this.goBtn.Text = "Go!";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // advancedSettings
            // 
            this.advancedSettings.AutoSize = true;
            this.advancedSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.advancedSettings.Location = new System.Drawing.Point(15, 45);
            this.advancedSettings.Name = "advancedSettings";
            this.advancedSettings.Size = new System.Drawing.Size(79, 19);
            this.advancedSettings.TabIndex = 6;
            this.advancedSettings.Text = "Advanced";
            this.advancedSettings.UseVisualStyleBackColor = true;
            this.advancedSettings.CheckedChanged += new System.EventHandler(this.advancedSettings_CheckedChanged);
            // 
            // StarterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(474, 118);
            this.Controls.Add(this.advancedSettings);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.difficultyLbl);
            this.Controls.Add(this.difficultyComboBox);
            this.Controls.Add(this.fieldWidthTxtBox);
            this.Controls.Add(this.fieldHeightTxtBox);
            this.Controls.Add(this.countMinesTxtBox);
            this.Controls.Add(this.fieldWidthLbl);
            this.Controls.Add(this.fieldHeightLbl);
            this.Controls.Add(this.countMinesLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StarterForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StarterForm_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.StarterForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label countMinesLbl;
        private System.Windows.Forms.Label fieldHeightLbl;
        private System.Windows.Forms.Label fieldWidthLbl;
        internal System.Windows.Forms.TextBox countMinesTxtBox;
        internal System.Windows.Forms.TextBox fieldHeightTxtBox;
        internal System.Windows.Forms.TextBox fieldWidthTxtBox;
        private System.Windows.Forms.Label difficultyLbl;
        internal System.Windows.Forms.ComboBox difficultyComboBox;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.CheckBox advancedSettings;
    }
}