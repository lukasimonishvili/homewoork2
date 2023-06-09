using homework14.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace homework14.services
{
    public static class RespodentService
    {
        private static string filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0] + "/data";
        private static string JSONFileDirectory = filesDirectory + "/respodents.json";

        public static List<Respodent> CreateNewRespodent(Respodent respodent)
        {
            var uniqueId = Guid.NewGuid().ToString();
            respodent.Id = uniqueId;
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            respodents.Add(respodent);
            File.WriteAllText(JSONFileDirectory, JsonConvert.SerializeObject(respodents, Formatting.Indented));
            return respodents;
        }

        public static List<Respodent> GetAllRespodents()
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            return respodents;
        }

        public static Respodent GetRespodentById(string id)
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            return respodents.Where(x => x.Id == id).FirstOrDefault();
        }

        public static List<Respodent> FilterRespodents(string firstName, string lastName, string jobPosition, string salary, string workExperience)
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);

            List<Respodent> filteredRespodents = respodents;

            if (!string.IsNullOrEmpty(firstName))
            {
                filteredRespodents = filteredRespodents
                    .Where(respodent => respodent.FirstName == firstName)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                filteredRespodents = filteredRespodents
                    .Where(respodent => respodent.LastName == lastName)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(jobPosition))
            {
                filteredRespodents = filteredRespodents
                    .Where(respodent => respodent.JobPosition == jobPosition)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(salary))
            {
                filteredRespodents = filteredRespodents
                    .Where(respodent => respodent.Salary.ToString() == salary)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(workExperience))
            {
                filteredRespodents = filteredRespodents
                    .Where(respodent => respodent.WorkExperience.ToString() == workExperience)
                    .ToList();
            }

            return filteredRespodents;
        }

        public static Respodent UpdateRespodent(Respodent respodent, string id)
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            var index = FindIndexById(id);
            respodents[index] = respodent;
            respodents[index].Id = id;
            File.WriteAllText(JSONFileDirectory, JsonConvert.SerializeObject(respodents, Formatting.Indented));
            return respodents[index];
        }

        public static List<Respodent> DeleteRespodent(string id)
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            var index = FindIndexById(id);
            respodents.RemoveAt(index);
            File.WriteAllText(JSONFileDirectory, JsonConvert.SerializeObject(respodents, Formatting.Indented));
            return respodents;
        }

        public static int FindIndexById(string id)
        {
            var JSON = File.ReadAllText(JSONFileDirectory);
            List<Respodent> respodents = JsonConvert.DeserializeObject<List<Respodent>>(JSON);
            var index = respodents.FindIndex(x => x.Id == id);
            return index;
        }
    }
}
