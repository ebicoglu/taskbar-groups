using System.ComponentModel;
using System.Windows.Forms;

namespace client.User_controls
{
    partial class ucShortcut
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBar = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblBar);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.picIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 69);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.ucShortcut_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            // 
            // lblBar
            // 
            this.lblBar.BackColor = System.Drawing.Color.Gray;
            this.lblBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBar.Location = new System.Drawing.Point(0, 67);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(321, 2);
            this.lblBar.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Location = new System.Drawing.Point(65, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label1";
            this.lblName.Click += new System.EventHandler(this.ucShortcut_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.Location = new System.Drawing.Point(24, 13);
            this.picIcon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(34, 35);
            this.picIcon.TabIndex = 3;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.ucShortcut_Click);
            this.picIcon.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.picIcon.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            // 
            // ucShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucShortcut";
            this.Size = new System.Drawing.Size(321, 69);
            this.Load += new System.EventHandler(this.ucShortcut_Load);
            this.Click += new System.EventHandler(this.ucShortcut_Click);
            this.MouseEnter += new System.EventHandler(this.ucShortcut_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucShortcut_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Panel panel1;
        public Label lblBar;
        public Label lblName;
        public PictureBox picIcon;
    }
}
