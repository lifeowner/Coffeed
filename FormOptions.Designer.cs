
namespace Coffeed
{
    partial class FormOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
            this.button1 = new System.Windows.Forms.Button();
            this.puttypath = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInstallPutty = new System.Windows.Forms.Button();
            this.btnInstallFileZilla = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(339, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Save Changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // puttypath
            // 
            this.puttypath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.puttypath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.puttypath.ForeColor = System.Drawing.Color.Silver;
            this.puttypath.Location = new System.Drawing.Point(12, 70);
            this.puttypath.Name = "puttypath";
            this.puttypath.Size = new System.Drawing.Size(389, 20);
            this.puttypath.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Fira Code Retina", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Silver;
            this.checkBox1.Location = new System.Drawing.Point(12, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(189, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Start with windows";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(12, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Custom Putty Path";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(407, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 20);
            this.button2.TabIndex = 11;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Install Putty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Install FileZilla";
            // 
            // btnInstallPutty
            // 
            this.btnInstallPutty.BackColor = System.Drawing.Color.LimeGreen;
            this.btnInstallPutty.FlatAppearance.BorderSize = 0;
            this.btnInstallPutty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallPutty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallPutty.ForeColor = System.Drawing.Color.Black;
            this.btnInstallPutty.Location = new System.Drawing.Point(199, 93);
            this.btnInstallPutty.Name = "btnInstallPutty";
            this.btnInstallPutty.Size = new System.Drawing.Size(98, 24);
            this.btnInstallPutty.TabIndex = 14;
            this.btnInstallPutty.Text = "&Install";
            this.btnInstallPutty.UseVisualStyleBackColor = false;
            this.btnInstallPutty.Click += new System.EventHandler(this.btnInstallPutty_Click);
            // 
            // btnInstallFileZilla
            // 
            this.btnInstallFileZilla.BackColor = System.Drawing.Color.LimeGreen;
            this.btnInstallFileZilla.FlatAppearance.BorderSize = 0;
            this.btnInstallFileZilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallFileZilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallFileZilla.ForeColor = System.Drawing.Color.Black;
            this.btnInstallFileZilla.Location = new System.Drawing.Point(199, 121);
            this.btnInstallFileZilla.Name = "btnInstallFileZilla";
            this.btnInstallFileZilla.Size = new System.Drawing.Size(98, 24);
            this.btnInstallFileZilla.TabIndex = 15;
            this.btnInstallFileZilla.Text = "&Install";
            this.btnInstallFileZilla.UseVisualStyleBackColor = false;
            this.btnInstallFileZilla.Click += new System.EventHandler(this.btnInstallFileZilla_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(441, 157);
            this.Controls.Add(this.btnInstallFileZilla);
            this.Controls.Add(this.btnInstallPutty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.puttypath);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox puttypath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInstallFileZilla;
        private System.Windows.Forms.Button btnInstallPutty;
    }
}