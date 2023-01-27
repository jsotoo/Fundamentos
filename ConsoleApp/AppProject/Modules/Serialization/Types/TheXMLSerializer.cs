using AppProject.Core.Module;
using AppProject.Core.Print;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AppProject.Modules
{
    public class TheXMLSerializer : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public TheXMLSerializer() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            SerializeElement();
            SerializeNode();
        }

        private void SerializeElement()
        {
            string filename = "Element.xml";
            XmlSerializer ser = new XmlSerializer(typeof(XmlElement));
            XmlElement myElement =
            new XmlDocument().CreateElement("MyElement", "ns");
            myElement.InnerText = "Hello World";
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, myElement);
            writer.Close();
        }

        private void SerializeNode()
        {
            string filename = "Node.xml";
            XmlSerializer ser = new XmlSerializer(typeof(XmlNode));
            XmlNode myNode = new XmlDocument().
            CreateNode(XmlNodeType.Element, "MyNode", "ns");
            myNode.InnerText = "Hello Node";
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, myNode);
            writer.Close();
        }
    }

}
