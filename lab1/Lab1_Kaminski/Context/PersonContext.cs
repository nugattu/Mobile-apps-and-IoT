using Lab1_Kaminski.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Lab1_Kaminski.Context
{
    public class PersonContext :DbContext
    {
       public static string password = "zaq1@WSX";
       
        private readonly string _connectionString = "Server=tcp:tkaminski-cdv.database.windows.net,1433;Initial Catalog=tkaminski_cdv;Persist Security Info=False;User ID=tkaminski;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
