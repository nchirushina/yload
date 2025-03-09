using Microsoft.EntityFrameworkCore;
using MyYTLoader.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyYTLoader.DAL
{
    public class LoaderContext : DbContext
    {
        public DbSet<VideoEntity> Videos { get; set; }

        public LoaderContext(DbContextOptions<LoaderContext> options)
        : base(options)
        {
           // Database.EnsureCreated();
        }
/*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=yload.ru;Port=5432;Database=postgres;Username=yuser;Password=iL0veMyJ0b?!");
        }*/
    }
}
