using AppProject.Core.Module;
using AppProject.Core.Print;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicEvents : ModulesNestedBase, IModule
    {

        public BasicEvents() : base(new ConsolePrinter(), new Collection<IModule>() { /*new EventSimpleExample(), */ /*new ConceptualImplementation(), */ new PrintExample() })
        {

        }
    }
}
