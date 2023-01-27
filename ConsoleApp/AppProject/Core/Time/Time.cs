using System;

namespace AppProject.Core.Time
{
    public class Time : ITime
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }

        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public string GetTimeSpan(TimeSpan timeSpan)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
                timeSpan.Milliseconds / 10);

            return elapsedTime;
        }
    }
}
