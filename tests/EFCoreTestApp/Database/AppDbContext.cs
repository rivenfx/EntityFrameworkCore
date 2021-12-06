using EFCoreTestApp.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // =========== д��OnModelCreating������� ===========

            //// PostgreSQL
            //modelBuilder.TableMappingToPostgreSQL((entityType) =>
            //{
            //    // У���Ƿ����ʵ��
            //    return true;
            //});

            //// Oracle
            //modelBuilder.TableMappingToOracle((entityType) =>
            //{
            //    // У���Ƿ����ʵ��
            //    return true;
            //});

            //// Devart Oracle
            //modelBuilder.TableMappingToDevartOracle((entityType) =>
            //{
            //    // У���Ƿ����ʵ��
            //    return true;
            //});
        }
    }
}
