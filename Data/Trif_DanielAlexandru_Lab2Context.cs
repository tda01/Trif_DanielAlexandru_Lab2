using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trif_DanielAlexandru_Lab2.Models;

namespace Trif_DanielAlexandru_Lab2.Data
{
    public class Trif_DanielAlexandru_Lab2Context : DbContext
    {
        public Trif_DanielAlexandru_Lab2Context (DbContextOptions<Trif_DanielAlexandru_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Trif_DanielAlexandru_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Trif_DanielAlexandru_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Trif_DanielAlexandru_Lab2.Models.Author>? Author { get; set; }
    }
}
