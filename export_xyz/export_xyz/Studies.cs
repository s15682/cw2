using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    public enum StudiesMode
    {
        Dzienne, Zaoczne, Internetowe, Wieczorowe
    }

    [Serializable]
    public class Studies
    {
        [XmlElement(ElementName = "name")] public string Nazwa { get; set; }
        [XmlElement(ElementName = "mode")] public StudiesMode Tryb { get; set; }

        public Studies(string name, string mode)
        {
            Nazwa = name;
            Tryb = SetMode(mode);
        }

        private StudiesMode SetMode(string mode)
        {
            if (mode == "Dzienne" || mode == "dzienne")
            {
                return StudiesMode.Dzienne;
            }
            if (mode == "Zaoczne" || mode == "zaoczne")
            {
                return StudiesMode.Zaoczne;
            }
            if (mode == "Internetowe" || mode == "internetowe")
            {
                return StudiesMode.Internetowe;
            }
            if (mode == "Wieczorowe" || mode == "wieczorowe")
            {
                return StudiesMode.Internetowe;
            }
            throw new Exception("Invalid mode "+mode);
        }

        public override string ToString()
        {
            return Nazwa + "," + Tryb;
        }
    }

    public class InvalidStudiesMode : Exception
    {
        public InvalidStudiesMode(): this("Podano niepoprawny tryb studiów"){}

        public InvalidStudiesMode(string msg) : base(msg) { }
    }

    
}
