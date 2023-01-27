using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

namespace AppProject.Modules
{
    public class TheIFormater : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public TheIFormater() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            SerializeObjectToBinaryFile();
            DeserializeBinaryFileToObject();
            SerializeObjectToSOAPFile();
            DeserializeSOAPFileToObject();
        }

        private void SerializeObjectToBinaryFile()
        {
            ClassToSerialize2 obj = new ClassToSerialize2();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyBinaryFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        private void DeserializeBinaryFileToObject()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyBinaryFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            ClassToSerialize2 obj = (ClassToSerialize2)formatter.Deserialize(stream);
            stream.Close();

            // Here's the proof.  
            _printer.Print($"n1: {obj.n1}");
            _printer.Print($"n2: {obj.n2}");
            _printer.Print($"str: {obj.str}");
        }
        private void SerializeObjectToSOAPFile()
        {
            ClassToSerialize2 obj = new ClassToSerialize2();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream("MySOAPFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        private void DeserializeSOAPFileToObject()
        {
            IFormatter formatter = new SoapFormatter();
            Stream stream = new FileStream("MySOAPFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            ClassToSerialize2 obj = (ClassToSerialize2)formatter.Deserialize(stream);
            stream.Close();

            // Here's the proof.  
            _printer.Print($"n1: {obj.n1}");
            _printer.Print($"n2: {obj.n2}");
            _printer.Print($"str: {obj.str}");
        }
    }
}
