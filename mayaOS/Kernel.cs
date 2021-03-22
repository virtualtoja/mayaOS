using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using mayaOS.DiskManagement;
using mayaOS.UserManager;
using Cosmos.System.Graphics;

namespace mayaOS
{
    public class Kernel : Sys.Kernel
    {
        public static bool appRunning;
        public static string user;

        #region BeforeRun
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Starting mayaOS");
            Console.WriteLine("Starting FileSystem");
            DiskManager.RegisterFileSystem();
            Console.WriteLine("Done");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            UserManager.UserManager.InitUserManager();
            UserManager.UserManager.Login();
            Console.WriteLine("Welcome {0}", user);
        }
        #endregion

        void PrintPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(user);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{CommandLine.workingDir}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(">");

        }

        protected override void Run()
        {
            try
            {
                if (!appRunning)
                {
                    PrintPrompt();
                    string command = Console.ReadLine();
                    CommandLine.CheckCommand(command);
                }
                else
                {
                    CommandLine.currentApp.Update();
                }
            }
            catch(Exception e)
            {
                SystemManager.FatalError(e.GetType().ToString(), e.Message);
            }
        }
    }

    public static class SystemManager
    {
        public static void FatalError(string errorCode, string message)
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"fatal error with code {errorCode} message {message}");
            Console.WriteLine("");

            Console.ReadKey();

            Sys.Power.Reboot();
        }
    }
}
