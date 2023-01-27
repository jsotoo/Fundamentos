using AppProject.Core.Module;
using AppProject.Core.Print;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AppProject.Modules
{
    public class TheDataContractJsonSerializer : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public TheDataContractJsonSerializer() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            SerializeObjectToJSON();
            DeserializeJSONToObject();
            WriteFromObject();
            ReadToObject();
        }
        private void SerializeObjectToJSON()
        {
            ClassToSerialize1 classInstance = new ClassToSerialize1();
            var stream = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(ClassToSerialize1));
            serializer.WriteObject(stream, classInstance);

            stream.Position = 0;
            var streamReader = new StreamReader(stream);
            _printer.Print("JSON form of Person object: ");
            _printer.Print(streamReader.ReadToEnd());
        }
        private void DeserializeJSONToObject()
        {
            ClassToSerialize1 classInstance = new ClassToSerialize1();
            var stream = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(ClassToSerialize1));
            serializer.WriteObject(stream, classInstance);

            stream.Position = 0;
            var theObject = (ClassToSerialize1)serializer.ReadObject(stream);
            _printer.Print($"Deserialized back, got name={theObject.Name}, age={theObject.Age}");
        }

        // Create a User object and serialize it to a JSON stream.
        private void WriteFromObject()
        {
            // Create User object.
            var classToSerialize = new ClassToSerialize3("Bob", 42);

            // Create a stream to serialize the object to.
            var memoryStream = new MemoryStream();

            // Serializer the User object to the stream.
            var serializer = new DataContractJsonSerializer(typeof(ClassToSerialize3));
            serializer.WriteObject(memoryStream, classToSerialize);
            byte[] json = memoryStream.ToArray();
            memoryStream.Close();
            string jsonResult = Encoding.UTF8.GetString(json, 0, json.Length);

            _printer.Print(jsonResult);
        }

        // Deserialize a JSON stream to a User object.
        public void ReadToObject()
        {
            string json = "{'_v1':'Bob','_v2':42}";
            var deserializedObject = new ClassToSerialize3();
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var serializer = new DataContractJsonSerializer(deserializedObject.GetType());
            deserializedObject = serializer.ReadObject(memoryStream) as ClassToSerialize3;
            memoryStream.Close();

            _printer.Print($"Deserialized object: v1:{deserializedObject.V1} v2:{deserializedObject.V2}");
        }
    }

}
