using AppProject.Core.Print;
using AppProject.Core.Watch;

namespace AppProject.Modules.Delegates.Resources
{
    public class InstanceProcedures
    {
        private IPrint _printer;
        private IWatch _watcher;

        public InstanceProcedures(IPrint printer, IWatch watcher)
        {
            _printer = printer;
            _watcher = watcher;
        }

        #region [Signature1]

        public void Signature1()
        {
            _printer.Print("Calling " + _watcher.GetMethodName());
        }

        public void Signature1Again()
        {
            _printer.Print("Calling " + _watcher.GetMethodName());
        }

        #endregion

        #region [Signature2]

        public void Signature2(string message)
        {
            _printer.Print("Calling " + _watcher.GetMethodName() + " | " + message);
        }

        #endregion

        #region [Signature3]

        public void Signature3(IPrint printer)
        {
            printer.Print("Calling " + _watcher.GetMethodName());
        }

        #endregion
    }
}
