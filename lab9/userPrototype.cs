using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    abstract class User
    {
        public string Name { get; set; }
        public UserStatus Status { get; set; }

        public User(string n)
        {
            Name = n;
            Status = UserStatus.Visitor;
        }
        // фабричный метод
        abstract public UserAction Create();
    }

    enum UserStatus
    {
        Visitor,
        Employer,
        Admin,
        Boss
    }

    class Visitor : User
    {
        public Visitor(string n) : base(n)
        { }

        public override UserAction Create()
        {
            return new ShowCityesList();
        }
    }
    class Admin : User
    {
        public Admin(string n) : base(n)
        { }

        public override UserAction Create()
        {
            return new AddEmployer();
        }
    }

    class Employer : User
    {
        public Employer(string n) : base(n)
        { }

        public override UserAction Create()
        {
            return new CompleatTicket();
        }
    }

    class Boss : User
    {
        public Task task;
        public Boss(string n) : base(n)
        { }

        public override UserAction Create()
        {
            return new CreateTask(task);
        }

    }

    abstract class UserAction
    { }

    class ShowCityesList : UserAction
    {
        public ShowCityesList()
        {
            Console.WriteLine("Список отображен\n");
        }
    }
    class AddEmployer : UserAction
    {
        public AddEmployer()
        {
            Console.WriteLine("Пользователь добавлен\n");
        }
    }
    class CompleatTicket : UserAction
    {
        public CompleatTicket()
        {
            Console.WriteLine("Задание выполнено\n");
        }
    }

    class CreateTask : UserAction
    {
        public CreateTask(Task task)
        {
            Console.WriteLine("Введите id города");
            int curIdCity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите статус задания: ");
            int curStatus = Convert.ToInt32(Console.ReadLine());
            task = new Task(curIdCity, curStatus);

        }
    }
}
