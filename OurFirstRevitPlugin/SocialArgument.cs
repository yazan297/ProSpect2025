using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFirstRevitPlugin
{
    public class SocialArgument
    {
        public string reference;
        public List<SAElement> elements;
        public List<SARelation> relations;

        public void addElement()
        {
            elements.Add(new SAElement());
        }
        public void addRelation()
        {
            relations.Add(new SARelation());
        }


    }
}
