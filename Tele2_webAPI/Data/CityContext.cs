using Microsoft.EntityFrameworkCore;
using Tele2_webAPI.Models;

namespace Tele2_webAPI.Data
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions<CityContext> opt) : base(opt)
        {

        }

        public DbSet<Citizen> City { get; set; }
    }
}