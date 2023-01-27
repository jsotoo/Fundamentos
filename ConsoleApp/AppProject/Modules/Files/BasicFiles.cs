using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Modules.Files.Types;
using AppProject.Modules.Tasks.Types;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicFiles : ModulesNestedBase, IModule
    {
        public BasicFiles() : base(new ConsolePrinter(), new Collection<IModule>() { /*new FileManipulation(), new FileWatcher(),*/ /*new FileStreams(), */ new XMLManipulation() })
        {

        }
    }
}
