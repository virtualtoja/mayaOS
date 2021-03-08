using System;
using System.Collections.Generic;
using System.Text;

namespace mayaOS.AppHelper
{
    public static class Taskmanager
    {
        public static void EndProcess(int pid)
        {
            Process.Terminate(true, pid);
        }

        public static void StartProcess()
        {

        }
    }
}
