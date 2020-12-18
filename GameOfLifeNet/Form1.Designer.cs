
namespace GameOfLifeNet
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.PictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.TimerTick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxCanvas
            // 
            this.PictureBoxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxCanvas.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxCanvas.Name = "PictureBoxCanvas";
            this.PictureBoxCanvas.Size = new System.Drawing.Size(590, 400);
            this.PictureBoxCanvas.TabIndex = 0;
            this.PictureBoxCanvas.TabStop = false;
            // 
            // TimerTick
            // 
            this.TimerTick.Interval = 1;
            this.TimerTick.Tick += new System.EventHandler(this.TimerTick_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(590, 400);
            this.Controls.Add(this.PictureBoxCanvas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxCanvas;
        private System.Windows.Forms.Timer TimerTick;
    }
}

