
namespace Coffeed
{
    partial class frmSoftwareDetector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoftwareDetector));
            this.btnInstallFileZilla = new System.Windows.Forms.Button();
            this.btnInstallPutty = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInstallFileZilla
            // 
            this.btnInstallFileZilla.BackColor = System.Drawing.Color.LimeGreen;
            this.btnInstallFileZilla.FlatAppearance.BorderSize = 0;
            this.btnInstallFileZilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallFileZilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallFileZilla.ForeColor = System.Drawing.Color.Black;
            this.btnInstallFileZilla.Location = new System.Drawing.Point(263, 84);
            this.btnInstallFileZilla.Name = "btnInstallFileZilla";
            this.btnInstallFileZilla.Size = new System.Drawing.Size(98, 24);
            this.btnInstallFileZilla.TabIndex = 19;
            this.btnInstallFileZilla.Text = "&Install";
            this.btnInstallFileZilla.UseVisualStyleBackColor = false;
            this.btnInstallFileZilla.Click += new System.EventHandler(this.btnInstallFileZilla_Click);
            // 
            // btnInstallPutty
            // 
            this.btnInstallPutty.BackColor = System.Drawing.Color.LimeGreen;
            this.btnInstallPutty.FlatAppearance.BorderSize = 0;
            this.btnInstallPutty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallPutty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallPutty.ForeColor = System.Drawing.Color.Black;
            this.btnInstallPutty.Location = new System.Drawing.Point(263, 54);
            this.btnInstallPutty.Name = "btnInstallPutty";
            this.btnInstallPutty.Size = new System.Drawing.Size(98, 24);
            this.btnInstallPutty.TabIndex = 18;
            this.btnInstallPutty.Text = "&Install";
            this.btnInstallPutty.UseVisualStyleBackColor = false;
            this.btnInstallPutty.Click += new System.EventHandler(this.btnInstallPutty_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(4, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Install FileZilla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(4, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Install Putty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(351, 39);
            this.label3.TabIndex = 20;
            this.label3.Text = "*Attetion: You are missing some software,\r\nin order our software to work with the" +
    "\r\napis you must install the missing software.";
            // 
            // frmSoftwareDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(362, 109);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInstallFileZilla);
            this.Controls.Add(this.btnInstallPutty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSoftwareDetector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Installer";
            this.Load += new System.EventHandler(this.frmSoftwareDetector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstallFileZilla;
        private System.Windows.Forms.Button btnInstallPutty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}