using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    [XmlType(TypeName = "uczelnia")]
    public class College
    {
        [XmlAttribute(AttributeName = "createdAt")]
        public string dateOfCreation;
        [XmlAttribute(AttributeName = "author")]
        public string author = "Wojciech Pawleniak";

        
        public List<Student> studenci;

        public List<ActiveStudies> activeStudies; 

        public College() { }

        public College(List<Student> students, List<ActiveStudies> studies)
        {
            dateOfCreation = DateTime.Today.ToShortDateString(); 
            this.studenci = students;
            this.activeStudies = studies; 
        }


    }
}
