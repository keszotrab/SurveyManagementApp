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
using Microsoft.AspNetCore.Identity;

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


        public Answers FindAnswerById(int answerId)
        {
            return SurveyMapper.FromEntityToAnswers(_dbContext.Answers.Find(answerId));
        }

        public Questions FindQuestionById(int questionId)
        {
            var entity = _dbContext
                .Questions
                .AsNoTracking()
                .Include(q => q.Answers)
                .FirstOrDefault(e=> e.Id == questionId);


            return SurveyMapper.FromEntityToQuestions(entity);
        }


        public Surveys FindSurveyById(int surveyId)
        {
            var entity = _dbContext
                .Surveys
                .AsNoTracking()
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .Include(q => q.Checks)
                .Include(q => q.User)
                .FirstOrDefault(e => e.Id == surveyId);


            return SurveyMapper.FromEntityToSurveys(entity);
        }








































        public IEnumerable<Surveys> FindAllSurveys()
        {
            return _dbContext
                .Surveys
                .AsNoTracking()
                .Include(q => q.Questions)
                .ThenInclude(i => i.Answers)
                .Select(SurveyMapper.FromEntityToSurveys)
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
