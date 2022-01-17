using System.Collections.Generic;
using Tele2_webAPI.Models;

namespace Tele2_webAPI.Data
{
    public interface ICityRepo
    {
        bool SaveChanges();

        IEnumerable<Citizen> GetCitizens();
        Citizen GetCitizentById(string code);
        void SettleCitizents();
        IEnumerable<Citizen> GetCitizensByParams(string sex = null, int lowAge = -1, int upAge = -1, int pageNum = -1, int pageSize = -1);
    }
}
