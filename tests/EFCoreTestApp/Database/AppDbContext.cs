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


            // =========== 写到OnModelCreating方法最后 ===========

            //// PostgreSQL
            //modelBuilder.TableMappingToPostgreSQL((entityType) =>
            //{
            //    // 校验是否处理此实体
            //    return true;
            //});

            //// Oracle
            //modelBuilder.TableMappingToOracle((entityType) =>
            //{
            //    // 校验是否处理此实体
            //    return true;
            //});

            //// Devart Oracle
            //modelBuilder.TableMappingToDevartOracle((entityType) =>
            //{
            //    // 校验是否处理此实体
            //    return true;
            //});
        }
    }
}
