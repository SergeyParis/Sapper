namespace Sapper.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 373);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button[,] _gameFieldButtons;

        private void GameFieldCreate(int gameFieldWidth, int gameFieldHeight)
        {
            _gameFieldButtons = new System.Windows.Forms.Button[gameFieldHeight, gameFieldWidth];
            for (int i = 0; i < gameFieldHeight; i++)
                for (int j = 0; j < gameFieldWidth; j++)
                {
                    _gameFieldButtons[i, j] = new System.Windows.Forms.Button();
                    _gameFieldButtons[i, j].Location = new System.Drawing.Point(25 + (i * 24), 80 + (j * 24));
                    _gameFieldButtons[i, j].Size = new System.Drawing.Size(25, 25);

                    this.Controls.Add(_gameFieldButtons[i, j]);
                }
        }
        private void GameFieldDelete(int gameFieldWidth, int gameFieldHeight)
        {
            for (int i = 0; i < GameFieldHeight; i++)
                for (int j = 0; j < GameFieldWidth; j++)
                    this.Controls.Remove(_gameFieldButtons[i, j]);
        }

        //private System.Collections.Generic.List<System.Windows.Forms.Button> _gameFieldButtons = 
        //    new System.Collections.Generic.List<System.Windows.Forms.Button>();
    }
}

