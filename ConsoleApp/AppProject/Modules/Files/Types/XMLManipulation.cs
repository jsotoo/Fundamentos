using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AppProject.Modules.Files.Types
{
    public class XMLManipulation : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private const string file = @"Modules\\Files\\Resources\\File1.txt";
        private string fileFullPath = string.Empty;
        private string copyDirectoryName = "CopyDirectory";
        private string copyDirectoryFullPath = string.Empty;
        private string moveDirectoryName = "MoveDirectory";
        private string moveDirectoryFullPath = string.Empty;
        private string tempXml = @"<Projects>  
        <Project ID='1' Name='project1' />  
        <Project ID='2' Name='project2' />  
        <Project ID='3' Name='project3' />  
        <Project ID='4' Name='project4' />  
        <Project ID='5' Name='project5' />  
        </Projects>";

        public XMLManipulation() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            fileFullPath = Path.Combine(appPath + file);
            copyDirectoryFullPath = Path.Combine(appPath + copyDirectoryName);
            moveDirectoryFullPath = Path.Combine(appPath + moveDirectoryName);
        }

        public void Init()
        {
            UseOfXMLDocument();
            UseOfXDocument();
        }

        private void UseOfXMLDocument()
        {
            // Option1: Using InsertAfter()
            // Adding Node to XML  
            XmlDocument document1 = new XmlDocument();
            document1.LoadXml(tempXml);
            XmlNode root1 = document1.DocumentElement;
            //Create a new attrtibute.  
            XmlElement element = document1.CreateElement("Project");
            XmlAttribute attribute = document1.CreateAttribute("ID");
            attribute.Value = "6";
            element.Attributes.Append(attribute);
            //Create a new attrtibute.  
            XmlAttribute attr2 = document1.CreateAttribute("Name");
            attr2.Value = "Project6";
            element.Attributes.Append(attr2);
            //Add the node to the document.  
            root1.InsertAfter(element, root1.LastChild);
            document1.Save(Console.Out);
            Console.WriteLine();
            File.WriteAllText("XMLDocument1.xml", document1.OuterXml);


            // Option2: Using AppendChild()
            XmlDocument document2 = new XmlDocument();
            document2.LoadXml(tempXml);
            XmlElement XElement = document2.CreateElement("Project");
            XElement.SetAttribute("Name", "Project6");
            XElement.SetAttribute("ID", "6");
            document2.DocumentElement.AppendChild(XElement.Clone());
            document2.Save(Console.Out);
            Console.WriteLine();
            File.WriteAllText("XMLDocument2.xml", document2.OuterXml);
        }

        private void UseOfXDocument()
        {

            string tempXmlNamespace = @"<Projects xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>  
                    <Project ID='1' Name='project1' />  
                    <Project ID='2' Name='project2' />  
                    <Project ID='3' Name='project3' />  
                    <Project ID='4' Name='project4' />  
                    <Project ID='5' Name='project5' />  
                    </Projects>";
            // Option1: Using AddAfterSelf()
            XDocument xDocument1 = XDocument.Parse(tempXml);
            XElement xElement = xDocument1.Descendants("Project")
                            .First(rec => rec.Attribute("ID").Value == "5");
            xElement.AddAfterSelf(new XElement("Project", new XAttribute("ID", "6")));
            xDocument1.Save(Console.Out);
            File.WriteAllText("XDocument1.xml", xDocument1.ToString());
            Console.WriteLine();

            // Option2: Using Add() method 
            XDocument xDocument2 = XDocument.Parse(tempXml);
            XElement root = new XElement("Project");
            root.Add(new XAttribute("ID", "6"));
            root.Add(new XAttribute("Name", "Project6"));
            xDocument2.Element("Projects").Add(root);
            xDocument2.Save(Console.Out);
            Console.WriteLine();
            File.WriteAllText("XDocument2.xml", xDocument1.ToString());

            XNamespace xNameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";
            XDocument xDocucment3 = XDocument.Parse(tempXmlNamespace);

            XElement lastXElement = xDocucment3.Descendants(xNameSpace + "Project").Last();

            lastXElement.Parent.Add(
                new XElement(xNameSpace + "Project",
                    new XAttribute("ID", "6"), new XAttribute("Name", "Project6")
                )
            );

            xDocucment3.Save(Console.Out);
            Console.WriteLine();
            File.WriteAllText("XDocument3.xml", xDocument1.ToString());
        }
    }
}
