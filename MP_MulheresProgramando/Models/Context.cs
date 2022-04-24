using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MP_MulheresProgramando.Models
{
    public class Context : DbContext
    {
        public DbSet<Linguagem> Linguagens { get; set; }

        public DbSet<Programadora> Programadoras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MPDb;Integrated Security=True");
        }
    }
}
