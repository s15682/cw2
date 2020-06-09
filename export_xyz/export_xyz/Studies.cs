using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    public enum StudiesMode
    {
        Dzienne, Zaoczne, Internetowe 
    }

    [Serializable]
    public class Studies
    {
        [XmlElement(ElementName = "name")] public string Nazwa { get; set; }
        [XmlElement(ElementName = "mode")] public StudiesMode Tryb { get; set; }
    }
}
