using AppProject.Core.Print;
using System;
using System.Collections.ObjectModel;

namespace AppProject.Core.Module
{
    public abstract class ModulesNestedBase : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool _disposed = false;
        private readonly IPrint _printer;
        public readonly Collection<IModule> _innerModules;

        public ModulesNestedBase(IPrint printer, Collection<IModule> innerModules)
        {
            _printer = printer;
            _innerModules = innerModules;
            _printer.Print("Initiating module" + this.GetType());
        }

        public virtual void Init()
        {
            foreach (IModule module in _innerModules)
            {
                module.Init();
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            _disposed = true;
        }
    }
}
