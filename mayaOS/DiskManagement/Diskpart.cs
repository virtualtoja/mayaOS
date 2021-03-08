using System;
using mayaOS.Applications;

namespace mayaOS.DiskManagement
{
    public class Diskpart : Application
    {
        private string selectedDriveId;

        public Diskpart() : base("diskpart") { this.execPath = "bulitin"; }

        public override void Update()
        {
            Console.Write("diskpart>");
            string command = Console.ReadLine();
            Command(command);
        }

        public void Command(string command)
        {
            try 
            {
                if (command.StartsWith("select"))
                {
                    string id = command.Substring(7);
                    SelectDrive(id);
                }
                else if (command == "format")
                {
                    Format();
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error ocured while running that operation. {0}", e.ToString());
            }
        }

        void Format()
        {
            Console.WriteLine("Formatting drive {0}...", selectedDriveId);
            DiskManager.Format(selectedDriveId);
            Console.WriteLine("Succesfully formatted drive {0}.", selectedDriveId);
        }

        public void SelectDrive(string id)
        {
            selectedDriveId = id + ":/";
            Console.WriteLine("Selected drive {0}", id);
        }
        
    }
}
