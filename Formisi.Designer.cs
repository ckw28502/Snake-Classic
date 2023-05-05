
namespace Tugas_Proyek
{
    partial class Formisi
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnmulaigame = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbmudah = new System.Windows.Forms.RadioButton();
            this.rdbsedang = new System.Windows.Forms.RadioButton();
            this.rdbsulit = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(205, 127);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 25);
            this.textBox1.TabIndex = 2;
            // 
            // btnmulaigame
            // 
            this.btnmulaigame.BackColor = System.Drawing.Color.LightGray;
            this.btnmulaigame.FlatAppearance.BorderSize = 0;
            this.btnmulaigame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmulaigame.Location = new System.Drawing.Point(489, 268);
            this.btnmulaigame.Name = "btnmulaigame";
            this.btnmulaigame.Size = new System.Drawing.Size(98, 47);
            this.btnmulaigame.TabIndex = 3;
            this.btnmulaigame.Text = "Mulai Game";
            this.btnmulaigame.UseVisualStyleBackColor = false;
            this.btnmulaigame.Click += new System.EventHandler(this.btnmulaigame_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Difficulty :";
            // 
            // rdbmudah
            // 
            this.rdbmudah.AutoSize = true;
            this.rdbmudah.BackColor = System.Drawing.Color.Transparent;
            this.rdbmudah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbmudah.Location = new System.Drawing.Point(231, 205);
            this.rdbmudah.Name = "rdbmudah";
            this.rdbmudah.Size = new System.Drawing.Size(57, 17);
            this.rdbmudah.TabIndex = 8;
            this.rdbmudah.TabStop = true;
            this.rdbmudah.Text = "Mudah";
            this.rdbmudah.UseVisualStyleBackColor = false;
            // 
            // rdbsedang
            // 
            this.rdbsedang.AutoSize = true;
            this.rdbsedang.BackColor = System.Drawing.Color.Transparent;
            this.rdbsedang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbsedang.Location = new System.Drawing.Point(294, 205);
            this.rdbsedang.Name = "rdbsedang";
            this.rdbsedang.Size = new System.Drawing.Size(57, 17);
            this.rdbsedang.TabIndex = 9;
            this.rdbsedang.TabStop = true;
            this.rdbsedang.Text = "Normal";
            this.rdbsedang.UseVisualStyleBackColor = false;
            // 
            // rdbsulit
            // 
            this.rdbsulit.AutoSize = true;
            this.rdbsulit.BackColor = System.Drawing.Color.Transparent;
            this.rdbsulit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbsulit.Location = new System.Drawing.Point(361, 206);
            this.rdbsulit.Name = "rdbsulit";
            this.rdbsulit.Size = new System.Drawing.Size(44, 17);
            this.rdbsulit.TabIndex = 10;
            this.rdbsulit.TabStop = true;
            this.rdbsulit.Text = "Sulit";
            this.rdbsulit.UseVisualStyleBackColor = false;
            // 
            // Formisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tugas_Proyek.Resource1.formisi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(599, 327);
            this.Controls.Add(this.rdbsulit);
            this.Controls.Add(this.rdbsedang);
            this.Controls.Add(this.rdbmudah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnmulaigame);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Formisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formisi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Formisi_FormClosed);
            this.Load += new System.EventHandler(this.Formisi_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Formisi_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnmulaigame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbmudah;
        private System.Windows.Forms.RadioButton rdbsedang;
        private System.Windows.Forms.RadioButton rdbsulit;
    }
}