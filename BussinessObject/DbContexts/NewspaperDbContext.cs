using System;
using System.Reflection.Emit;
using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BussinessObject.DbContexts
{
	public class NewspaperDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public NewspaperDbContext()
		{
		}

		public NewspaperDbContext(DbContextOptions<NewspaperDbContext> options) : base(options)
		{
			Database.Migrate();
		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // rename AspNet table
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<Article>(article =>
            {
                article.ToTable("Articles");
            });

            builder.Entity<Comment>(comment =>
            {
                comment.ToTable("Comments");
                comment.HasOne(c => c.Article).WithMany(p => p.Comments).HasForeignKey(c => c.ArticleId);
            });

            builder.Seed();
        }
    }
}

