using Microsoft.EntityFrameworkCore;
using Statly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statly.Infrastructure.Data
{
    public class StatlyDbContext : DbContext
    {
        public StatlyDbContext(DbContextOptions<StatlyDbContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs => Set<Club>();
    }
}
