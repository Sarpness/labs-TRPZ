//Facade//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    internal class Task
    {
        public int id { get; set; }
        public int idCity { get; set; }
        public int curStatus { get; set; }
        public DateTime created_at { get; set; }

        public Task(int idCity, int curStatus)
        {
            this.id = 0;
            this.idCity = idCity;
            this.curStatus = curStatus;
            this.created_at = DateTime.Now;
        }
        public void GetTask()
        {
            Console.WriteLine("Задание №{0}\n" +
                "Статус задания: {1}\n", this.id + 1, this.curStatus);
        }
    }

    class WorkFacade
    {
        Task task;
        City city;
        public WorkFacade(Task curT, City curC)
        {
            this.task = curT;
            this.city = curC;
        }
        public void Show()
        {
            task.GetTask();
            city.GetInfo();
        }

        public void Edit()
        {
            Console.WriteLine("введите количество населения в городе {0}", this.city.cityName_);
            this.city.count_ = Convert.ToInt32(Console.ReadLine());
            this.city.update_at_ = DateTime.Now;
            Console.WriteLine("введите статус задания: ");
            this.task.curStatus = Convert.ToInt32(Console.ReadLine());

        }
        public void Safe()
        {
            Console.WriteLine("Данные сохранены");
        }
    }

    class ShowTask
    {
        public void ActionTask(WorkFacade facade)
        {
            facade.Show();

            facade.Edit();

            facade.Show();
            facade.Safe();
        }
    }
}
