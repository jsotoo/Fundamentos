using System;

namespace AppProject.Core.Print
{
    public interface IPrint
    {
        void Print(string message);

        void Print(object objectInstance);
    }
}
