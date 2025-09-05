using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OurFirstRevitPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]

    public partial class Export : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.AppendAllText(saveFileDialog.FileName, "SOCIAL_DESIGN_INTENTION " + Step4.instance.tb2.Text.ToString() + "\n");
                File.AppendAllText(saveFileDialog.FileName, "DESCRIPTION " + Step4.instance.tb3.Text.ToString() + "\n");
                foreach (string item in Step1.instance.lb1.Items) { File.AppendAllText(saveFileDialog.FileName, item); }
                foreach (string item in Step2.instance.lb1.Items) { File.AppendAllText(saveFileDialog.FileName, item + "\n"); }
                foreach (string item in Step3.instance.lb1.Items) { File.AppendAllText(saveFileDialog.FileName, item + "\n"); }
                foreach (string item in Step4.instance.lb1.Items) { File.AppendAllText(saveFileDialog.FileName, item + "\n"); }
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }


}


