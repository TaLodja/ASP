using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesClass.Models;

namespace MoviesClass.Data
{
    public class MoviesClassContext : DbContext
    {
        public MoviesClassContext (DbContextOptions<MoviesClassContext> options)
            : base(options)
        {
        }

        public DbSet<MoviesClass.Models.Movie> Movie { get; set; } = default!;
    }
}
