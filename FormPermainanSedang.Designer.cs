
namespace Tugas_Proyek
{
    partial class FormPermainanSedang
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
            this.label_skor = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_skor
            // 
            this.label_skor.AutoSize = true;
            this.label_skor.BackColor = System.Drawing.Color.Transparent;
            this.label_skor.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.label_skor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_skor.Location = new System.Drawing.Point(11, 9);
            this.label_skor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_skor.Name = "label_skor";
            this.label_skor.Size = new System.Drawing.Size(206, 39);
            this.label_skor.TabIndex = 1;
            this.label_skor.Text = "SCORE = 0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 30;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Tugas_Proyek.Resource1.soundOn;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(682, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormPermainanSedang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tugas_Proyek.Resource1.bgproyek;
            this.ClientSize = new System.Drawing.Size(739, 716);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_skor);
            this.Name = "FormPermainanSedang";
            this.Text = "FormPermainanSedang";
            this.Load += new System.EventHandler(this.FormPermainanSedang_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormPermainanSedang_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPermainanSedang_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_skor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}