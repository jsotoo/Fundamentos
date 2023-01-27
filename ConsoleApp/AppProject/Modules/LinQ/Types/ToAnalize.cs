using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules
{
    public class ToAnalize : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public ToAnalize() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            
        }

        private void Situation1()
        {
            int[] n1 = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.Write("\nBasic structure of LINQ : ");
            Console.Write("\n---------------------------");

            var nQuery =
                from VrNum in n1
                where (VrNum % 2) == 0
                select VrNum;

            Console.Write("\nThe numbers which produce the remainder 0 after divided by 2 are : \n");
            foreach (int VrNum in nQuery)
            {
                Console.Write("{0} ", VrNum);
            }
        }

        private void Situation2()
        {
            int[] n1 = {
                1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14
            };

            var nQuery =
            from VrNum in n1
            where VrNum > 0
            where VrNum < 12
            select VrNum;
            Console.Write("\nThe numbers within the range of 1 to 11 are : \n");
            foreach (var VrNum in nQuery)
            {
                Console.Write("{0}  ", VrNum);
            }
        }

        private void Situation3()
        {
            var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

            var sqNo = from int Number in arr1
                       let SqrNo = Number * Number
                       where SqrNo > 20
                       select new { Number, SqrNo };

            foreach (var a in sqNo)
                Console.WriteLine(a);
        }

        private void Situation4()
        {
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            var n = from x in arr1
                    group x by x into y
                    select y;
            foreach (var arrNo in n)
            {
                Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
            }
        }

        private void Situation5()
        {
            string str = "This is an example text, nothing else, nothing more.";
            Console.Write("\n");

            var FreQ = from x in str
                       group x by x into y
                       select y;
            
            foreach (var ArrEle in FreQ)
            {
                Console.WriteLine("Character " + ArrEle.Key + ": " + ArrEle.Count() + " times");
            }
        }

        private void Situation6()
        {
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            var days = from WeekDay in dayWeek
                       select WeekDay;
            foreach (var WeekDay in days)
            {
                Console.WriteLine(WeekDay);
            }
        }

        private void Situation7()
        {
            int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

            var m = from x in nums
                    group x by x into y
                    select y;

            foreach (var arrEle in m)
            {
                Console.WriteLine(arrEle.Key + "\t" + arrEle.Sum() + "\t\t\t" + arrEle.Count());
            }
        }

        private void Situation8()
        {
            string chst, chen;
            char ch;
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            ch = (char)Console.Read();
            chst = ch.ToString();
            ch = (char)Console.Read();
            chen = ch.ToString();


            var _result = from x in cities
                          where x.StartsWith(chst)
                          where x.EndsWith(chen)
                          select x;
            Console.Write("\n\n");
            foreach (var city in _result)
            {
                Console.Write("You typed {0} and then {1}. The result is : {2} \n", chst, chen, city);
            }
        }

        private void Situation9()
        {
            int i = 0;
            List<int> templist = new List<int>();
            templist.Add(55);
            templist.Add(200);
            templist.Add(740);
            templist.Add(76);
            templist.Add(230);
            templist.Add(482);
            templist.Add(95);

            foreach (var lstnum in templist)
            {
                Console.Write(lstnum + " ");
            }
            List<int> FilterList = templist.FindAll(x => x > 80 ? true : false);

            foreach (var num in FilterList)
            {
                Console.WriteLine(num);
            }
        }

        private void Situation10()
        {
            int i = 0;
            int memlist, n, m;
            List<int> templist = new List<int>();

            n = Convert.ToInt32(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                Console.Write("Member {0} : ", i);
                memlist = Convert.ToInt32(Console.ReadLine());
                templist.Add(memlist);
            }

            m = Convert.ToInt32(Console.ReadLine());

            List<int> FilterList = templist.FindAll(x => x > m ? true : false);

            foreach (var num in FilterList)
            {
                Console.WriteLine(num);
            }
        }

        private void Situation11()
        {
            List<int> templist = new List<int>();
            templist.Add(5);
            templist.Add(7);
            templist.Add(13);
            templist.Add(24);
            templist.Add(6);
            templist.Add(9);
            templist.Add(8);
            templist.Add(7);

            foreach (var lstnum in templist)
            {
                Console.WriteLine(lstnum + " ");
            }

            int n = Convert.ToInt32(Console.ReadLine());

            templist.Sort();
            templist.Reverse();

            Console.Write("The top {0} records from the list are : \n", n);
            foreach (int topn in templist.Take(n))
            {
                Console.WriteLine(topn);
            }
        }
    }
}
