namespace Sapper
{
    partial class UserTimer
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TimerPart_100 = new System.Windows.Forms.PictureBox();
            this.TimerPart_10 = new System.Windows.Forms.PictureBox();
            this.TimerPart_1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_1)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerPart_100
            // 
            this.TimerPart_100.Location = new System.Drawing.Point(0, 0);
            this.TimerPart_100.Name = "TimerPart_100";
            this.TimerPart_100.Size = new System.Drawing.Size(140, 200);
            this.TimerPart_100.TabIndex = 0;
            this.TimerPart_100.TabStop = false;
            // 
            // TimerPart_10
            // 
            this.TimerPart_10.Location = new System.Drawing.Point(140, 0);
            this.TimerPart_10.Name = "TimerPart_10";
            this.TimerPart_10.Size = new System.Drawing.Size(140, 200);
            this.TimerPart_10.TabIndex = 1;
            this.TimerPart_10.TabStop = false;
            // 
            // TimerPart_1
            // 
            this.TimerPart_1.Location = new System.Drawing.Point(280, 0);
            this.TimerPart_1.Name = "TimerPart_1";
            this.TimerPart_1.Size = new System.Drawing.Size(140, 200);
            this.TimerPart_1.TabIndex = 2;
            this.TimerPart_1.TabStop = false;
            // 
            // UserTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimerPart_1);
            this.Controls.Add(this.TimerPart_10);
            this.Controls.Add(this.TimerPart_100);
            this.Name = "UserTimer";
            this.Size = new System.Drawing.Size(420, 200);
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPart_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TimerPart_100;
        private System.Windows.Forms.PictureBox TimerPart_10;
        private System.Windows.Forms.PictureBox TimerPart_1;
    }
}
