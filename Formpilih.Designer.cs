
namespace Tugas_Proyek
{
    partial class Formpilih
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tglafter = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chktanggal = new System.Windows.Forms.CheckBox();
            this.chknama = new System.Windows.Forms.CheckBox();
            this.chkscore = new System.Windows.Forms.CheckBox();
            this.chkkesulitan = new System.Windows.Forms.CheckBox();
            this.kesulitan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tglbefore = new System.Windows.Forms.DateTimePicker();
            this.skor = new System.Windows.Forms.NumericUpDown();
            this.cmbskor = new System.Windows.Forms.ComboBox();
            this.txtnama = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnsort = new System.Windows.Forms.Button();
            this.sc = new System.Windows.Forms.ComboBox();
            this.sort = new System.Windows.Forms.ComboBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skor)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(25, 258);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 490);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tglafter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chktanggal);
            this.groupBox1.Controls.Add(this.chknama);
            this.groupBox1.Controls.Add(this.chkscore);
            this.groupBox1.Controls.Add(this.chkkesulitan);
            this.groupBox1.Controls.Add(this.kesulitan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tglbefore);
            this.groupBox1.Controls.Add(this.skor);
            this.groupBox1.Controls.Add(this.cmbskor);
            this.groupBox1.Controls.Add(this.txtnama);
            this.groupBox1.Location = new System.Drawing.Point(25, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(777, 239);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.DarkKhaki;
            this.filter.FlatAppearance.BorderSize = 0;
            this.filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filter.Location = new System.Drawing.Point(629, 188);
            this.filter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(123, 33);
            this.filter.TabIndex = 20;
            this.filter.Text = "Filter";
            this.filter.UseVisualStyleBackColor = false;
            this.filter.Click += new System.EventHandler(this.filter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(419, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "After";
            // 
            // tglafter
            // 
            this.tglafter.Enabled = false;
            this.tglafter.Location = new System.Drawing.Point(497, 90);
            this.tglafter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tglafter.Name = "tglafter";
            this.tglafter.Size = new System.Drawing.Size(255, 22);
            this.tglafter.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Before";
            // 
            // chktanggal
            // 
            this.chktanggal.AutoSize = true;
            this.chktanggal.Location = new System.Drawing.Point(405, 21);
            this.chktanggal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chktanggal.Name = "chktanggal";
            this.chktanggal.Size = new System.Drawing.Size(90, 21);
            this.chktanggal.TabIndex = 15;
            this.chktanggal.Text = "Tanggal :";
            this.chktanggal.UseVisualStyleBackColor = true;
            this.chktanggal.CheckedChanged += new System.EventHandler(this.chktanggal_CheckedChanged);
            // 
            // chknama
            // 
            this.chknama.AutoSize = true;
            this.chknama.Location = new System.Drawing.Point(15, 25);
            this.chknama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chknama.Name = "chknama";
            this.chknama.Size = new System.Drawing.Size(75, 21);
            this.chknama.TabIndex = 14;
            this.chknama.Text = "Nama :";
            this.chknama.UseVisualStyleBackColor = true;
            this.chknama.CheckedChanged += new System.EventHandler(this.chknama_CheckedChanged);
            // 
            // chkscore
            // 
            this.chkscore.AutoSize = true;
            this.chkscore.Location = new System.Drawing.Point(15, 60);
            this.chkscore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkscore.Name = "chkscore";
            this.chkscore.Size = new System.Drawing.Size(75, 21);
            this.chkscore.TabIndex = 13;
            this.chkscore.Text = "Score :";
            this.chkscore.UseVisualStyleBackColor = true;
            this.chkscore.CheckedChanged += new System.EventHandler(this.chkscore_CheckedChanged);
            // 
            // chkkesulitan
            // 
            this.chkkesulitan.AutoSize = true;
            this.chkkesulitan.Location = new System.Drawing.Point(421, 118);
            this.chkkesulitan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkkesulitan.Name = "chkkesulitan";
            this.chkkesulitan.Size = new System.Drawing.Size(96, 21);
            this.chkkesulitan.TabIndex = 12;
            this.chkkesulitan.Text = "Kesulitan :";
            this.chkkesulitan.UseVisualStyleBackColor = true;
            this.chkkesulitan.CheckedChanged += new System.EventHandler(this.chkkesulitan_CheckedChanged);
            // 
            // kesulitan
            // 
            this.kesulitan.Enabled = false;
            this.kesulitan.FormattingEnabled = true;
            this.kesulitan.Items.AddRange(new object[] {
            "Mudah",
            "Normal",
            "Sulit"});
            this.kesulitan.Location = new System.Drawing.Point(421, 145);
            this.kesulitan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kesulitan.Name = "kesulitan";
            this.kesulitan.Size = new System.Drawing.Size(329, 24);
            this.kesulitan.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 9;
            // 
            // tglbefore
            // 
            this.tglbefore.Enabled = false;
            this.tglbefore.Location = new System.Drawing.Point(497, 54);
            this.tglbefore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tglbefore.Name = "tglbefore";
            this.tglbefore.Size = new System.Drawing.Size(255, 22);
            this.tglbefore.TabIndex = 8;
            // 
            // skor
            // 
            this.skor.Enabled = false;
            this.skor.Location = new System.Drawing.Point(101, 101);
            this.skor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skor.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.skor.Name = "skor";
            this.skor.Size = new System.Drawing.Size(280, 22);
            this.skor.TabIndex = 5;
            // 
            // cmbskor
            // 
            this.cmbskor.Enabled = false;
            this.cmbskor.FormattingEnabled = true;
            this.cmbskor.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">="});
            this.cmbskor.Location = new System.Drawing.Point(20, 98);
            this.cmbskor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbskor.Name = "cmbskor";
            this.cmbskor.Size = new System.Drawing.Size(55, 24);
            this.cmbskor.TabIndex = 4;
            // 
            // txtnama
            // 
            this.txtnama.Enabled = false;
            this.txtnama.Location = new System.Drawing.Point(96, 25);
            this.txtnama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnama.Name = "txtnama";
            this.txtnama.Size = new System.Drawing.Size(287, 22);
            this.txtnama.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnsort);
            this.groupBox2.Controls.Add(this.sc);
            this.groupBox2.Controls.Add(this.sort);
            this.groupBox2.Location = new System.Drawing.Point(808, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(200, 183);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // btnsort
            // 
            this.btnsort.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnsort.FlatAppearance.BorderSize = 0;
            this.btnsort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsort.Location = new System.Drawing.Point(43, 118);
            this.btnsort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsort.Name = "btnsort";
            this.btnsort.Size = new System.Drawing.Size(123, 33);
            this.btnsort.TabIndex = 21;
            this.btnsort.Text = "Sort";
            this.btnsort.UseVisualStyleBackColor = false;
            this.btnsort.Click += new System.EventHandler(this.btnsort_Click);
            // 
            // sc
            // 
            this.sc.FormattingEnabled = true;
            this.sc.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.sc.Location = new System.Drawing.Point(16, 78);
            this.sc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sc.Name = "sc";
            this.sc.Size = new System.Drawing.Size(164, 24);
            this.sc.TabIndex = 1;
            // 
            // sort
            // 
            this.sort.FormattingEnabled = true;
            this.sort.Items.AddRange(new object[] {
            "Nama",
            "Score",
            "Tanggal",
            "Kesulitan"});
            this.sort.Location = new System.Drawing.Point(16, 21);
            this.sort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sort.Name = "sort";
            this.sort.Size = new System.Drawing.Size(164, 24);
            this.sort.TabIndex = 0;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnreset.FlatAppearance.BorderSize = 0;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Location = new System.Drawing.Point(851, 215);
            this.btnreset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(113, 31);
            this.btnreset.TabIndex = 19;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click_1);
            // 
            // Formpilih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1029, 750);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Formpilih";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formpilih";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Formpilih_FormClosed);
            this.Load += new System.EventHandler(this.Formpilih_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Formpilih_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox kesulitan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tglbefore;
        private System.Windows.Forms.NumericUpDown skor;
        private System.Windows.Forms.ComboBox cmbskor;
        private System.Windows.Forms.TextBox txtnama;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox sc;
        private System.Windows.Forms.ComboBox sort;
        private System.Windows.Forms.CheckBox chknama;
        private System.Windows.Forms.CheckBox chkscore;
        private System.Windows.Forms.CheckBox chkkesulitan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker tglafter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chktanggal;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button filter;
        private System.Windows.Forms.Button btnsort;
    }
}