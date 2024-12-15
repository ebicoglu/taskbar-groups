using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using client.Classes;
using client.Forms;

namespace client
{
    internal static class client
    {
        public static string[] Arguments = Environment.GetCommandLineArgs();

        // Define functions to set AppUserModelID
        [DllImport("shell32.dll", SetLastError = true)]
        static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);
        
        [STAThread]
        static void Main()
        {
            // Use existing methods to obtain cursor already imported as to not import any extra functions
            // Pass as two variables instead of Point due to Point requiring System.Drawing
            var cursorX = Cursor.Position.X;
            var cursorY = Cursor.Position.Y;

            // Set the MainPath to the absolute path where the exe is located
            MainPath.path = Path.GetFullPath(new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath);
            MainPath.exeString = Path.GetFullPath(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);

            Directory.CreateDirectory($"{MainPath.path}\\JITComp");

            // Creates directory in case it does not exist for config files
            Directory.CreateDirectory($"{MainPath.path}\\config");
            Directory.CreateDirectory($"{MainPath.path}\\Shortcuts");

            ProfileOptimization.SetProfileRoot(MainPath.path + "\\JITComp");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                File.Create(MainPath.path + "\\directoryTestingDocument.txt").Close();
                File.Delete(MainPath.path + "\\directoryTestingDocument.txt");
            }
            catch
            {
                using (var configTool = new Process())
                {
                    configTool.StartInfo.FileName = MainPath.exeString;
                    configTool.StartInfo.Verb = "runas";
                    try
                    {
                        configTool.Start();
                    } catch
                    {
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }

            if (Arguments.Length > 1) // Checks for additional arguments; opens either main application or taskbar drawer application
            {
                // Distinguishes each shortcut process from one another to prevent them from stacking with the main application
                SetCurrentProcessExplicitAppUserModelID("alper.taskbarGroup.menu."+ Arguments[1]);

                Application.Run(new frmMain(Arguments[1], cursorX, cursorY));
            } else
            {
                // See comment above
                SetCurrentProcessExplicitAppUserModelID("alper.taskbarGroup.main");
                Application.Run(new frmClient());
            }
        }
    }
}
