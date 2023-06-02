using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace JSONMagic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            calculateDayCountBeforeBirthday();
        }

        static void calculateDayCountBeforeBirthday()
        {
            var filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/files"; // folder directory
            var JSONFileDirectory = filesDirectory + "/data.json"; // actual file directory
            var JSON = File.ReadAllText(JSONFileDirectory);
            JsonDataObject jsonDataObject = JsonConvert.DeserializeObject<JsonDataObject>(JSON);
            DateTime currentDate = Convert.ToDateTime(jsonDataObject.currentDate);
            DateTime birthDay = Convert.ToDateTime(jsonDataObject.birthDay);
            DateTime currentYearBirthday = new DateTime(currentDate.Year, birthDay.Month, birthDay.Day);
            var CurrentYearBirthdaytimeGap = (currentDate - currentYearBirthday).Days;

            if (CurrentYearBirthdaytimeGap == 0)
            {
                Console.WriteLine("Happy birthday");
            }
            else if (CurrentYearBirthdaytimeGap > 0)
            {
                Console.WriteLine($"{CurrentYearBirthdaytimeGap} days left before birthday");
            }
            else
            {

                Console.WriteLine($"{365 + CurrentYearBirthdaytimeGap} days left before birthday");
            }
        }
    }

    internal class JsonDataObject
    {
        public string currentDate { get; set; }
        public string birthDay { get; set; }
    }
}