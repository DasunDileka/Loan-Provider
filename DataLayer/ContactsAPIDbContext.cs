using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ContactsAPIDbContext:DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Product> Product{ get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Loan> Loan { get; set; }

    }
}
