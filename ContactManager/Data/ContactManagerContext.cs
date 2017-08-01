using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Models
{
    public class ContactManagerContext : DbContext
    {
        public ContactManagerContext (DbContextOptions<ContactManagerContext> options)
            : base(options)
        {
        }

        public DbSet<ContactManager.Models.Company> Company { get; set; }

        public DbSet<ContactManager.Models.Person> Person { get; set; }
    }
}
