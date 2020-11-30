using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TechCodeLib.DAL.Entities;

namespace TechCodeLib.DAL
{
    public class TechCodeLibContext : DbContext
    {
        public TechCodeLibContext()
        {

        }
        public TechCodeLibContext(DbContextOptions<TechCodeLibContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=TechCodeLibDb;Integrated Security=True");
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ContentLevel> ContentLevels { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Section> Sections { get; set; }
        
        public DbSet<Video> Videos { get; set; }
        public DbSet<Language> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            

            modelBuilder.Entity<Language>()
                .HasData(new Language { Id = 1, Name = "English" }, new Language { Id = 2, Name = "Hindi" });

            modelBuilder.Entity<Subject>()
                .HasData(new Subject { Id = 1, Name = "C# .Net", ParentSubjectId = null });

            modelBuilder.Entity<ContentLevel>()
                .HasData(
                new ContentLevel { Id = 1, Name = "Basic", Description = "Basic/Beginer's Level for content" },
                new ContentLevel { Id = 2, Name = "Intermediate", Description = "Intermediate Level for content" },
                new ContentLevel { Id = 3, Name = "Advance", Description = "Advanced Level for content" },
                new ContentLevel { Id = 4, Name = "Professional", Description = "Professional Level for content" });

            modelBuilder.Entity<AppUser>()
                .HasData(
                new AppUser { Id = 1, FirstName = "Nitin", LastName = "Rastogi", Email = "nitin.rastogi@live.in", ContactNo = "2173438626", Password = "Test@123" }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                new Course
                {
                    Id = 1,
                    ContentLevelId = 1,
                    Name = "C# Beginer's Course",
                    Description = "A very easy introductory course in C# for beginners.",
                    IsActive = true,
                    LanguageId = 1,
                    Tags = "C#, .Net",
                    CreatedOn = DateTime.Now,
                    AppUserId = 1,
                    SubjectId=1,
                    CourseDuration=190
                },
                new Course
                {
                    Id = 2,
                    ContentLevelId = 2,
                    Name = "C# Intermediate Course with Windows Application Project",
                    Description = "C# Intermediate Course with Windows Application Project",
                    IsActive = true,
                    LanguageId = 1,
                    Tags = "C#, .Net, Winform",
                    CreatedOn = DateTime.Now,
                    AppUserId = 1,
                    SubjectId = 1,
                    CourseDuration = 180
                });

            modelBuilder.Entity<Section>()
                .HasData(
                new Section { Id = 1, Description = "Introduction", Duration = 1, Name = "Introduction", CourseId = 1 },
                new Section { Id = 2, Description = "Introduction", Duration = 1, Name = "Introduction", CourseId = 2 },
                new Section { Id = 3, Description = "OOP Programming", Duration = 1, Name = "OOP Programming", CourseId = 2 });

            modelBuilder.Entity<Video>()
                .HasData(
                new Video { Id = 1, Name = "Introduction to C# and .Net Framework", Description = "Introduction to C# and .Net Framework", AppUserId = 1, EmbedLink = "", CreatedOn = DateTime.Now, IsActive = true, SectionId = 1, Length = 10.25m, Rating = 1, Tags = "C#, .Net Framework" },
                new Video { Id = 3, Name = "Introduction to C# and .Net Framework", Description = "Introduction to C# and .Net Framework", AppUserId = 1, EmbedLink = "", CreatedOn = DateTime.Now, IsActive = true, SectionId = 1, Length = 10.25m, Rating = 1, Tags = "C#, .Net Framework" },
                new Video { Id = 4, Name = "OOP In Detail", Description = "OOP In Detail", AppUserId = 1, EmbedLink = "", CreatedOn = DateTime.Now, IsActive = true, SectionId = 3, Length = 10.25m, Rating = 1, Tags = "C#, OOP" });

            modelBuilder.Entity<Video>()
               .HasData(
               new Video { Id = 2, Name = "C# Data Type", Description = "C# Data Type", AppUserId = 1, EmbedLink = "", CreatedOn = DateTime.Now, IsActive = true, SectionId = 3, Length = 15.25m, Rating = 1, Tags = "C#, .Net Framework" });

            

            
        }
    }
}
