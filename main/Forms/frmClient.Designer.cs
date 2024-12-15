using System.ComponentModel;
using System.Windows.Forms;

namespace client.Forms
{
    partial class frmClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.pnlLeftColumn = new System.Windows.Forms.Panel();
            this.pnlVersionInfo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.currentVersion = new System.Windows.Forms.Label();
            this.githubVersion = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.LinkLabel();
            this.githubLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHelp1 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.pnlAddGroup = new System.Windows.Forms.Panel();
            this.lblAddGroup = new System.Windows.Forms.Label();
            this.cmdAddGroup = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlExistingGroups = new System.Windows.Forms.Panel();
            this.pnlBottomMain = new System.Windows.Forms.Panel();
            this.pnlLeftColumn.SuspendLayout();
            this.pnlVersionInfo.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBottomMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftColumn
            // 
            this.pnlLeftColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pnlLeftColumn.Controls.Add(this.pnlVersionInfo);
            this.pnlLeftColumn.Controls.Add(this.pnlHelp);
            this.pnlLeftColumn.Controls.Add(this.lblHelpTitle);
            this.pnlLeftColumn.ImeMode = System.Windows.Forms.ImeMode.On;
            this.pnlLeftColumn.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftColumn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLeftColumn.Name = "pnlLeftColumn";
            this.pnlLeftColumn.Size = new System.Drawing.Size(480, 1262);
            this.pnlLeftColumn.TabIndex = 0;
            // 
            // pnlVersionInfo
            // 
            this.pnlVersionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlVersionInfo.Controls.Add(this.label6);
            this.pnlVersionInfo.Controls.Add(this.currentVersion);
            this.pnlVersionInfo.Controls.Add(this.githubVersion);
            this.pnlVersionInfo.Controls.Add(this.githubLink);
            this.pnlVersionInfo.Controls.Add(this.githubLabel);
            this.pnlVersionInfo.Controls.Add(this.label4);
            this.pnlVersionInfo.Controls.Add(this.label5);
            this.pnlVersionInfo.Location = new System.Drawing.Point(18, 946);
            this.pnlVersionInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlVersionInfo.Name = "pnlVersionInfo";
            this.pnlVersionInfo.Size = new System.Drawing.Size(438, 274);
            this.pnlVersionInfo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(99, 155);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 28);
            this.label6.TabIndex = 19;
            this.label6.Text = "Current Version:";
            // 
            // currentVersion
            // 
            this.currentVersion.AutoSize = true;
            this.currentVersion.BackColor = System.Drawing.Color.Transparent;
            this.currentVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.currentVersion.ForeColor = System.Drawing.Color.Transparent;
            this.currentVersion.Location = new System.Drawing.Point(260, 155);
            this.currentVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentVersion.Name = "currentVersion";
            this.currentVersion.Size = new System.Drawing.Size(23, 28);
            this.currentVersion.TabIndex = 15;
            this.currentVersion.Text = "0";
            // 
            // githubVersion
            // 
            this.githubVersion.AutoSize = true;
            this.githubVersion.BackColor = System.Drawing.Color.Transparent;
            this.githubVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubVersion.ForeColor = System.Drawing.Color.Transparent;
            this.githubVersion.Location = new System.Drawing.Point(260, 200);
            this.githubVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githubVersion.Name = "githubVersion";
            this.githubVersion.Size = new System.Drawing.Size(23, 28);
            this.githubVersion.TabIndex = 14;
            this.githubVersion.Text = "0";
            // 
            // githubLink
            // 
            this.githubLink.AutoSize = true;
            this.githubLink.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.githubLink.LinkColor = System.Drawing.Color.White;
            this.githubLink.Location = new System.Drawing.Point(327, 52);
            this.githubLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(50, 28);
            this.githubLink.TabIndex = 18;
            this.githubLink.TabStop = true;
            this.githubLink.Text = "here";
            this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLink_LinkClicked);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.BackColor = System.Drawing.Color.Transparent;
            this.githubLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.githubLabel.ForeColor = System.Drawing.Color.Transparent;
            this.githubLabel.Location = new System.Drawing.Point(112, 200);
            this.githubLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(136, 28);
            this.githubLabel.TabIndex = 13;
            this.githubLabel.Text = "Latest Version:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(33, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(364, 42);
            this.label4.TabIndex = 17;
            this.label4.Text = "Have issues/bugs?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(33, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 37);
            this.label5.TabIndex = 14;
            this.label5.Text = "Please report them to the Github";
            // 
            // pnlHelp
            // 
            this.pnlHelp.Controls.Add(this.label3);
            this.pnlHelp.Controls.Add(this.lblHelp1);
            this.pnlHelp.Controls.Add(this.lblHelp3);
            this.pnlHelp.Controls.Add(this.lblHelp2);
            this.pnlHelp.Location = new System.Drawing.Point(18, 194);
            this.pnlHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(438, 311);
            this.pnlHelp.TabIndex = 17;
            this.pnlHelp.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(39, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 40);
            this.label3.TabIndex = 17;
            this.label3.Text = "When the folder opens:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHelp1
            // 
            this.lblHelp1.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp1.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp1.Location = new System.Drawing.Point(39, 91);
            this.lblHelp1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp1.Name = "lblHelp1";
            this.lblHelp1.Size = new System.Drawing.Size(364, 62);
            this.lblHelp1.TabIndex = 14;
            this.lblHelp1.Text = "1. Right click on the shortcut named as your new group";
            // 
            // lblHelp3
            // 
            this.lblHelp3.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp3.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp3.Location = new System.Drawing.Point(39, 238);
            this.lblHelp3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(364, 34);
            this.lblHelp3.TabIndex = 16;
            this.lblHelp3.Text = "3. Enjoy your new Taskbar group";
            // 
            // lblHelp2
            // 
            this.lblHelp2.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblHelp2.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelp2.Location = new System.Drawing.Point(39, 177);
            this.lblHelp2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(364, 34);
            this.lblHelp2.TabIndex = 15;
            this.lblHelp2.Text = "2. Click on \"Pin to taskbar\"";
            // 
            // lblHelpTitle
            // 
            this.lblHelpTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHelpTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lblHelpTitle.Location = new System.Drawing.Point(62, 68);
            this.lblHelpTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelpTitle.Name = "lblHelpTitle";
            this.lblHelpTitle.Size = new System.Drawing.Size(360, 86);
            this.lblHelpTitle.TabIndex = 13;
            this.lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
            this.lblHelpTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAddGroup
            // 
            this.pnlAddGroup.Controls.Add(this.lblAddGroup);
            this.pnlAddGroup.Controls.Add(this.cmdAddGroup);
            this.pnlAddGroup.Location = new System.Drawing.Point(246, 6);
            this.pnlAddGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAddGroup.Name = "pnlAddGroup";
            this.pnlAddGroup.Size = new System.Drawing.Size(510, 108);
            this.pnlAddGroup.TabIndex = 1;
            this.pnlAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.pnlAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.pnlAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // lblAddGroup
            // 
            this.lblAddGroup.AutoSize = true;
            this.lblAddGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblAddGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.lblAddGroup.Location = new System.Drawing.Point(210, 37);
            this.lblAddGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddGroup.Name = "lblAddGroup";
            this.lblAddGroup.Size = new System.Drawing.Size(177, 28);
            this.lblAddGroup.TabIndex = 8;
            this.lblAddGroup.Text = "Add taskbar group";
            this.lblAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.lblAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.lblAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // cmdAddGroup
            // 
            this.cmdAddGroup.BackgroundImage = global::client.Properties.Resources.AddGray;
            this.cmdAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdAddGroup.Location = new System.Drawing.Point(132, 22);
            this.cmdAddGroup.Margin = new System.Windows.Forms.Padding(45, 46, 15, 46);
            this.cmdAddGroup.Name = "cmdAddGroup";
            this.cmdAddGroup.Size = new System.Drawing.Size(60, 62);
            this.cmdAddGroup.TabIndex = 7;
            this.cmdAddGroup.TabStop = false;
            this.cmdAddGroup.Click += new System.EventHandler(this.cmdAddGroup_Click);
            this.cmdAddGroup.MouseEnter += new System.EventHandler(this.pnlAddGroup_MouseEnter);
            this.cmdAddGroup.MouseLeave += new System.EventHandler(this.pnlAddGroup_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(46, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 60);
            this.label1.TabIndex = 11;
            this.label1.Text = "Taskbar Groups";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(480, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 205);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.label2.Location = new System.Drawing.Point(54, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(777, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Group your favourite programs and pin them to the taskbar for easy access";
            // 
            // pnlExistingGroups
            // 
            this.pnlExistingGroups.Location = new System.Drawing.Point(480, 205);
            this.pnlExistingGroups.Margin = new System.Windows.Forms.Padding(0);
            this.pnlExistingGroups.Name = "pnlExistingGroups";
            this.pnlExistingGroups.Size = new System.Drawing.Size(1020, 0);
            this.pnlExistingGroups.TabIndex = 3;
            // 
            // pnlBottomMain
            // 
            this.pnlBottomMain.Controls.Add(this.pnlAddGroup);
            this.pnlBottomMain.Location = new System.Drawing.Point(489, 249);
            this.pnlBottomMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBottomMain.Name = "pnlBottomMain";
            this.pnlBottomMain.Size = new System.Drawing.Size(993, 155);
            this.pnlBottomMain.TabIndex = 4;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(1500, 1263);
            this.Controls.Add(this.pnlBottomMain);
            this.Controls.Add(this.pnlExistingGroups);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeftColumn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taskbar Groups";
            this.Resize += new System.EventHandler(this.frmClient_Resize);
            this.pnlLeftColumn.ResumeLayout(false);
            this.pnlVersionInfo.ResumeLayout(false);
            this.pnlVersionInfo.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            this.pnlAddGroup.ResumeLayout(false);
            this.pnlAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAddGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBottomMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlLeftColumn;
        private Panel pnlAddGroup;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label lblAddGroup;
        private PictureBox cmdAddGroup;
        private Panel pnlExistingGroups;
        private Label lblHelpTitle;
        private Panel pnlHelp;
        private Label lblHelp1;
        private Label lblHelp3;
        private Label lblHelp2;
        private Label label3;
        private Label currentVersion;
        private Label githubVersion;
        private Label githubLabel;
        private Panel pnlVersionInfo;
        private Label label4;
        private Label label5;
        private LinkLabel githubLink;
        private Label label6;
        private Panel pnlBottomMain;
    }
}