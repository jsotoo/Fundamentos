using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules
{
    public class LinQToObjects : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public LinQToObjects() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            IntExample();
        }

        public void IntExample()
        {
            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (int i in scoreQuery)
            {
                _printer.Print(i + " ");
            }
        }

        public void StringExample()
        {
            string aString = "ABCDE99F-J74-12-89A";

            // Select only those characters that are numbers  
            IEnumerable<char> stringQuery =
              from ch in aString
              where Char.IsDigit(ch)
              select ch;

            // Execute the query  
            foreach (char c in stringQuery)
                _printer.Print(c + " ");

            // Call the Count method on the existing query.  
            int count = stringQuery.Count();
            _printer.Print("Count = " + count);

            // Select all characters before the first '-'  
            IEnumerable<char> stringQuery2 = aString.TakeWhile(c => c != '-');

            // Execute the second query  
            foreach (char c in stringQuery2)
                _printer.Print(c);
        }
    }
}
