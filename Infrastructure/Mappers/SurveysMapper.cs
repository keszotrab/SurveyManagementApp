using Infrastructure.EF.Entities;
using System.Threading.Channels;
using Infrastructure;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Infrastructure.Mappers
{
    public class SurveyMapper
    {
        public static Answers FromEntityToAnswers(AnswersEntity entity)
        {
            return new Answers(

                id: entity.Id,
                answer: entity.Answer,
                answerType: entity.AnswerType,
                questionId: entity.QuestionId

                );
        }


        public static Questions FromEntityToQuestions(QuestionsEntity entity)
        {
            return new Questions(
                id: entity.Id,
                surveysId: entity.SurveysId,
                question: entity.Question,
                answers: entity.Answers.Select(FromEntityToAnswers).ToList()
                );
        }



        public static Surveys FromEntityToSurveys(SurveysEntity entity)
        {
            return new Surveys(
                id: entity.Id,
                name: entity.Name,
                author: FromEntityToUsers(entity.User),
                type: entity.Type,
                checks: entity.Checks.Select(FromEntityToDomainChecks).ToList(), 
                questions: entity.Questions.Select(FromEntityToQuestions).ToList() 
                );
        }



        public static Users FromEntityToUsers(UsersEntity entity)
        {
            return new Users(

                id: entity.Id,
                username: entity.UserName,
                password: "Zastrzerzone",
                role: "Zastrzerzone",
                email: entity.Email
                );
        }


        public static DomainCheck FromEntityToDomainChecks(DomainCheckEntity entity)
        {

            return new DomainCheck(

                id: entity.Id,
                domain_Name: entity.Domain_Name,
                surveyId: entity.SurveyId
                );



        }

















    }
}
