using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Infrastructure.EF.Entities;
using Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Interfaces;

namespace Infrastructure.Services
{
    public class UserSurveyService : IUserSurveyService
    {
        private readonly SurveysDbContext _dbContext;

        public UserSurveyService()
        {
            _dbContext = new SurveysDbContext();
        }

        public string ReturnFirstSurveyName()
        {

            return _dbContext.Surveys.First().Name;
        }





        public IEnumerable<Surveys> FindAllSurveys()
        {
            return _dbContext
                .Surveys
                .AsNoTracking()
                .Include(q => q.Questions)
                .ThenInclude(i => i.Answers)
                .Select(SurveyMapper.FromEntityToSurvey)
                .ToList();
        }

        public bool SaveClosedAnswer(int answerId, int userId, string email)
        {
            ClosedUserAnswersEntity answer = new ClosedUserAnswersEntity
            {
                Id = 1,
                AnswerId = answerId,
                UserId = userId,
                Email = email
            };

            try
            {
                _dbContext.ClosedUserAnswers.Add(answer);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;

            }
            return false;
        }

        public bool SaveOpenAnswer(int answerId, int userId, string email, string answerText)
        {
            OpenUserAnswersEntity answer = new OpenUserAnswersEntity
            {
                Id = 1,
                AnswerId = answerId,
                UserId = userId,
                Email = email,
                AnswerText = answerText
            };

            try
            {
                _dbContext.OpenUserAnswers.Add(answer);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;

            }
            return false;
        }


        /*
        public bool SaveOpenAnswer(OpenUserAnswersEntity answer)
        {
            try
            {
                _dbContext.OpenUserAnswers.Add(answer);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;

            }
            return true;
        }
        */
        //TODO
        /// dodać interfejs do tego serwisu z funkcjami (moze)


    }
}
