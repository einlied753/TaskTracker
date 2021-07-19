using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using TaskTracker.DAL.Models;

namespace TaskTracker.DAL
{
    public class Context : DbContext
    {
        public Context() : base("DbConnection") {
            Init();
        }

        protected virtual void Init()
        {
            //Database.SetInitializer<Context>(null);
            Database.SetInitializer(new TaskTrackerInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Task>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<Project>());
            modelBuilder.Configurations.Add(new EntityTypeConfiguration<User>());
        }
    }
}

