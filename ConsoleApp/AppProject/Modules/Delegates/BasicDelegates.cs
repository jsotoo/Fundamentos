using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Watch;
using AppProject.Modules.Delegates.Resources;
using AppProject.Modules.Delegates.Types;
using System;
using System.Collections.ObjectModel;

namespace AppProject.Modules
{
    public class BasicDelegates : ModulesNestedBase, IModule
    {
        public BasicDelegates() : base(new ConsolePrinter(), new Collection<IModule>() { new FuncDelegate(), new ActionDelegate(), new PredicateDelegate() })
        {

        }
    }
}
