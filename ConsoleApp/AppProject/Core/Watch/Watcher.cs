using System;

namespace AppProject.Core.Watch
{
    public class Watcher : WatchBase, IWatch
    {
        public void Start()
        {
            _watcher.Reset();
            _watcher.Start();
        }

        public void Stop()
        {
            _watcher.Stop();
            _timeSpan = _watcher.Elapsed;
        }

        public string GetTimeSpan()
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                _timeSpan.Hours, _timeSpan.Minutes, _timeSpan.Seconds,
                _timeSpan.Milliseconds / 10);

            return elapsedTime;
        }

        public string GetMethodName()
        {
            _stackFrame = _stackTrace.GetFrame(0);

            return _stackFrame.GetMethod().Name;
        }
    }
}
