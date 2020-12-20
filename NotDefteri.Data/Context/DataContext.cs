using NotDefteri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}

        public DbSet<Category>Categories { get; set; }

        public DbSet<Note>Notes  { get; set; }

        public DbSet<User>Users { get; set; }

        public DbSet<Like> Likes { get; set; }

    }
}
