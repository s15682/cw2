using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    public class XmlOutputFileCreator : IOutputFileCreator
    {
        string outputFilePath;

        public XmlOutputFileCreator(string outputFilePath)
        {
            this.outputFilePath=outputFilePath;
        }

        public void CreateOutputFile(College college)
        {
            FileStream writer = new FileStream(outputFilePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer( typeof(College));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, college, ns);
        }

  
    }
}
