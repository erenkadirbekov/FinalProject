using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MilestoneProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilestoneProject.Data
{
    public class MyContext : IdentityDbContext<Users>
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }
        public new DbSet<Users> Users { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Belt> Belts { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<WeightCategory> WeightCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Fighter>()
                .HasOne(f => f.weightCategory)
                .WithMany(w => w.fighters)
                .HasForeignKey(f => f.weightCategoryId);

            modelBuilder.Entity<FightsAndFighters>()
            .HasOne(f => f.fight)
            .WithMany(ff => ff.fightsAndFighters)
            .HasForeignKey(f => f.fightId);

            modelBuilder.Entity<FightsAndFighters>()
                .HasOne(f => f.fighter)
                .WithMany(ff => ff.fightsAndFighters)
                .HasForeignKey(pt => pt.fighterId);

            modelBuilder.Entity<Fight>()
                .HasOne(f => f.weightCategory)
                .WithMany(w => w.fights)
                .HasForeignKey(f => f.weightCategoryId);

            modelBuilder.Entity<Fight>()
                .HasOne(f => f.tournament)
                .WithMany(t => t.fights)
                .HasForeignKey(f => f.tournamentId);

            modelBuilder.Entity<Belt>()
                .HasOne<Fighter>(b => b.owner)
                .WithOne(f => f.belt)
                .HasForeignKey<Belt>(b => b.fighterId);

        }

        public DbSet<MilestoneProject.Models.FightsAndFighters> Fights_And_Fighters { get; set; }
    }
}
