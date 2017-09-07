namespace Balls.Controls
{
    partial class pDraw
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
            this.pBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(0, 0);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(420, 326);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            this.pBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ReDraw);
            this.pBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AddBall);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.Update);
            // 
            // ballTimer
            // 
            this.ballTimer.Tick += new System.EventHandler(this.Update);
            // 
            // pDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBox);
            this.Name = "pDraw";
            this.Size = new System.Drawing.Size(420, 326);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer ballTimer;
    }
}
