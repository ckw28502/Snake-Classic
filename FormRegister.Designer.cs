
namespace Tugas_Proyek
{
    partial class FormRegister
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
            this.btnregis = new System.Windows.Forms.Button();
            this.txtboxpass = new System.Windows.Forms.TextBox();
            this.txtboxuser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnregis
            // 
            this.btnregis.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnregis.Location = new System.Drawing.Point(215, 347);
            this.btnregis.Name = "btnregis";
            this.btnregis.Size = new System.Drawing.Size(216, 33);
            this.btnregis.TabIndex = 21;
            this.btnregis.Text = "Register";
            this.btnregis.UseVisualStyleBackColor = false;
            this.btnregis.Click += new System.EventHandler(this.btnregis_Click);
            // 
            // txtboxpass
            // 
            this.txtboxpass.Location = new System.Drawing.Point(215, 313);
            this.txtboxpass.Multiline = true;
            this.txtboxpass.Name = "txtboxpass";
            this.txtboxpass.Size = new System.Drawing.Size(216, 28);
            this.txtboxpass.TabIndex = 16;
            // 
            // txtboxuser
            // 
            this.txtboxuser.Location = new System.Drawing.Point(215, 252);
            this.txtboxuser.Multiline = true;
            this.txtboxuser.Name = "txtboxuser";
            this.txtboxuser.Size = new System.Drawing.Size(216, 29);
            this.txtboxuser.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username :";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(626, 469);
            this.Controls.Add(this.btnregis);
            this.Controls.Add(this.txtboxpass);
            this.Controls.Add(this.txtboxuser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnregis;
        private System.Windows.Forms.TextBox txtboxpass;
        private System.Windows.Forms.TextBox txtboxuser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}