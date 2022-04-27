using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAlura.Model;

namespace WebApiAlura.Data
{
    public class NinjaContext : DbContext
    {
        public NinjaContext(DbContextOptions<NinjaContext> opt) : base(opt)
        {

        }

        public DbSet<Ninja> Ninjas { get; set; }
    }
}
