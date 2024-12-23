using Drive.Data.Entities;
using System.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Drive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DriveDbContext GetDriveContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Drive"].ConnectionString)
                .Options;

            return new DriveDbContext(options);
        }
    }
}
