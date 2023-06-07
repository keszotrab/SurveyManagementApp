using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Infrastructure.EF.Entities;
using Infrastructure.Utility;

namespace Infrastructure
{
    public class SurveysDbContext : IdentityDbContext<UsersEntity, UserRoleEntity, int>
    {
        public DbSet<AlreadyAnswerdEntity> AlreadyAnswerd { get; set; }
        public DbSet<ClosedUserAnswersEntity> ClosedUserAnswers { get; set; }
        public DbSet<DomainCheckEntity> DomainCheck { get; set; }
        public DbSet<OpenUserAnswersEntity> OpenUserAnswers { get; set; }
        public DbSet<AnswersEntity> Answers { get; set; }
        public DbSet<QuestionsEntity> Questions { get; set; }
        public DbSet<SurveysEntity> Surveys { get; set; }
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRole { get; set; }


        public SurveysDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "DATA SOURCE=BARTEK-KOMPUTER\\SQLEXPRESS;DATABASE=SurveysDbA1;Integrated Security=true;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoleEntity>().HasData(new UserRoleEntity
            {
                Id = 1,
                Name = "User",
                NormalizedName = "USER".ToUpper()

            });
            modelBuilder.Entity<UserRoleEntity>().HasData(new UserRoleEntity
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN".ToUpper()
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 1
            });

            modelBuilder.Entity<ClosedUserAnswersEntity>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<OpenUserAnswersEntity>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AlreadyAnswerdEntity>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SurveysEntity>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(e => e.AuthorId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);





            /////              /////
            //   Add data below  //
            /////             /////

            modelBuilder.Entity<UsersEntity>()
            .HasData(
                new UsersEntity()
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin@admin.adm",
                    PasswordHash = "Admin123@",
                    Salt = "3KmnGpckunC7RrOt/lRQYg==",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new UsersEntity()
                {
                    Id = 2,
                    UserName = "client",
                    Email = "client@client.cli",
                    PasswordHash = "RK9wNvXKYruqOaVsZ38Uew==",
                    Salt = "06AA267858EA0A0E227984B83434FEE818F4CB622D13051FF07229279E281EB5",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
                );

            modelBuilder.Entity<SurveysEntity>()
            .HasData(
                new SurveysEntity()
                {
                    Id = 1,
                    Name = "testSurvey",
                    AuthorId = 1,
                    Type = "public"
                }
            );




            modelBuilder.Entity<QuestionsEntity>()
            .HasData(
                new QuestionsEntity()
                {
                    Id = 1,
                    SurveysId = 1,
                    Question = "Ile to 2+2?"
                },
                new QuestionsEntity()
                {
                    Id = 2,
                    SurveysId = 1,
                    Question = "Kto założył Apple?"
                }
            );



            modelBuilder.Entity<AnswersEntity>()
               .HasData(
                   new AnswersEntity()
                   {
                       Id = 1,
                       QuestionId = 1,
                       Answer = "4",
                       AnswerType = "Closed",
                   },
                   new AnswersEntity()
                   {
                       Id = 2,
                       QuestionId = 1,
                       Answer = "7",
                       AnswerType = "Closed"
                   },
                   new AnswersEntity()
                   {
                       Id = 3,
                       QuestionId = 2,
                       Answer = "John Lenon",
                       AnswerType = "Closed",
                   },
                   new AnswersEntity()
                   {
                       Id = 4,
                       QuestionId = 2,
                       Answer = "Steve Jobs",
                       AnswerType = "Closed",
                   },
                   new AnswersEntity()
                   {
                       Id = 5,
                       QuestionId = 2,
                       Answer = "Jeve Stobs Jr.",
                       AnswerType = "Closed",
                   }

               );



        }
    }



}
