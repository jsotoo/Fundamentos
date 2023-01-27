using System;
using System.Diagnostics;

namespace AppProject.Core.Watch
{
    public abstract class WatchBase
    {
        internal TimeSpan _timeSpan;
        internal Stopwatch _watcher;
        internal StackTrace _stackTrace;
        internal StackFrame _stackFrame;
        public WatchBase()
        {
            if(_watcher == null)
                _watcher = new Stopwatch();

            if (_stackTrace == null)
                _stackTrace = new StackTrace();
        }
    }
}
