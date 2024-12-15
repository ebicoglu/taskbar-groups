﻿using System.ComponentModel;
using System.Windows.Forms;

namespace client.User_controls
{
    partial class ucCategoryPanel
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.picGroupIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGroupIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(143)))), ((int)(((byte)(143)))));
            this.lblTitle.Location = new System.Drawing.Point(83, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 30);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Group Name";
            this.lblTitle.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.cmdDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.cmdDelete.FlatAppearance.BorderSize = 0;
            this.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.ForeColor = System.Drawing.Color.White;
            this.cmdDelete.Location = new System.Drawing.Point(494, 35);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(129, 30);
            this.cmdDelete.TabIndex = 20;
            this.cmdDelete.TabStop = false;
            this.cmdDelete.Text = "Edit group";
            this.cmdDelete.UseVisualStyleBackColor = false;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // picGroupIcon
            // 
            this.picGroupIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picGroupIcon.Location = new System.Drawing.Point(46, 13);
            this.picGroupIcon.Name = "picGroupIcon";
            this.picGroupIcon.Size = new System.Drawing.Size(30, 30);
            this.picGroupIcon.TabIndex = 21;
            this.picGroupIcon.TabStop = false;
            this.picGroupIcon.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.picGroupIcon.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            // 
            // ucCategoryPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.Controls.Add(this.picGroupIcon);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucCategoryPanel";
            this.Size = new System.Drawing.Size(680, 100);
            this.Load += new System.EventHandler(this.ucNewCategory_Load);
            this.Click += new System.EventHandler(this.OpenFolder);
            ((System.ComponentModel.ISupportInitialize)(this.picGroupIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblTitle;
        private Button cmdDelete;
        private PictureBox picGroupIcon;
    }
}