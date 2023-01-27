using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Core.Time
{
    public interface ITime
    {
        string GetDateTime();
        string GetTime();

        string GetTimeSpan(TimeSpan timeSpan);
    }
}
