using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using client.Classes;
using client.Forms;
using client.Properties;

namespace client.User_controls
{
    public partial class ucCategoryPanel : UserControl
    {
        public Category Category;
        public frmClient Client;
        public ucCategoryPanel(frmClient client, Category category)
        {
            InitializeComponent();
            Client = client;
            Category = category;
            lblTitle.Text = Regex.Replace(category.Name, @"(_)+", " ");
            picGroupIcon.BackgroundImage = Category.LoadIconImage();

            // starting values for position of shortcuts
            var x = 90;
            var y = 55;
            var columns = 1;

            if (!Directory.Exists((@"config\" + category.Name) + "\\Icons\\"))
            {
                category.cacheIcons();
            }

            foreach (var psc in Category.ShortcutList) // since this is calculating uc height it cant be placed in load
            {
                if (columns == 8)
                {
                    x = 90; // resetting x
                    y += 40; // adding new row
                    Height += 40;
                    columns = 1;
                }
                CreateShortcut(x, y, psc);
                x += 50;
                columns++;
            }
        }

        private void CreateShortcut(int x, int y, ProgramShortcut programShortcut)
        {
            // creating shortcut picturebox from shortcut
            shortcutPanel = new PictureBox
            {
                BackColor = Color.Transparent,
                Location = new Point(x, y),
                Size = new Size(30, 30),
                BackgroundImageLayout = ImageLayout.Stretch,
                TabStop = false
            };
            shortcutPanel.MouseEnter += (sender, e) => Client.EnterControl(sender, e, this);
            shortcutPanel.MouseLeave += (sender, e) => Client.LeaveControl(sender, e, this);
            shortcutPanel.Click += (sender, e) => OpenFolder(sender, e);

            // Check if file is stil existing and if so render it
            if (File.Exists(programShortcut.FilePath) || Directory.Exists(programShortcut.FilePath) || programShortcut.isWindowsApp)
            {
                shortcutPanel.BackgroundImage = Category.loadImageCache(programShortcut);
            }
            else // if file does not exist
            {
                shortcutPanel.BackgroundImage = Resources.Error;
                var tt = new ToolTip
                {
                    InitialDelay = 0,
                    ShowAlways = true
                };
                tt.SetToolTip(shortcutPanel, "Program does not exist");
            }

            Controls.Add(shortcutPanel);
            shortcutPanel.Show();
            shortcutPanel.BringToFront();
        }

        private void ucNewCategory_Load(object sender, EventArgs e)
        {
            cmdDelete.Top = (Height / 2) - (cmdDelete.Height / 2);

        }

        public void OpenFolder(object sender, EventArgs e)
        {
            // Open the shortcut folder for the group when click on category panel

            // Build path based on the directory of the main .exe file
            var filePath = Path.GetFullPath(new Uri($"{MainPath.path}\\Shortcuts").LocalPath + "\\" + Category.Name + ".lnk");

            // Open directory in explorer and highlighting file
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var editGroup = new frmGroup(Client, Category);
            editGroup.Show();
            editGroup.BringToFront();
        }

        public static Bitmap LoadBitmap(string path) // needed to access img without occupying read/write
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                reader.Close();
                stream.Close();
                return new Bitmap(memoryStream);
            }
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            Client.EnterControl(sender, e, this);

        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            Client.LeaveControl(sender, e, this);
        }

        //
        // endregion
        //
        public PictureBox shortcutPanel;

    }
}
