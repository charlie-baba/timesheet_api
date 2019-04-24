using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace timesheet.data
{
    public class TimesheetContextFactory : IDesignTimeDbContextFactory<TimesheetDb>
    {
        public TimesheetDb CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TimesheetDb>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TimesheetDbConnection"));

            return new TimesheetDb(optionsBuilder.Options);
        }
    }
}
