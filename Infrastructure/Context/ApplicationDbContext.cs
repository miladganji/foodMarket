using Domain.Events;
using Domain.Food;
using Domain.Order;
using Domain.User;
using Infrastructure.configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        public DbSet<Food> tblFood { get; set; }
        public DbSet<Users> tblUser{ get; set; }
        public DbSet<Order> tblOrder{ get; set; }
        public DbSet<OrderLine> tblOrderLine { get; set; }
        public DbSet<Event>  events{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Foodconfiguration());
            modelBuilder.ApplyConfiguration(new Userconfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderLineconfiguration());
            //modelBuilder.ApplyConfiguration(new OrderLineconfiguration());

            






            base.OnModelCreating(modelBuilder);
        }

    }
}
