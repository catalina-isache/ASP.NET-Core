using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ProiectContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SavedList> SavedLists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CategoryForPost> CategoryForPost { get; set; }

        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasOne(u => u.SavedList)
             .WithOne(sl => sl.User)
             .HasForeignKey<SavedList>(sl => sl.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoryForPost>()
           .HasKey(cp => new { cp.CategoryId, cp.PostId });

            modelBuilder.Entity<CategoryForPost>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryForPost)
                .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryForPost>()
                .HasOne(cp => cp.Post)
                .WithMany(p => p.CategoryForPost)
                .HasForeignKey(cp => cp.PostId);
            /*modelBuilder.Entity<CategoryForPost>()
                .HasOne(cfp => cfp.Post)
                .WithMany()
                .HasForeignKey(cfp => cfp.PostId)
                .OnDelete(DeleteBehavior.SetNull);
            */

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
