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
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using Microsoft.VisualStudio.Services.Licensing;
using Microsoft.VisualStudio.Services.Users;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

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
                .Include(q => q.User)
                .Select(SurveyMapper.FromEntityToSurveys)
                .AsEnumerable();
                //ToList(); //////////////zapytać siwonia jak bedzie mi sie chciało
        }



        public Surveys CreateSurvey(string name, string type, int AuthorId)
        {

            SurveysEntity entity = new SurveysEntity()
            {
                Name = name,
                AuthorId = AuthorId,
                Type = type

            };

                var saved = _dbContext.Surveys.Add(entity).Entity;
                _dbContext.SaveChanges();
                return new Surveys
                (
                    id: saved.Id,
                    name: saved.Name,
                    author: SurveyMapper.FromEntityToUsers(saved.User),
                    type: saved.Type,
                    isFilled: false,
                    checks: null,
                    questions: null
                );



        }



        public Questions AddQuestion(int surveyId, string question, int userId)
        {
            var survey = _dbContext.Surveys.First(e => e.Id == surveyId);

            if (survey.AuthorId != userId) 
            {
                return null;
            }

            QuestionsEntity entity = new QuestionsEntity()
            {
                SurveysId = surveyId,
                Question = question
            };
            var saved = _dbContext.Questions.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToQuestions(entity);
        }

        public Answers AddAnswer(int questionId, string answer, string answerType, int userId)
        {
            var question = _dbContext.Questions.First(e => e.Id == questionId);
            var survey = _dbContext.Surveys.First(e => e.Id == question.SurveysId);

            if (survey.AuthorId != userId)
            {
                return null;
            }

            AnswersEntity entity = new AnswersEntity()
            {
                QuestionId = questionId,
                Answer = answer,
                AnswerType = answerType
                
            };

            var saved = _dbContext.Answers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToAnswers(entity);

        }






        public DomainCheck AddDomainCheck(int surveyId, string domainName, int userId)
        {
            var survey = _dbContext.Surveys.First(e => e.Id == surveyId);
            
            if (survey.AuthorId != userId)
            {
                return null;
            }
            if (survey.Type == "Domain")
            {
                DomainCheckEntity entity = new DomainCheckEntity()
                {
                    SurveyId = surveyId,
                    Domain_Name = domainName,
                };


                var saved = _dbContext.DomainCheck.Add(entity);
                _dbContext.SaveChanges();


                return SurveyMapper.FromEntityToDomainChecks(entity);
            }
            return null;
        }





        ///////////////////////////////////////////////////////////////
        //////////////////  //  Usuwanie  //  /////////////////////////
        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
 


        public bool RemoveAnswer(int answerId, int userId)
        {
            var entityToDelete = _dbContext.Answers.FirstOrDefault(e => e.Id == answerId);
            var question = _dbContext.Questions.First(e => e.Id == entityToDelete.QuestionId);
            var survey = _dbContext.Surveys.First(e => e.Id == question.SurveysId);

            if (survey.AuthorId != userId)
            {
                return false;
            }


            if (entityToDelete != null)
            {
                _dbContext.Answers.Remove(entityToDelete);

                _dbContext.SaveChanges();
                return true;
            }

            return false; //nie ma nic do usuniecia
        }





        public bool RemoveQuestion(int questionId, int userId)
        {
            var entityToDelete = _dbContext.Questions.FirstOrDefault(e => e.Id == questionId);
            var survey = _dbContext.Surveys.First(e => e.Id == entityToDelete.SurveysId);

            if (survey.AuthorId != userId)
            {
                return false;
            }


            if (entityToDelete != null)
            {
                _dbContext.Questions.Remove(entityToDelete);

                _dbContext.SaveChanges();
                return true;
            }
            return false; //nie ma nic do usuniecia
        }



        public bool RemoveSurvey(int surveyId, int userId)
        {
            var entityToDelete = _dbContext.Surveys.FirstOrDefault(e => e.Id == surveyId);

            if (entityToDelete.AuthorId != userId)
            {
                return false;
            }


            if (entityToDelete != null)
            {
                _dbContext.Surveys.Remove(entityToDelete);

                _dbContext.SaveChanges();
                return true;
            }
            return false; //nie ma nic do usuniecia
        }

        public bool RemoveDomainCheck(int domainCheckId, int userId)
        {
            var entityToDelete = _dbContext.DomainCheck.FirstOrDefault(e => e.Id == domainCheckId);
            var survey = _dbContext.Surveys.FirstOrDefault(e => e.Id == entityToDelete.SurveyId);

            if (survey.AuthorId != userId)
            {
                return false;
            }


            if (entityToDelete != null)
            {
                _dbContext.DomainCheck.Remove(entityToDelete);

                _dbContext.SaveChanges();
                return true;
            }
            return false; //nie ma nic do usuniecia
        }

        /////////////////////////////////////////////////////////////////
        ///////////////  //// Add User Answers ////  ////////////////////
        /////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////
        ///////////////  //// Public Answers  ////  /////////////////////
        /////////////////////////////////////////////////////////////////

        public ClosedUserAnswers PublicClosedAnswer(int answerId, string email)
        {

            ClosedUserAnswersEntity entity = new ClosedUserAnswersEntity()
            {
                Email = email,
                AnswerId = answerId
            };

            var saved = _dbContext.ClosedUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToClosedUserAnswers(entity);

        }


        public OpenUserAnswers PublicOpenAnswer(int answerId, string email, string answertext)
        {
            OpenUserAnswersEntity entity = new OpenUserAnswersEntity()
            {
                Email = email,
                AnswerId = answerId,
                AnswerText = answertext
            };

            var saved = _dbContext.OpenUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToOpenUserAnswers(entity);
        }



        ///////////////////////////////////// Private

        public ClosedUserAnswers PrivateClosedAnswer(int answerId, int userId)
        {
            var user = _dbContext.Users.First(e => e.Id == userId);

            ClosedUserAnswersEntity entity = new ClosedUserAnswersEntity()
            {
                User = user,
                AnswerId = answerId
            };

            var saved = _dbContext.ClosedUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToClosedUserAnswers(entity);

        }

        public OpenUserAnswers PrivateOpenAnswer(int answerId, int userId, string answerText) 
        {
            var user = _dbContext.Users.First(e => e.Id == userId);


            OpenUserAnswersEntity entity = new OpenUserAnswersEntity()
            {
                User = user,
                AnswerId = answerId,
                AnswerText = answerText
            };

            var saved = _dbContext.OpenUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToOpenUserAnswers(entity);

        }


        ///////////////////////////////////// Domain



        public ClosedUserAnswers DomainClosedAnswer(int answerId, string email)
        {

            ClosedUserAnswersEntity entity = new ClosedUserAnswersEntity()
            {
                Email = email,
                AnswerId = answerId
            };

            var saved = _dbContext.ClosedUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToClosedUserAnswers(entity);

        }


        public OpenUserAnswers DomainOpenAnswer(int answerId, string domain, string answerText) {

            OpenUserAnswersEntity entity = new OpenUserAnswersEntity()
            {
                Email = domain,
                AnswerId = answerId,
                AnswerText = answerText
            };

            var saved = _dbContext.OpenUserAnswers.Add(entity);
            _dbContext.SaveChanges();


            return SurveyMapper.FromEntityToOpenUserAnswers(entity);



        }







    
    }
}
