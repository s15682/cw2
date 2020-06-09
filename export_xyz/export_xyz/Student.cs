using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    [Serializable]
    public class Student
    {
        [XmlAttribute(AttributeName = "indexNumber")] public string IndexNumber { get; set; }
        [XmlElement(ElementName = "fname")] public string Imie { get; set; }
        [XmlElement(ElementName = "lname")] public string Nazwisko { get; set; }
        [XmlElement(ElementName = "birthdate")] public string DataUrodzenia { get; set; }
        [XmlElement(ElementName = "email")] public string Email { get; set; }
        [XmlElement(ElementName = "mothersName")] public string ImieMatki { get; set; }
        [XmlElement(ElementName = "fathersName")] public string ImieOjca { get; set; }
        [XmlElement(ElementName = "studies")] public string Studia { get; set; }

    }
}
