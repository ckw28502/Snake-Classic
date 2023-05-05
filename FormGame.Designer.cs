
namespace Tugas_Proyek
{
    partial class FormGame
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
            this.btnexit = new System.Windows.Forms.Button();
            this.btnboard = new System.Windows.Forms.Button();
            this.btnstart = new System.Windows.Forms.Button();
            this.btnreplay = new System.Windows.Forms.Button();
            this.btnsetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Location = new System.Drawing.Point(12, 648);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(98, 45);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnboard
            // 
            this.btnboard.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnboard.FlatAppearance.BorderSize = 0;
            this.btnboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnboard.Location = new System.Drawing.Point(133, 648);
            this.btnboard.Name = "btnboard";
            this.btnboard.Size = new System.Drawing.Size(98, 45);
            this.btnboard.TabIndex = 1;
            this.btnboard.Text = "Leader Board";
            this.btnboard.UseVisualStyleBackColor = false;
            this.btnboard.Click += new System.EventHandler(this.btnboard_Click);
            // 
            // btnstart
            // 
            this.btnstart.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnstart.FlatAppearance.BorderSize = 0;
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstart.Location = new System.Drawing.Point(474, 648);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(103, 45);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "Start";
            this.btnstart.UseVisualStyleBackColor = false;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // btnreplay
            // 
            this.btnreplay.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnreplay.FlatAppearance.BorderSize = 0;
            this.btnreplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreplay.Location = new System.Drawing.Point(353, 648);
            this.btnreplay.Name = "btnreplay";
            this.btnreplay.Size = new System.Drawing.Size(98, 45);
            this.btnreplay.TabIndex = 3;
            this.btnreplay.Text = "Replay";
            this.btnreplay.UseVisualStyleBackColor = false;
            this.btnreplay.Click += new System.EventHandler(this.btnreplay_Click);
            // 
            // btnsetting
            // 
            this.btnsetting.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnsetting.FlatAppearance.BorderSize = 0;
            this.btnsetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsetting.Location = new System.Drawing.Point(253, 648);
            this.btnsetting.Name = "btnsetting";
            this.btnsetting.Size = new System.Drawing.Size(79, 45);
            this.btnsetting.TabIndex = 4;
            this.btnsetting.Text = "Setting";
            this.btnsetting.UseVisualStyleBackColor = false;
            this.btnsetting.Click += new System.EventHandler(this.btnsetting_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tugas_Proyek.Resource1.SnakeClassic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(589, 702);
            this.Controls.Add(this.btnsetting);
            this.Controls.Add(this.btnreplay);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.btnboard);
            this.Controls.Add(this.btnexit);
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormGame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGame_FormClosed);
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGame_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnboard;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Button btnreplay;
        private System.Windows.Forms.Button btnsetting;
    }
}