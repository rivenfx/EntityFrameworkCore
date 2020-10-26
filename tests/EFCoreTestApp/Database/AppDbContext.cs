using EFCoreTestApp.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTestApp.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SampleEntity> SampleEntitys { get; set; }
    }
}
