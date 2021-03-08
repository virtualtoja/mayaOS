using System;
using System.Collections.Generic;
using System.Text;
using mayaOS.AppHelper;

namespace mayaOS.Applications
{
    public class Application : Process
    {
        public string name;
        public string execPath;
        
        public Application(string Name)
        {
            name = Name;

            Start();
        }

        public void Start()
        {
            sysProc = false;
            PID = GeneratePid();
            exec = execPath;
            RegisterProcess();
            Kernel.appRunning = true;
        }

        public virtual void Update() { }

        public void Close()
        {
            Terminate(false, PID);
            Kernel.appRunning = false;
        }

        public void ForceQuit()
        {
            Terminate(true, PID);
            Kernel.appRunning = false;
        }
    }
}
