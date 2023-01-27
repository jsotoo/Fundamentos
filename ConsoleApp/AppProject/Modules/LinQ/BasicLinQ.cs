using AppProject.Core.Module;
using AppProject.Core.Print;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicLinQ : ModulesNestedBase, IModule
    {

        public BasicLinQ() : base(new ConsolePrinter(),new Collection<IModule>() { new LinQToObjects() })
        {
            
        }
    }
}
