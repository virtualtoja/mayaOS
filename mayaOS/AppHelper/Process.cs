using System;
using System.Collections.Generic;
using System.Text;

namespace mayaOS.AppHelper
{
    public class Process
    {
        public bool sysProc;
        public string exec;
        public int PID;
        public bool running;

        public static List<Process> processes;

        public static int GeneratePid()
        {
            return processes.Count + 1;
        }

        public void RegisterProcess()
        {
            processes.Add(this);
        }

        public static void Terminate(bool permission, int PID)
        {
            for(int i = 0; i < processes.Count; i++)
            {
                if(processes[i].PID == PID) 
                {
                    if (processes[i].sysProc)
                        if (!permission)
                            return;

                    processes.RemoveAt(i); 
                }
            }
        }

    }
}
