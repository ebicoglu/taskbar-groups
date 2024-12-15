using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using client.Forms;
using client.Properties;
using client.User_controls;

namespace client.Classes
{
    public class Category
    {
        public string Name;
        public string ColorString = ColorTranslator.ToHtml(Color.FromArgb(31, 31, 31));
        public bool allowOpenAll;
        public List<ProgramShortcut> ShortcutList;
        public int Width; // not used aon
        public double Opacity = 10;
        Regex specialCharRegex = new Regex("[*'\",_&#^@]");

        private static int[] iconSizes = {16,32,64,128,256,512};

        public Category(string path)
        {
            // Use application's absolute path; (grabs the .exe)
            // Gets the parent folder of the exe and concats the rest of the path
            string fullPath;

            // Check if path is a full directory or part of a file name
            // Passed from the main shortcut client and the config client

            if (File.Exists(MainPath.path + @"\" + path + @"\ObjectData.xml"))
            {
                fullPath = MainPath.path + @"\" + path + @"\ObjectData.xml";
            }
            else
            {
                fullPath = Path.GetFullPath(path + "\\ObjectData.xml");
            }

            var reader =
                new XmlSerializer(typeof(Category));
            using (var file = new StreamReader(fullPath))
            {
                var category = (Category)reader.Deserialize(file);
                Name = category.Name;
                ShortcutList = category.ShortcutList;
                Width = category.Width;
                ColorString = category.ColorString;
                Opacity = category.Opacity;
                allowOpenAll = category.allowOpenAll;
            }
        }

        public Category() // needed for XML serialization
        {

        }

        public void CreateConfig(Image groupImage)
        {

            var path = @"config\" + Name;
            //string filePath = path + @"\" + this.Name + "Group.exe";
            //
            // Directory and .exe
            //
            Directory.CreateDirectory(path);

            //System.IO.File.Copy(@"config\config.exe", @filePath);
            //
            // XML config
            //
            var writer =
                new XmlSerializer(typeof(Category));

            using (var file = File.Create(path + @"\ObjectData.xml"))
            {
                writer.Serialize(file, this);
                file.Close();
            }
            //
            // Create .ico
            //

            Image img = ImageFunctions.ResizeImage(groupImage, 256, 256); // Resize img if too big
            img.Save(path + @"\GroupImage.png");

            if (GetMimeType(groupImage) == "*.PNG")
            {
                createMultiIcon(groupImage, path + @"\GroupIcon.ico");
            }
            else { 
                using (var fs = new FileStream(path + @"\GroupIcon.ico", FileMode.Create))
                {
                    ImageFunctions.IconFromImage(img).Save(fs);
                    fs.Close();
                }
            }


            // Through shellLink.cs class, pass through into the function information on how to construct the icon
            // Needed due to needing to set a unique AppUserModelID so the shortcut applications don't stack on the taskbar with the main application
            // Tricks Windows to think they are from different applications even though they are from the same .exe
            ShellLink.InstallShortcut(
                Path.GetFullPath(AppDomain.CurrentDomain.FriendlyName),
                "alper.taskbarGroup.menu." + Name,
                 path + " shortcut",
                 Path.GetFullPath(path),
                 Path.GetFullPath(path + @"\GroupIcon.ico"),
                 path + "\\" + Name + ".lnk",
                 Name
            );


            // Build the icon cache
            cacheIcons();

            File.Move(path + "\\" + Name + ".lnk",
                Path.GetFullPath(@"Shortcuts\" + Regex.Replace(Name, @"(_)+", " ") + ".lnk")); // Move .lnk to correct directory
        }

        private static void createMultiIcon(Image iconImage, string filePath)
        {


            var diffList = from number in iconSizes
                select new
                    {
                        number,
                        difference = Math.Abs(number - iconImage.Height)
                    };
            var nearestSize = (from diffItem in diffList
                          orderby diffItem.difference
                          select diffItem).First().number;

            var iconList = new List<Bitmap>();

            while (nearestSize != 16)
            {
                iconList.Add(ImageFunctions.ResizeImage(iconImage, nearestSize, nearestSize));
                nearestSize = (int)Math.Round((decimal) nearestSize / 2);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                IconFactory.SavePngsAsIcon(iconList.ToArray(), stream);
            }
        }

        public Bitmap LoadIconImage() // Needed to access img without occupying read/write
        {
            var path = @"config\" + Name + @"\GroupImage.png";

            using (var ms = new MemoryStream(File.ReadAllBytes(path)))
                return new Bitmap(ms);
        }

        // Goal is to create a folder with icons of the programs pre-cached and ready to be read
        // Avoids having the icons need to be rebuilt everytime which takes time and resources
        public void cacheIcons()
        {

            // Defines the paths for the icons folder
            var path = MainPath.path + @"\config\" + Name;
            var iconPath = path + "\\Icons\\";

            // Check and delete current icons folder to completely rebuild the icon cache
            // Only done on re-edits of the group and isn't done usually
            if (Directory.Exists(iconPath))
            {
                Directory.Delete(iconPath, true);
            }

            // Creates the icons folder inside of existing config folder for the group
            Directory.CreateDirectory(iconPath);

            iconPath = path + @"\Icons\";

            // Loops through each shortcut added by the user and gets the icon
            // Writes the icon to the new folder in a .jpg format
            // Namign scheme for the files are done through Path.GetFileNameWithoutExtension()
            for (var i = ShortcutList.Count; i < 0; i--)
            {
                var filePath = ShortcutList[i].FilePath;

                var programShortcutControl = Application.OpenForms["frmGroup"].Controls["pnlShortcuts"].Controls[i] as ucProgramShortcut;
                string savePath;

                if (ShortcutList[i].isWindowsApp)
                {
                    savePath = iconPath + "\\" + specialCharRegex.Replace(filePath, string.Empty) + ".png";
                } else if (Directory.Exists(filePath))
                {
                    savePath = iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_FolderObjTSKGRoup.png";
                } else
                {
                    savePath = iconPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".png";
                }

                programShortcutControl.logo.Save(savePath);

    }
        }

        // Try to load an iamge from the cache
        // Takes in a programPath (shortcut) and processes it to the proper file name
        public Image loadImageCache(ProgramShortcut shortcutObject)
        {

            var programPath = shortcutObject.FilePath;

            if (File.Exists(programPath) || Directory.Exists(programPath) || shortcutObject.isWindowsApp)
            {
                try
                {
                    // Try to construct the path like if it existed
                    // If it does, directly load it into memory and return it
                    // If not then it would throw an exception in which the below code would catch it
                    var cacheImagePath = Path.GetDirectoryName(Application.ExecutablePath) + 
                                         @"\config\" + Name + @"\Icons\" + ((shortcutObject.isWindowsApp) ? specialCharRegex.Replace(programPath, string.Empty) : 
                                             Path.GetFileNameWithoutExtension(programPath)) + (Directory.Exists(programPath)? "_FolderObjTSKGRoup.jpg" : ".png");

                    using (var ms = new MemoryStream(File.ReadAllBytes(cacheImagePath)))
                        return Image.FromStream(ms);
                    
                }
                catch (Exception)
                {
                    // Try to recreate the cache icon image and catch and missing file/icon situations that may arise

                    // Checks if the original file even exists to make sure to not do any extra operations

                    // Same processing as above in cacheIcons()
                    var path = MainPath.path + @"\config\" + Name + @"\Icons\" + Path.GetFileNameWithoutExtension(programPath) + (Directory.Exists(programPath) ? "_FolderObjTSKGRoup.png" : ".png");

                    Image finalImage;

                    if (Path.GetExtension(programPath).ToLower() == ".lnk")
                    {
                        finalImage = frmGroup.handleLnkExt(programPath);
                    }
                    else if (Directory.Exists(programPath))
                    {
                        finalImage = handleFolder.GetFolderIcon(programPath).ToBitmap();
                    } else 
                    {
                        finalImage = Icon.ExtractAssociatedIcon(programPath).ToBitmap();
                    }


                    // Above all sets finalIamge to the bitmap that was generated from the icons
                    // Save the icon after it has been fetched by previous code
                    finalImage.Save(path);

                    // Return the said image
                    return finalImage;
                }
            }

            return Resources.Error;
        }

        public static string GetMimeType(Image i)
        {
            var imgguid = i.RawFormat.Guid;
            foreach (var codec in ImageCodecInfo.GetImageDecoders())
            {
                if (codec.FormatID == imgguid)
                {
                    return codec.FilenameExtension;
                }
            }
            return "image/unknown";
        }
        //
        // END OF CLASS
        //
    }
}
