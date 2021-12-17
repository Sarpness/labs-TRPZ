using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//singletone//
namespace lab9
{
    
    class CurCity
    {
        public City City { get; set; }

        
        public void getCity(int cityId)
        {
            City.getInstance(cityId);
        }
    }
    class City
    {
        private static City cur;

        public int id_ { get; private set; }
        public int cityId_ { get; set; }
        public string cityName_ { get; set; }
        public int count_ { get; set; }
        public DateTime update_at_ { get; set; }
        private static object syncRoot = new Object();

        public City(int cityId)
        {
            this.id_ = this.getID();
            this.cityId_ = cityId;
            this.cityName_ = this.findName(cityId);
            this.count_ = this.findCount(cityId);
            this.update_at_ = DateTime.Now;
        }

        public static City getInstance(int cityId)
        {
            if (cur == null)
            {
                lock (syncRoot)
                {
                    if (cur == null)
                        cur = new City(cityId);
                    return cur;
                }
            }
            return cur;
        }
        /*
        public static City getInstance(int cityId)
        {
            if (cur == null)
                cur = new City(cityId);
            return cur;
        }
        */
        int getID()
        {
            return 0;
        }

        string findName(int cityID)
        {
            string[] exCitys = new string[]{
                    "Киев",
                    "Харьков",
                    "Одесса",
                    "Днепр",
                    "Донецк",
                    "Запорожье",
                    "Львов",
                    "Кривой Рог",
                    "Николаев",
                    "Мариуполь"
            };

            if (cityID > 10 || cityID <0) return "newCity";
            return exCitys[cityID];
        }

        int findCount(int cityID)
        {
            int[] exCount = new int[]{
                2868702,
                1451132,
                1017022,
                1001094,
                949825,
                766268,
                729038,
                652137,
                494922,
                458533
            };
            if (cityID > 10 || cityID < 0) return 0;
            return exCount[cityID];
        }

        public void GetInfo()
        {
            Console.WriteLine("Город: {0}\n" +
                "население:{1}\n" +
                "Данные обновлены: {2}\n",
                cityName_, count_, update_at_);
        }
    }

   

}
