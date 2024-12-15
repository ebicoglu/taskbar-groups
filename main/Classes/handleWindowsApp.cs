using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using Windows.ApplicationModel;
using Windows.Management.Deployment;
using Shell32;

namespace client.Classes
{
    class handleWindowsApp
    {
        public static Dictionary<string, string> fileDirectoryCache = new Dictionary<string, string>();

        private static PackageManager pkgManger = new PackageManager();
        public static Bitmap getWindowsAppIcon(string file, bool alreadyAppID = false)
        {
            // Get the app's ID from its shortcut target file (Ex. 4DF9E0F8.Netflix_mcm4njqhnhss8!Netflix.app)
            var microsoftAppName = (!alreadyAppID) ? GetLnkTarget(file) : file;

            // Split the string to get the app name from the beginning (Ex. 4DF9E0F8.Netflix)
            var subAppName = microsoftAppName.Split('!')[0];

            // Loop through each of the folders with the app name to find the one with the manifest + logos
            var appPath = findWindowsAppsFolder(subAppName);

            // Load and read manifest to get the logo path
            var appManifest = new XmlDocument();
            appManifest.Load(appPath + "\\AppxManifest.xml");

            var appManifestNamespace = new XmlNamespaceManager(new NameTable());
            appManifestNamespace.AddNamespace("sm", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");

            var logoLocation = (appManifest.SelectSingleNode("/sm:Package/sm:Properties/sm:Logo", appManifestNamespace).InnerText).Replace("\\", @"\");



            if (logoLocation != null)
            {
                // Get the last instance or usage of \ to cut out the path of the logo just to have the path leading to the general logo folder
                logoLocation = logoLocation.Substring(0, logoLocation.LastIndexOf(@"\"));
                var logoLocationFullPath = Path.GetFullPath(appPath + "\\" + logoLocation);

                // Search for all files with 150x150 in its name and use the first result
                var logoDirectory = new DirectoryInfo(logoLocationFullPath);
                var filesInDir = getLogoFolder("StoreLogo", logoDirectory);

                if (filesInDir.Length != 0)
                {
                    return getLogo(filesInDir.Last().FullName, file);
                }

                filesInDir = getLogoFolder("scale-200", logoDirectory);

                if (filesInDir.Length != 0)
                {
                    return getLogo(filesInDir[0].FullName, file);
                }

                return Icon.ExtractAssociatedIcon(file).ToBitmap();
            }

            return Icon.ExtractAssociatedIcon(file).ToBitmap();
        }

        private static FileInfo[] getLogoFolder(string keyname, DirectoryInfo logoDirectory)
        {
            // Search for all files with the keyname in its name and use the first result
            var filesInDir = logoDirectory.GetFiles("*" + keyname + "*.*");
            return filesInDir;
        }

        private static Bitmap getLogo(string logoPath, string defaultFile)
        {
            if (File.Exists(logoPath))
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(logoPath)))
                    return ImageFunctions.ResizeImage(Bitmap.FromStream(ms), 64, 64);
            }

            return Icon.ExtractAssociatedIcon(defaultFile).ToBitmap();
        }

        public static string GetLnkTarget(string lnkPath)
        {
            var shl = new Shell();
            lnkPath = Path.GetFullPath(lnkPath);
            var dir = shl.NameSpace(Path.GetDirectoryName(lnkPath));
            var itm = dir.Items().Item(Path.GetFileName(lnkPath));
            var lnk = (ShellLinkObject)itm.GetLink;
            return lnk.Target.Path;
        }

        public static string findWindowsAppsFolder(string subAppName)
        {

            if (!fileDirectoryCache.ContainsKey(subAppName))
            {
                try
                {
                    var packages = pkgManger.FindPackagesForUser("", subAppName);


                    var finalPath = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + @"\WindowsApps\" + packages.First().InstalledLocation.DisplayName + @"\";
                    fileDirectoryCache[subAppName] = finalPath;
                    return finalPath;
                }
                catch (UnauthorizedAccessException) { };
                return "";
            }

            return fileDirectoryCache[subAppName];
        }

        public static string findWindowsAppsName(string AppName)
        {
            var subAppName = AppName.Split('!')[0];
            var appPath = findWindowsAppsFolder(subAppName);

            

                // Load and read manifest to get the logo path
                var appManifest = new XmlDocument();
            appManifest.Load(appPath + "\\AppxManifest.xml");

            var appManifestNamespace = new XmlNamespaceManager(new NameTable());
            appManifestNamespace.AddNamespace("sm", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");
            appManifestNamespace.AddNamespace("uap", "http://schemas.microsoft.com/appx/manifest/uap/windows10");

            try
            {
                return appManifest.SelectSingleNode("/sm:Package/sm:Applications/sm:Application/uap:VisualElements", appManifestNamespace).Attributes.GetNamedItem("DisplayName").InnerText;
            } catch (Exception)
            {
                return appManifest.SelectSingleNode("/sm:Package/sm:Properties/sm:DisplayName", appManifestNamespace).InnerText;
            }
        }
    }
}
