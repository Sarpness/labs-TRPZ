using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{

    interface ICommand
    {
        User UpPriv(User cur, string name);
        User DownPriv(User cur, string name);
    }

    class AdminCommand
    {

        public User upUser(User cur, string name)
        {
            //Состояние (State)
            if (cur.Status == UserStatus.Visitor)
            {
                cur = new Employer(name);
                cur.Status = UserStatus.Employer;
            }
            else if (cur.Status == UserStatus.Employer)
            {
                cur = new Admin(name);
                cur.Status = UserStatus.Admin;
            }
            else if (cur.Status == UserStatus.Admin)
            {
                cur = new Boss(name);
                cur.Status = UserStatus.Boss;
            }
            else Console.WriteLine("max priv\n");
            
            return cur;
        }

        public User downUser(User cur, string name)
        {
            if (cur.Status == UserStatus.Boss)
            {
                cur = new Admin(name);
                cur.Status = UserStatus.Admin;
            }
            else if (cur.Status == UserStatus.Admin)
            {
                cur = new Employer(name);
                cur.Status = UserStatus.Employer;
            }
            else if (cur.Status == UserStatus.Employer)
            {
                cur = new Visitor(name);
                cur.Status = UserStatus.Visitor;
            }
            else Console.WriteLine("min priv\n");
            return cur;
        }

    }

    // Invoker - инициатор

    class AdminPanel
    {
        ICommand command;

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public User setUp(User cur, string name)
        {
            return command.UpPriv(cur, name);
        }
        public User setDown(User cur, string name)
        {
            return command.DownPriv(cur, name);
        }
    }

    class PanelCommand : ICommand
    {
        AdminCommand adminCommand;

        public PanelCommand(AdminCommand adminCommandSet)
        {
            adminCommand = adminCommandSet;
        }

        public User UpPriv(User cur, string name)
        {
            return adminCommand.upUser(cur, name);
        }
        public User DownPriv(User cur, string name)
        {
            return adminCommand.downUser(cur, name);
        }
    }
}
