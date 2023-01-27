using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Modules.Tasks.Types;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicTasks : ModulesNestedBase, IModule
    {
        public BasicTasks() : base(new ConsolePrinter(), new Collection<IModule>() { new AsyncAndAwait() /*, new TaskParallel(), new DataCollectionInParallel()*/ })
        {

        }
    }
}
