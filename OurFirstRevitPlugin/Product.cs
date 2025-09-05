using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurFirstRevitPlugin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Product : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            MessageBox.Show("Please select building elements involved in the social design intention");

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document doc = uidoc.Document;

            List<Element> selectedElements = SelectElements(uidoc, doc);

            List<string> myElements = new List<string>();

            Step1 step1 = new Step1(doc);

            foreach (Element e in selectedElements)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.IFC_GUID);
                Step1.instance.cb1.Items.Add(e.Name + " GUID: " + GetParameterValue(p) + "\n");
            }

            using (Transaction t = new Transaction(doc, "param"))
            {
                StringBuilder sb = new StringBuilder();
                t.Start("param");

                foreach (Element e in selectedElements)
                {
                    Parameter p = e.get_Parameter(BuiltInParameter.IFC_GUID);
                    sb.Append("\n" + e.Name + "\n" + "GUID: " + GetParameterValue(p));
                }
                //TaskDialog.Show("Building element selection", sb.ToString()); 
                Autodesk.Revit.UI.TaskDialog.Show("Building element selection", "You have selected " + selectedElements.Count + " building elements");
                t.Commit();
            }

            step1.ShowDialog();

            return Result.Succeeded;
        }
        public List<Element> SelectElements(UIDocument uidoc, Document doc)
        {
            IList<Reference> pickObjs = uidoc.Selection.PickObjects(ObjectType.Element, "Choose elements");
            List<Element> elements = new List<Element>();
            foreach (Reference pickObj in pickObjs)
            {
                elements.Add(doc.GetElement(pickObj));
            }
            return elements;
        }
        public string GetParameterValue(Parameter parameter)
        {
            switch (parameter.StorageType)
            {
                case StorageType.Double:
                    return parameter.AsValueString();
                case StorageType.ElementId:
                    return parameter.AsElementId().Value.ToString();
                case StorageType.Integer:
                    return parameter.AsValueString();
                case StorageType.None:
                    return parameter.AsValueString();
                case StorageType.String:
                    return parameter.AsString();
                default:
                    return "";
            }

        }
    }
}
