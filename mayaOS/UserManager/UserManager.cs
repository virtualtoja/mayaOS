using System;
using System.Collections.Generic;
using System.Text;

namespace mayaOS.UserManager
{
    public class UserManager
    {
        private static List<User> users = new List<User>();

        public static void Login()
        {
            Console.Write("login: ");
            string login = Console.ReadLine();
            Console.Write("pass: ");
            string password = Console.ReadLine();

            foreach(User usr in users)
            {
                if(usr.name == login)
                {
                    if(usr.password == password)
                    {
                        Kernel.user = usr.name;
                    }
                }
            }
            Console.Clear();
        }

        public static void InitUserManager()
        {
            users.Add(new User { name = "root", password = "1234" });
            users.Add(new User { name = "testuser", password = "1234" });
        }
    }
}
