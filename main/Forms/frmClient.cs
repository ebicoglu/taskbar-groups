using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Json;
using client.Classes;
using client.User_controls;

namespace client.Forms
{
    public partial class frmClient : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public frmClient()
        {
            ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();
            MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Reload();

            currentVersion.Text = "v" + Assembly.GetEntryAssembly().GetName().Version;

            githubVersion.Text = Task.Run(() => getVersionData()).Result;
        }
        public void Reload()
        {
            // flush and reload existing groups
            pnlExistingGroups.Controls.Clear();
            pnlExistingGroups.Height = 0;

            var configPath = MainPath.path + @"\config";
            var subDirectories = Directory.GetDirectories(configPath);
            foreach (var dir in subDirectories)
            {
                try
                {
                    LoadCategory(dir);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (pnlExistingGroups.HasChildren) // helper if no group is created
            {
                lblHelpTitle.Text = "Click on a group to add a taskbar shortcut";
                pnlHelp.Visible = true;
            }
            else // helper if groups are created
            {
                lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
                pnlHelp.Visible = false;
            }
            pnlBottomMain.Top = pnlExistingGroups.Bottom + 20; // spacing between existing groups and add new group btn

            Reset();
        }

        public void LoadCategory(string dir)
        {
            var category = new Category(dir);
            var newCategory = new ucCategoryPanel(this, category);
            pnlExistingGroups.Height += newCategory.Height;
            pnlExistingGroups.Controls.Add(newCategory);
            newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
            newCategory.Show();
            newCategory.BringToFront();
            newCategory.MouseEnter += (sender, e) => EnterControl(sender, e, newCategory);
            newCategory.MouseLeave += (sender, e) => LeaveControl(sender, e, newCategory);
        }

        public void Reset()
        {
            if (pnlBottomMain.Bottom > Bottom)
            {
                pnlLeftColumn.Height = pnlBottomMain.Bottom;
            }
            else
            {
                pnlLeftColumn.Height = RectangleToScreen(ClientRectangle).Height; // making left column pnl dynamic
            }
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            var newGroup = new frmGroup(this);
            newGroup.Show();
            newGroup.BringToFront();
        }

        private void pnlAddGroup_MouseLeave(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(3, 3, 3);
        }

        private void pnlAddGroup_MouseEnter(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void EnterControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(31, 31, 31);
        }
        public void LeaveControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(3, 3, 3);
        }

        private static async Task<string> getVersionData()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "taskbar-groups");
                var res = await client.GetAsync("https://api.github.com/repos/alper/taskbar-groups/releases");
                res.EnsureSuccessStatusCode();
                var responseBody = await res.Content.ReadAsStringAsync();

                var responseJSON = JsonArray.Parse(responseBody);
                var jsonObjectData = responseJSON[0].GetObject();

                return jsonObjectData["tag_name"].GetString();
            } catch {return "Not found";}
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/alper/taskbar-groups/releases");
        }

        private void frmClient_Resize(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
