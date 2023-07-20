using System.Collections.Generic;
using System.Data;
using BussinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions
{
    public static class NewspaperInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            var Hasher = new PasswordHasher<User>();

            var Categories = new Category[]
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Thể Thao",
                    UrlSlug = "the-thao",
                    Description = "",
                }
            };

            var Users = new User[]
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Admin",
                    LastName = "System",
                    BirthDate = new DateTime(2001,2,3),
                    About = "Nothing to say",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = Hasher.HashPassword(null, "Matkhau1234!")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Writer",
                    LastName = "System",
                    BirthDate = new DateTime(2001,3,4),
                    About = "Nothing to say",
                    UserName = "writer",
                    NormalizedUserName = "WRITER",
                    Email = "writer@localhost.com",
                    NormalizedEmail = "WRITER@LOCALHOST.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = Hasher.HashPassword(null, "Matkhau1234!")
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "User",
                    LastName = "System",
                    BirthDate = new DateTime(2001,5,6),
                    About = "Nothing to say",
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = Hasher.HashPassword(null, "Matkhau1234!")
                },
            };

            List<Article> Articles = new List<Article>
            {
                new Article
                {
                    Id = Guid.NewGuid(),
                    Title = "Thủ quân New Zealand ngạc nhiên khi Việt Nam phòng ngự sâus",
                    UrlSlug = "thu-quan-new-zealand-ngac-nhien-khi-viet-nam-phong-ngu-sau",
                    ShortDescription = "Tiền vệ phòng ngự Ria Percival, hiện khoác áo CLB nữ Tottenham, bất ngờ trước việc Việt Nam chơi phòng ngự lùi sâu trong trận giao hữu với New Zealand hôm nay",
                    ArticleContent = "Trước trận đấu trên sân McLean Park (thành phố Napier), New Zealand đã dự đoán Việt Nam sẽ chơi phòng ngự. HLV Jitka Klimkova còn hy vọng được chứng kiến khả năng tổ chức hàng thủ của Việt Nam, với đội hình lùi sâu và kèm người chặt chẽ. Bà và các học trò vốn bị ấn tượng bởi màn trình diễn của Việt Nam trong trận thua 1-2 trên sân của số hai thế giới Đức.",
                    IsPublished = true,
                    ViewCount = 1413,
                    PostedOn = new DateTime(2023, 6, 1),
                    UserId = Users[1].Id
                }
            };


            List<Comment> Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    ArticleId = Articles.ElementAt(0).Id,
                    UserId = Users[2].Id,
                    CommentHeader = "Nói chung là chán!",
                    CommentText = "Cả trận không cú sút trúng khung thành, không có nổi 1 trái phạt góc.",
                    CommentTime = DateTime.Now
                }
            };

            var Roles = new IdentityRole<Guid>[]
            {
               new IdentityRole<Guid>
               {
                   Id = Guid.NewGuid(),
                   Name = "Admin",
                   NormalizedName = "ADMIN"
               },
               new IdentityRole<Guid>
               {
                   Id = Guid.NewGuid(),
                   Name = "Writer",
                   NormalizedName = "WRITER"
               },
               new IdentityRole<Guid>
               {
                   Id = Guid.NewGuid(),
                   Name = "User",
                   NormalizedName = "USER"
               }
            };


            var UserRoles = new IdentityUserRole<Guid>[]
            {
                new IdentityUserRole<Guid>
                {
                    RoleId = Roles[0].Id,
                    UserId = Users[0].Id
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Roles[1].Id,
                    UserId = Users[1].Id
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Roles[2].Id,
                    UserId = Users[2].Id
                }
            };
            var ArticleCategories = new ArticleCategory[]
            {
                new ArticleCategory
                {
                    ArticleId = Articles[0].Id,
                    CategoryId = Categories[0].Id
                }
            };

            builder.Entity<Article>().HasData(Articles);
            builder.Entity<Category>().HasData(Categories);
            builder.Entity<Comment>().HasData(Comments);
            builder.Entity<IdentityRole<Guid>>().HasData(Roles);
            builder.Entity<User>().HasData(Users);
            builder.Entity<IdentityUserRole<Guid>>().HasData(UserRoles);
            builder.Entity<ArticleCategory>().HasData(ArticleCategories);
        }
    }
}