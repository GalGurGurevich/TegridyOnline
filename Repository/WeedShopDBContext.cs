using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WeedShopDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Weed> WeedProducts { get; set; }
    }
}
