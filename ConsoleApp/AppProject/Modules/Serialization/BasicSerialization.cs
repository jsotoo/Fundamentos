using AppProject.Core.Module;
using AppProject.Core.Print;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicSerialization : ModulesNestedBase, IModule
    {
        public BasicSerialization() : base(new ConsolePrinter(), new Collection<IModule>() { /*new TheDataContractJsonSerializer(), new TheIFormater(), */ new TheXMLSerializer() })
        {

        }
    }
}
