using System;
using System.Collections.Generic;
using System.Text;
using mayaOS.Applications;
using mayaOS.DiskManagement;

namespace mayaOS
{
    public static class CommandLine
    {
        public static Application currentApp;

        public static string workingDir = @"\";

        public static void CheckCommand(string command)
        {
            try
            {
                if (command == "crash")
                {
                    SystemManager.FatalError("TEST_CRASH", "Test crash");
                }
                else if (command == "diskpart")
                {
                    currentApp = new Diskpart();
                }
                else if (command.StartsWith("create"))
                {
                    string name = workingDir + command.Substring(7);
                    string content = command.Substring(7 + name.Length + 1);

                    DiskManager.CreateFile(name, content);
                }
                else if (command.StartsWith("cd"))
                {
                    string dir = command.Substring(3);

                    if (dir == "..")
                    {
                        workingDir = @"\" + workingDir.Substring(0, workingDir.Length - workingDir.Substring(workingDir.IndexOf(@"\")).Length);
                    }
                    else
                    {
                        workingDir += dir + @"\";
                    }
                }
                else if (command == "clear")
                {
                    Console.Clear();

                }
                else if(command.StartsWith("read"))
                {
                    Console.WriteLine(DiskManager.ReadFile(workingDir + command.Substring(5)));
                }
                else if(command == "dir")
                {
                    DiskManager.ListFiles("0", workingDir);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: ", e.ToString());
            }
        }

    }
}
