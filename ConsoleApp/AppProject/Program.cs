using AppProject.Modules;
using System;


namespace AppProject
{
    public delegate void InitModule();
    class Program
    {
        static void Main(string[] args)
        {
            // Recommended Modules order
            // 1. Fundamentals
            // 2. Lambda
            // 3. Delegates
            // 4. TaskParallel

            #region [Fundamentals]

            using (var module = new Fundamentals())
            {
                module.Init();
            }

            #endregion

            #region [Lambda]

            //using (var module = new Lambda())
            //{
            //    module.Init();
            //}

            #endregion

            #region [TaskParallel]

            //using (var module = new BasicTasks())
            //{
            //    module.Init();
            //}

            #endregion

            #region [Delegates]

            //using (var module = new BasicDelegates())
            //{
            //    module.Init();
            //}

            #endregion

            #region [LinQ]

            //using (var module = new BasicLinQ())
            //{
            //    module.Init();
            //}

            #endregion

            #region [Files]

            //using (var module = new BasicFiles())
            //{
            //    module.Init();
            //}

            #endregion

            #region [Identity]

            //using (var module = new Identity())
            //{
            //    module.Init();
            //}

            #endregion

            #region [Serialization]

            //using (var module = new BasicSerialization())
            //{
            //    module.Init();
            //}

            #endregion

            #region [Events]

            using (var module = new BasicEvents())
            {
                module.Init();
            }

            #endregion

            Console.ReadLine();
        }
    }
}
