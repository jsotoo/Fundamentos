using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace AppProject.Modules.Tasks.Types
{
    public class AsyncAndAwait : ModuleBase, IModule
    {
        private IPrint _printer;

        public AsyncAndAwait() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            //AsynchronousMethod();
            //TaskRun();
            //ContinueWith();
            //Background();
            HandleSuccessAndFailure();
        }

        #region [ASYNCHRONOUS METHOD]

        private void AsynchronousMethod()
        {
            // Part 1: start the HandleFile method.
            Task<int> task = HandleFileAsync();

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            _printer.Print("Please wait patiently " +
                    "while I do something important.");

            // Do something at the same time as the file is being read.
            string line = Console.ReadLine();
            _printer.Print("You entered (asynchronous logic): " + line);

            // Part 3: wait for the HandleFile task to complete.
            // ... Display its results.
            task.Wait();
            var x = task.Result;
            _printer.Print("Count: " + x);
            _printer.Print("[DONE]");
        }

        private static async Task<int> HandleFileAsync()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string file = @"Modules\\Tasks\\Resources\\File1.txt";
            string fileFullPath = Path.Combine(appPath + file);

            // Part 2: status messages and long-running calculations.
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader(fileFullPath))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 100000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }

        #endregion

        #region [TASK.RUN]

        private void TaskRun()
        {
            while (true)
            {
                // Start computation.
                ComputeStart();
                // Handle user input.
                string result = Console.ReadLine();
                Console.WriteLine("You typed: " + result);
            }
        }
        private static async void ComputeStart()
        {
            // This method runs asynchronously.
            int t = await Task.Run(() => Allocate());
            Console.WriteLine("Compute: " + t + 1);
        }

        private static int Allocate()
        {
            // Compute total count of digits in strings.
            int size = 0;
            for (int z = 0; z < 100; z++)
            {
                for (int i = 0; i < 1000; i++)
                {
                    string value = i.ToString();
                    size += value.Length;
                }
            }
            return size;
        }

        #endregion

        #region [CONTINUE WITH]
        private void ContinueWith()
        {
            // Call async method 10 times.
            for (int i = 0; i < 10; i++)
            {
                Run2Methods(i);
            }
            // The calls are all asynchronous, so they can end at any time.
            Console.ReadLine();
        }

        static async void Run2Methods(int count)
        {
            // Run a Task that calls a method, then calls another method with ContinueWith.
            int result = await Task.Run(() => GetSum(count))
                .ContinueWith(x => MultiplyNegative1(x));
            Console.WriteLine("Run2Methods result: " + result);
        }

        private static int GetSum(int count)
        {
            // This method is called first, and returns an int.
            return count + 1;
        }

        private static int MultiplyNegative1(Task<int> task)
        {
            // This method is called second, and returns a negative int.
            return task.Result * -1;
        }

        #endregion

        #region [BACKGROUND METHOD]

        private void Background()
        {
            // Run a Task in the background.
            BackgroundMethod();
            // Run this loop in Main at the same time.
            for (int i = 0; i < 30; i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("::Main::");
            }
        }

        private async static void BackgroundMethod()
        {
            // Use a local function.
            void InnerMethod()
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(150);
                    Console.WriteLine("::Background::");
                }
            }
            // Create a new Task and start it.
            // ... Call the local function.
            var task = new Task(() => InnerMethod());
            task.Start();
            await task;
        }

        #endregion

        #region [HANDLE SUCCESS AND FAILURE]

        private void HandleSuccessAndFailure()
        {
            var loadLinesTask = Task.Run(() =>
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string file = @"Modules\\Tasks\\Resources\\File1.txt";
                string fileFullPath = Path.Combine(appPath, file);

                var lines = File.ReadAllLines(fileFullPath);

                return lines;
            });

            var processLines = loadLinesTask.ContinueWith(t =>
            {
                var lines = t.Result;
                Console.WriteLine("The file lines were received");
                
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            processLines.ContinueWith(t =>
            {
                Console.WriteLine("Something is wrong");
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        #endregion
    }
}
