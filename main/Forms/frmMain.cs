using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;
using client.Classes;
using client.User_controls;

namespace client.Forms
{

    public partial class frmMain : Form
    {
        // Allow doubleBuffering drawing each frame to memory and then onto screen
        // Solves flickering issues mostly as the entire rendering of the screen is done in 1 operation after being first loaded to memory
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Category ThisCategory;
        public List<ucShortcut> ControlList;
        public Color HoverColor;

        public Point mouseClick;

        //------------------------------------------------------------------------------------
        // CTOR AND LOAD
        //
        public frmMain(string passedDirectory, int cursorPosX, int cursorPosY)
        {
            InitializeComponent();

            ProfileOptimization.StartProfile("frmMain.Profile");
            mouseClick = new Point(cursorPosX, cursorPosY);
            var passedDirec = passedDirectory;
            FormBorderStyle = FormBorderStyle.None;

            var icon = MainPath.path + "\\config\\" + passedDirec + "\\GroupIcon.ico";
            using (var ms = new MemoryStream(File.ReadAllBytes(icon)))
            {
                Icon = new Icon(ms);
            }

            if (Directory.Exists(MainPath.path + @"\config\" + passedDirec))
            {
                ControlList = new List<ucShortcut>();

                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                ThisCategory = new Category($"config\\{passedDirec}");
                BackColor = ImageFunctions.FromString(ThisCategory.ColorString);
                Opacity = (1 - (ThisCategory.Opacity / 100));

                if (BackColor.R * 0.2126 + BackColor.G * 0.7152 + BackColor.B * 0.0722 > 255 / 2)
                    //if backcolor is light, set hover color as darker
                {
                    HoverColor = Color.FromArgb(BackColor.A, (BackColor.R - 50), (BackColor.G - 50), (BackColor.B - 50));
                }
                else
                    //light backcolor is light, set hover color as darker
                {
                    HoverColor = Color.FromArgb(BackColor.A, (BackColor.R + 50), (BackColor.G + 50), (BackColor.B + 50));
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadCategory();
            SetLocation();
        }

        // Sets location of form
        private void SetLocation()
        {
            var taskbarList = FindDockedTaskBars();
            var taskbar = new Rectangle();
            var screen = new Rectangle();

            var i = 0;
            int locationy;
            int locationx;
            if (taskbarList.Count != 0)
            {
                foreach (var scr in Screen.AllScreens) // Get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                        taskbar = taskbarList[i];
                    }

                    i++;
                }

                if (taskbar.Contains(mouseClick)) // Click on taskbar
                {
                    if (taskbar.Top == screen.Top && taskbar.Width == screen.Width)
                    {
                        // TOP
                        locationy = screen.Y + taskbar.Height + 10;
                        locationx = mouseClick.X - (Width / 2);
                    }
                    else if (taskbar.Bottom == screen.Bottom && taskbar.Width == screen.Width)
                    {
                        // BOTTOM
                        locationy = screen.Y + screen.Height - Height - taskbar.Height - 10;
                        locationx = mouseClick.X - (Width / 2);
                    }
                    else if (taskbar.Left == screen.Left)
                    {
                        // LEFT
                        locationy = mouseClick.Y - (Height / 2);
                        locationx = screen.X + taskbar.Width + 10;

                    }
                    else
                    {
                        // RIGHT
                        locationy = mouseClick.Y - (Height / 2);
                        locationx = screen.X + screen.Width - Width - taskbar.Width - 10;
                    }

                }
                else // not click on taskbar
                {
                    locationy = mouseClick.Y - Height - 20;
                    locationx = mouseClick.X - (Width / 2);

                }

                Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (Left < screen.Left)
                {
                    Left = screen.Left + 10;
                }

                if (Top < screen.Top)
                {
                    Top = screen.Top + 10;
                }

                if (Right > screen.Right)
                {
                    Left = screen.Right - Width - 10;
                }

                // If form goes over taskbar
                if (taskbar.Contains(Left, Top) && taskbar.Contains(Right, Top)) // Top taskbar
                {
                    Top = screen.Top + 10 + taskbar.Height;
                }

                if (taskbar.Contains(Left, Top)) // Left taskbar
                {
                    Left = screen.Left + 10 + taskbar.Width;
                }

                if (taskbar.Contains(Right, Top))  // Right taskbar
                {
                    Left = screen.Right - Width - 10 - taskbar.Width;
                }
            }
            else // Hidded taskbar
            {
                foreach (var scr in Screen.AllScreens) // get what screen user clicked on
                {
                    if (scr.Bounds.Contains(mouseClick))
                    {
                        screen.X = scr.Bounds.X;
                        screen.Y = scr.Bounds.Y;
                        screen.Width = scr.Bounds.Width;
                        screen.Height = scr.Bounds.Height;
                    }
                    i++;
                }

                if (mouseClick.Y > Screen.PrimaryScreen.Bounds.Height - 35)
                {
                    locationy = Screen.PrimaryScreen.Bounds.Height - Height - 45;
                }
                else
                {
                    locationy = mouseClick.Y - Height - 20;
                }

                locationx = mouseClick.X - (Width / 2);

                Location = new Point(locationx, locationy);

                // If form goes over screen edge
                if (Left < screen.Left)
                {
                    Left = screen.Left + 10;
                }

                if (Top < screen.Top)
                {
                    Top = screen.Top + 10;
                }

                if (Right > screen.Right)
                {
                    Left = screen.Right - Width - 10;
                }

                // If form goes over taskbar
                if (taskbar.Contains(Left, Top) && taskbar.Contains(Right, Top)) // Top taskbar
                {
                    Top = screen.Top + 10 + taskbar.Height;
                }

                if (taskbar.Contains(Left, Top)) // Left taskbar
                {
                    Left = screen.Left + 10 + taskbar.Width;
                }

                if (taskbar.Contains(Right, Top))  // Right taskbar
                {
                    Left = screen.Right - Width - 10 - taskbar.Width;
                }
            }
        }
        // Search for active taskbars on screen
        public static List<Rectangle> FindDockedTaskBars()
        {
            var dockedRects = new List<Rectangle>();
            foreach (var tmpScrn in Screen.AllScreens)
            {
                if (!tmpScrn.Bounds.Equals(tmpScrn.WorkingArea))
                {
                    var rect = new Rectangle();

                    var leftDockedWidth = Math.Abs((Math.Abs(tmpScrn.Bounds.Left) - Math.Abs(tmpScrn.WorkingArea.Left)));
                    var topDockedHeight = Math.Abs((Math.Abs(tmpScrn.Bounds.Top) - Math.Abs(tmpScrn.WorkingArea.Top)));
                    var rightDockedWidth = ((tmpScrn.Bounds.Width - leftDockedWidth) - tmpScrn.WorkingArea.Width);
                    var bottomDockedHeight = ((tmpScrn.Bounds.Height - topDockedHeight) - tmpScrn.WorkingArea.Height);
                    if ((leftDockedWidth > 0))
                    {
                        rect.X = tmpScrn.Bounds.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = leftDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((rightDockedWidth > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Right;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = rightDockedWidth;
                        rect.Height = tmpScrn.Bounds.Height;
                    }
                    else if ((topDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.Bounds.Top;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = topDockedHeight;
                    }
                    else if ((bottomDockedHeight > 0))
                    {
                        rect.X = tmpScrn.WorkingArea.Left;
                        rect.Y = tmpScrn.WorkingArea.Bottom;
                        rect.Width = tmpScrn.WorkingArea.Width;
                        rect.Height = bottomDockedHeight;
                    }

                    // Nothing found!
                    dockedRects.Add(rect);
                }
            }

            if (dockedRects.Count == 0)
            {
                // Taskbar is set to "Auto-Hide".
            }

            return dockedRects;
        }
        //
        //------------------------------------------------------------------------------------
        //

        private void AddSettingsShortcut()
        {
            ThisCategory.ShortcutList.Add(new ProgramShortcut
            {
                name = "Settings",
                FilePath = Assembly.GetExecutingAssembly().Location,
                isWindowsApp = false,
                WorkingDirectory = Application.StartupPath,
                ShouldTerminateAfterRun = true
            });
        }

        // Loading category and building shortcuts
        private void LoadCategory()
        {
            Width = 100; //shortcut window width
            Height = 0;
            var x = 0;
            var y = 0;

            AddSettingsShortcut();

            // Check if icon caches exist for the category being loaded
            // If not then rebuild the icon cache
            if (!Directory.Exists(MainPath.path + @"\config\" + ThisCategory.Name + @"\Icons\"))
            {
                ThisCategory.cacheIcons();
            }

            foreach (var psc in ThisCategory.ShortcutList)
            {
                // Building shortcut controls
                var pscPanel = new ucShortcut
                {
                    Psc = psc,
                    MotherForm = this,
                    ThisCategory = ThisCategory,
                    Location = new Point(x, y)
                };

                var rowSize = TextRenderer.MeasureText(psc.name, pscPanel.Font);

                var verticalPadding = 25;
                y += rowSize.Height + verticalPadding;
                Height += rowSize.Height + verticalPadding;

                var horizontalPadding = 50;
                var rowWidth = rowSize.Width + pscPanel.picIcon.Width + horizontalPadding;
                if (rowWidth > Width)
                {
                    Width = Convert.ToInt32(rowWidth);
                }

                pscPanel.Width = Width + horizontalPadding;
                Controls.Add(pscPanel);
                ControlList.Add(pscPanel);
                pscPanel.Show();
                pscPanel.BringToFront();
            }

        }

        // Click handler for shortcuts
        public void OpenFile(string arguments, string path, string workingDirectory, bool shouldTerminateAfterRun = false)
        {
            // starting program from psc panel click
            var proc = new ProcessStartInfo
            {
                FileName = path
            };

            if (!string.IsNullOrWhiteSpace(arguments))
            {
                proc.Arguments = arguments;
            }

            if (!string.IsNullOrWhiteSpace(workingDirectory))
            {
                proc.WorkingDirectory = workingDirectory;
            }

            try
            {
                Process.Start(proc);

                if (shouldTerminateAfterRun)
                {
                    Thread.Sleep(1);
                    Environment.Exit(0);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // Closes application upon deactivation
        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            // closes program if user clicks outside form
            Close();
        }

    }
}
