namespace Sapper
{
    partial class Counter
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
            this.components = new System.ComponentModel.Container();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.ValuePart_100 = new System.Windows.Forms.PictureBox();
            this.ValuePart_10 = new System.Windows.Forms.PictureBox();
            this.ValuePart_1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_1)).BeginInit();
            this.SuspendLayout();
            // 
            // ValuePart_100
            // 
            this.ValuePart_100.Location = new System.Drawing.Point(0, 0);
            this.ValuePart_100.Name = "ValuePart_100";
            this.ValuePart_100.Size = new System.Drawing.Size(11, 21);
            this.ValuePart_100.TabIndex = 0;
            this.ValuePart_100.TabStop = false;
            // 
            // ValuePart_10
            // 
            this.ValuePart_10.Location = new System.Drawing.Point(11, 0);
            this.ValuePart_10.Name = "ValuePart_10";
            this.ValuePart_10.Size = new System.Drawing.Size(11, 21);
            this.ValuePart_10.TabIndex = 1;
            this.ValuePart_10.TabStop = false;
            // 
            // ValuePart_1
            // 
            this.ValuePart_1.Location = new System.Drawing.Point(22, 0);
            this.ValuePart_1.Name = "ValuePart_1";
            this.ValuePart_1.Size = new System.Drawing.Size(11, 21);
            this.ValuePart_1.TabIndex = 2;
            this.ValuePart_1.TabStop = false;
            // 
            // Counter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ValuePart_1);
            this.Controls.Add(this.ValuePart_10);
            this.Controls.Add(this.ValuePart_100);
            this.Name = "Counter";
            this.Size = new System.Drawing.Size(33, 21);
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuePart_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ValuePart_100;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox ValuePart_10;
        private System.Windows.Forms.PictureBox ValuePart_1;
    }
}
