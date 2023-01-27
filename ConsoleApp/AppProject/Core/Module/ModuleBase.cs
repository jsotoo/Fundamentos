using AppProject.Core.Print;
using System;
using System.Collections.ObjectModel;

namespace AppProject.Core.Module
{
    public abstract class ModuleBase : IDisposable
    {
        // Flag: Has Dispose already been called?
        private bool _disposed = false;
        private IPrint _printer;

        public ModuleBase(IPrint printer)
        {
            _printer = printer;
            _printer.Print("Initiating module" + this.GetType());
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
