using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure
{
    public class QuizDbContext : IdentityDbContext<UsersEntity, UserRoleEntity, int>
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


        public QuizDbContext() 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "DATA SOURCE=BARTEK-KOMPUTER\\SQLEXPRESS;DATABASE=SurveysDb5;Integrated Security=true;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<QuizItemUserAnswerEntity>()
            //    .HasOne(e => e.QuizItem);

            /*
            modelBuilder.Entity<UsersEntity>()
                .HasData(
                    new UsersEntity() { Id = 1, Username="admin", Password="admin", Role= "admin", Email="admin@admin.adm"},
                    new UsersEntity() { Id = 2, Username = "client", Password = "client", Role = "client", Email = "client@client.cli" }
                );
            */




            /*
             * 
             * 
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
                   }
               );




            */












            /*
            modelBuilder.Entity<SurveysEntity>()
                .HasMany<QuestionsEntity>(q => q.Questions)
                .WithMany(e => e.Quizzes)
                .UsingEntity(
                    join => join.HasData(
                        new { QuizzesId = 1, ItemsId = 1 },
                        new { QuizzesId = 1, ItemsId = 2 },
                        new { QuizzesId = 1, ItemsId = 3 }
                    )
                );

            modelBuilder.Entity<QuizItemEntity>()
                .HasMany<QuizItemAnswerEntity>(q => q.IncorrectAnswers)
                .WithMany(e => e.QuizItems)
                .UsingEntity(join => join.HasData(
                        // "2 + 3"
                        new { QuizItemsId = 1, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 1, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 1, IncorrectAnswersId = 3 },
                        // "2 * 3"
                        new { QuizItemsId = 2, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 2, IncorrectAnswersId = 4 },
                        new { QuizItemsId = 2, IncorrectAnswersId = 7 },
                        // "8 - 3"
                        new { QuizItemsId = 3, IncorrectAnswersId = 1 },
                        new { QuizItemsId = 3, IncorrectAnswersId = 3 },
                        new { QuizItemsId = 3, IncorrectAnswersId = 9 },
                        // "8 : 2"
                        new { QuizItemsId = 4, IncorrectAnswersId = 2 },
                        new { QuizItemsId = 4, IncorrectAnswersId = 6 },
                        new { QuizItemsId = 4, IncorrectAnswersId = 8 }
                    )
                );
            */
        }
    }


    /*
    public class SurveysDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
    public SurveysDbContext(): base("MyConnectionString")
    {
        Database.SetInitializer<SurveysDbContext>(new CreateDatabaseIfNotExists<SurveysDbContext>());

        //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
        //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
        //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
    }



        public DbSet<AlreadyAnswerdEntity> AlreadyAnswerd { get; set; }
        public DbSet<AnswersEntity> Answers { get; set; }
        public DbSet<ClosedUserAnswersEntity> ClosedUserAnswers { get; set; }
        public DbSet<DomainCheckEntity> DomainCheck { get; set; }
        public DbSet<OpenUserAnswersEntity> OpenUserAnswers { get; set; }
        public DbSet<QuestionsEntity> Questions { get; set; }
        public DbSet<SurveysEntity> Surveys { get; set; }
        public DbSet<UsersEntity> users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "DATA SOURCE=..\\SQLEXPRESS;DATABASE=SurveyManagementApp;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);







        }




    }
    */

}
