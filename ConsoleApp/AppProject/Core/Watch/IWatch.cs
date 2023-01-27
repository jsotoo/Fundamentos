using System;

namespace AppProject.Core.Watch
{
    public interface IWatch
    {
        void Start();
        void Stop();
        string GetTimeSpan();
        string GetMethodName();
    }
}
