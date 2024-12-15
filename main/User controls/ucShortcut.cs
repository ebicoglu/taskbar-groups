using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using client.Classes;
using client.Forms;

namespace client.User_controls
{
    public partial class ucShortcut : UserControl
    {
        public ProgramShortcut Psc { get; set; }
        public frmMain MotherForm { get; set; }
        public Category ThisCategory { get; set; }
        public Font Font { get; }

        public ucShortcut()
        {
            InitializeComponent();
            Font = new Font("Segoe UI", 10F);
            lblName.Font = Font;
        }

        private void ucShortcut_Load(object sender, EventArgs e)
        {
            lblName.Text = Psc.name;
            Show();
            BringToFront();
            BackColor = MotherForm.BackColor;
            picIcon.BackgroundImage = ThisCategory.loadImageCache(Psc); // Use the local icon cache for the file specified as the icon image
        }

        public void ucShortcut_Click(object sender, EventArgs e)
        {
            if (Psc.isWindowsApp)
            {
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = $@"shell:appsFolder\{Psc.FilePath}"
                    }
                };

                p.Start();
            }
            else
            {
                if (Path.GetExtension(Psc.FilePath).ToLower() == ".lnk" &&
                   Psc.FilePath == MainPath.exeString)
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, MainPath.path);
                }
                else
                {
                    MotherForm.OpenFile(Psc.Arguments, Psc.FilePath, Psc.WorkingDirectory);
                }
            }
        }

        public void ucShortcut_MouseEnter(object sender, EventArgs e)
        {
            BackColor = MotherForm.HoverColor;
            Cursor = Cursors.Hand;
        }

        public void ucShortcut_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
            Cursor = Cursors.Default;
        }
    }
}
