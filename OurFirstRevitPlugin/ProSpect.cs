using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;

namespace OurFirstRevitPlugin
{
    public class ProSpect : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string newtab = "ProSpect";
            application.CreateRibbonTab(newtab);
            RibbonPanel newPanel = application.CreateRibbonPanel(newtab, "New Social Design Intention");

            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            PushButtonData button2 = new PushButtonData("button2", "About", assemblyPath, "OurFirstRevitPlugin.About");
            PushButtonData button3 = new PushButtonData("button3", "New Social Design Intention", assemblyPath, "OurFirstRevitPlugin.Product");
            PushButtonData button4 = new PushButtonData("button4", "Export Social Design Intention", assemblyPath, "OurFirstRevitPlugin.Export");

            PushButton pushButton2 = newPanel.AddItem(button2) as PushButton;
            PushButton pushButton3 = newPanel.AddItem(button3) as PushButton;
            PushButton pushButton4 = newPanel.AddItem(button4) as PushButton;

            // Load embedded image from resources
            BitmapImage iconImage = LoadEmbeddedPng("OurFirstRevitPlugin.proformalize.png");

            if (iconImage != null)
            {
                pushButton2.LargeImage = iconImage;
                pushButton3.LargeImage = iconImage;
                pushButton4.LargeImage = iconImage;
            }

            return Result.Succeeded;
        }

        private BitmapImage LoadEmbeddedPng(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    TaskDialog.Show("Resource Error", $"Cannot find resource: {resourceName}");
                    return null;
                }

                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze(); // Optional but recommended

                return image;
            }
        }

    }
}
