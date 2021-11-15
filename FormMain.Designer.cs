
namespace Coffeed
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.serverBox = new System.Windows.Forms.ListBox();
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeCredsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.botPanel = new System.Windows.Forms.Panel();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnTrash = new System.Windows.Forms.Button();
            this.txtGroup = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listMenu.SuspendLayout();
            this.botPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // serverBox
            // 
            this.serverBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.serverBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverBox.ContextMenuStrip = this.listMenu;
            this.serverBox.Font = new System.Drawing.Font("Fira Code Retina", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.serverBox.FormattingEnabled = true;
            this.serverBox.ItemHeight = 20;
            this.serverBox.Location = new System.Drawing.Point(3, 32);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(511, 300);
            this.serverBox.TabIndex = 0;
            this.serverBox.SelectedIndexChanged += new System.EventHandler(this.serverBox_SelectedIndexChanged);
            this.serverBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeCredsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.listMenu.Name = "contextMenuStrip1";
            this.listMenu.Size = new System.Drawing.Size(151, 48);
            // 
            // removeCredsToolStripMenuItem
            // 
            this.removeCredsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.removeCredsToolStripMenuItem.Name = "removeCredsToolStripMenuItem";
            this.removeCredsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.removeCredsToolStripMenuItem.Text = "&Remove Creds";
            this.removeCredsToolStripMenuItem.Click += new System.EventHandler(this.removeCredsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem2.Text = "&";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Coffeed";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Font = new System.Drawing.Font("Fira Code Retina", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trayMenu.Name = "contextMenuStrip2";
            this.trayMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox5
            // 
            this.textBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Fira Code Retina", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Silver;
            this.textBox5.Location = new System.Drawing.Point(33, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(479, 27);
            this.textBox5.TabIndex = 7;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyDown);
            // 
            // botPanel
            // 
            this.botPanel.Controls.Add(this.btnModify);
            this.botPanel.Controls.Add(this.btnTrash);
            this.botPanel.Controls.Add(this.txtGroup);
            this.botPanel.Controls.Add(this.txtUsername);
            this.botPanel.Controls.Add(this.txtIP);
            this.botPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.botPanel.Location = new System.Drawing.Point(0, 339);
            this.botPanel.Name = "botPanel";
            this.botPanel.Size = new System.Drawing.Size(556, 69);
            this.botPanel.TabIndex = 8;
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnModify.BackgroundImage = global::Coffeed.Properties.Resources._185042_edit_modify_icon;
            this.btnModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModify.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnModify.FlatAppearance.BorderSize = 3;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.btnModify.Location = new System.Drawing.Point(484, 34);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(36, 35);
            this.btnModify.TabIndex = 15;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnTrash
            // 
            this.btnTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrash.BackColor = System.Drawing.Color.Tomato;
            this.btnTrash.BackgroundImage = global::Coffeed.Properties.Resources._2849797_trash_basket_multimedia_icon;
            this.btnTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrash.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnTrash.FlatAppearance.BorderSize = 3;
            this.btnTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrash.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.btnTrash.Location = new System.Drawing.Point(520, 34);
            this.btnTrash.Name = "btnTrash";
            this.btnTrash.Size = new System.Drawing.Size(36, 35);
            this.btnTrash.TabIndex = 14;
            this.btnTrash.UseVisualStyleBackColor = false;
            this.btnTrash.Visible = false;
            this.btnTrash.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtGroup
            // 
            this.txtGroup.AutoSize = true;
            this.txtGroup.Font = new System.Drawing.Font("Fira Code Retina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGroup.ForeColor = System.Drawing.Color.Silver;
            this.txtGroup.Location = new System.Drawing.Point(3, 52);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(63, 15);
            this.txtGroup.TabIndex = 13;
            this.txtGroup.Text = "Group: ";
            this.txtGroup.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSize = true;
            this.txtUsername.Font = new System.Drawing.Font("Fira Code Retina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Silver;
            this.txtUsername.Location = new System.Drawing.Point(3, 27);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(87, 15);
            this.txtUsername.TabIndex = 12;
            this.txtUsername.Text = "Username: ";
            this.txtUsername.Visible = false;
            // 
            // txtIP
            // 
            this.txtIP.AutoSize = true;
            this.txtIP.Font = new System.Drawing.Font("Fira Code Retina", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.ForeColor = System.Drawing.Color.Silver;
            this.txtIP.Location = new System.Drawing.Point(3, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(103, 15);
            this.txtIP.TabIndex = 11;
            this.txtIP.Text = "IP Address: ";
            this.txtIP.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.button4);
            this.topPanel.Controls.Add(this.button3);
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.textBox5);
            this.topPanel.Controls.Add(this.serverBox);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(556, 339);
            this.topPanel.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.SaddleBrown;
            this.button4.BackgroundImage = global::Coffeed.Properties.Resources._48746_coffee_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.button4.FlatAppearance.BorderSize = 3;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.button4.Location = new System.Drawing.Point(520, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 35);
            this.button4.TabIndex = 10;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Yellow;
            this.button3.BackgroundImage = global::Coffeed.Properties.Resources._8207898_about_info_information_help_ui_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button3.FlatAppearance.BorderSize = 3;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.button3.Location = new System.Drawing.Point(520, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 35);
            this.button3.TabIndex = 9;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Coffeed.Properties.Resources._2931190_fit_search_zoom_glass_view_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.BackgroundImage = global::Coffeed.Properties.Resources._134224_add_plus_new_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.button1.Location = new System.Drawing.Point(520, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 35);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Purple;
            this.button2.BackgroundImage = global::Coffeed.Properties.Resources._3325032_settings_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Fira Code Retina", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.button2.Location = new System.Drawing.Point(520, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 35);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(556, 408);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.botPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.listMenu.ResumeLayout(false);
            this.botPanel.ResumeLayout(false);
            this.botPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem removeCredsToolStripMenuItem;
        public System.Windows.Forms.ListBox serverBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Panel botPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnTrash;
        private System.Windows.Forms.Label txtGroup;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Label txtIP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button button4;
    }
}

