using System;
using System.Reflection.Emit;
using DataAccess.Extensions;
using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
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
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                string? tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<Article>(article =>
            {
                article.ToTable("Articles");
                article.HasKey(a => a.Id);
                article.HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId);
                article.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);
                article.Property(a => a.ShortDescription)
                .IsRequired()
                .HasMaxLength(1000);
                article.Property(a => a.ArticleContent)
                .IsRequired()
                .HasMaxLength(5000);
            });

            builder.Entity<Comment>(comment =>
            {
                comment.ToTable("Comments");
                comment.HasKey(c => c.Id);
                comment.HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId);
                comment.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);
            });

            builder.Entity<Category>(category =>
            {
                category.ToTable("Categories");
                category.HasKey(a => a.Id);
            });

            builder.Entity<ArticleCategory>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.CategoryId });
                entity.HasOne(e => e.Article)
                .WithMany(e => e.ArticleCategories)
                .HasForeignKey(e => e.ArticleId);
                entity.HasOne(e => e.Category)
                .WithMany(e => e.ArticleCategories)
                .HasForeignKey(e => e.CategoryId);
            });

            builder.Seed();
        }
    }
}

