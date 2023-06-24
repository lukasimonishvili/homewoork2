using BCryptNet = BCrypt.Net.BCrypt;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Mapster;

namespace API.Services
{
    public class RespodentService : RootService
    {
        public List<RespodentDTO> FetchAllRespodents()
        {
            return respodentContext.Respodents.Include(r => r.Address).Where(r => r.Role == Roles.User).ToList().Adapt<List<RespodentDTO>>();
        }

        public Respodent FetchRespodentById(int id)
        {
            return respodentContext.Respodents.Include(r => r.Address).FirstOrDefault(r => r.Id == id);
        }

        public RespodentDTO FetchRespodentByIdDto(int id)
        {
            var result = respodentContext.Respodents.Include(r => r.Address).FirstOrDefault(r => r.Id == id);
            return result.Adapt<RespodentDTO>();
        }

        public List<RespodentDTO> FilterRespodents(string firstName, string lastName, string jobPosition, string salary, string workExperience)
        {
            IQueryable<Respodent> query = respodentContext.Respodents.Include(r => r.Address);

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(r => r.FirstName.Contains(firstName));

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(r => r.LastName.Contains(lastName));

            if (!string.IsNullOrEmpty(jobPosition))
                query = query.Where(r => r.JobPosition.Contains(jobPosition));

            if (!string.IsNullOrEmpty(salary))
            {
                double salaryValue;
                if (double.TryParse(salary, out salaryValue))
                    query = query.Where(r => r.Salary >= salaryValue);
            }

            if (!string.IsNullOrEmpty(workExperience))
            {
                double workExperienceValue;
                if (double.TryParse(workExperience, out workExperienceValue))
                    query = query.Where(r => r.WorkExperience >= workExperienceValue);
            }

            List<RespodentDTO> filteredList = query.Where(r => r.Role == Roles.User).ToList().Adapt<List<RespodentDTO>>();
            return filteredList;
        }

        public List<RespodentDTO> DeleteRespodent(Respodent respodent)
        {
            respodentContext.Respodents.Remove(respodent);
            respodentContext.SaveChanges();

            return FetchAllRespodents();
        }

        public List<RespodentDTO> UpdateRespodent(Respodent oldRespodent, RespodentAutheDTO newRespodent)
        {
            if (oldRespodent.Password != newRespodent.Password)
            {
                newRespodent.Password = BCryptNet.HashPassword(newRespodent.Password);
            }
            respodentContext.Entry(oldRespodent).CurrentValues.SetValues(newRespodent);
            respodentContext.Entry(oldRespodent.Address).CurrentValues.SetValues(newRespodent.Address);
            respodentContext.SaveChanges();

            return FetchAllRespodents();
        }


    }
}
