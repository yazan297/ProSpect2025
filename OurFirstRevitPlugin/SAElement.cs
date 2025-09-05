using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFirstRevitPlugin
{
    public class SAElement
    {
        public string level;
        public string reference;
        public string typ;
        public List<string> arguments = new List<string>();
    }
}
