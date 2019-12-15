using Microsoft.EntityFrameworkCore;
using StudentPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPro.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<StudentEntity> students { get; set; }
    }
}
