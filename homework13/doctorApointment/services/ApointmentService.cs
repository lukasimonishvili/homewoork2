using doctorApointment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace doctorApointment.services
{
    public static class ApointmentService
    {
        private static string filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/data";
        private static string JSONFileDirectory = filesDirectory + "/data.json";

        public static bool saveNewApointment(Apointment data)
        {
            var hours = Convert.ToInt32(data.Time.Split(":")[0]);

            if (hours < 10 || hours > 19)
            {
                return false;
            }
            else
            {
                var JSON = File.ReadAllText(JSONFileDirectory);
                List<Apointment> ApointemntList = JsonConvert.DeserializeObject<Apointment[]>(JSON).ToList();

                var newApointment = new Apointment();
                newApointment.FirstName = data.FirstName;
                newApointment.LastName = data.LastName;
                newApointment.Doctor = data.Doctor;
                newApointment.Time = data.Time;

                ApointemntList.Add(newApointment);
                File.WriteAllText(JSONFileDirectory, JsonConvert.SerializeObject(ApointemntList, Formatting.Indented));
                return true;
            }
        }

        public static Apointment[] getApointmentList()
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            return JsonConvert.DeserializeObject<Apointment[]>(JSON);
        }
    }
}
