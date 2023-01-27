using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Watch;
using System;

namespace AppProject.Modules
{
    public class Lambda : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private readonly IWatch _watcher;

        public Lambda() : base(new ConsolePrinter())
        {
            // Init helpers
            _printer = new ConsolePrinter();
            _watcher = new Watcher();
        }

        public void Init()
        {
            
        }
    }
}
