using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    [XmlType(TypeName = "activeStudies")]
    public class ActiveStudies
    {
        public static Dictionary<string,ActiveStudies> studies = new Dictionary<string, ActiveStudies>();

        [XmlAttribute(AttributeName = "name")]
        public string name;
        [XmlAttribute(AttributeName = "numberOfStudents")]
        public int numberOfStudents=1;

        public ActiveStudies() { }

        public ActiveStudies(string name)
        {
            this.name = name; 
        }


        public static void AddStudiesOrIncrementStudents(string name)
        {
            if (!studies.ContainsKey(name))
            {
                studies.Add(name, new ActiveStudies(name));
            } else
            {
                studies[name].numberOfStudents++; 
            }
        }

        public static List<ActiveStudies> GetActiveStudies()
        {
            return studies.Values.ToList<ActiveStudies>(); 
        }

    }
}
