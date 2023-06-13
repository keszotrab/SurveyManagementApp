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
                author: entity.User is null ? null : FromEntityToUsers(entity.User),
                type: entity.Type,
                isFilled: entity.IsFilled,
                checks: entity.Checks is null ? null : entity.Checks.Select(FromEntityToDomainChecks).ToList(), 
                questions: entity.Questions is null ? null : entity.Questions.Select(FromEntityToQuestions).ToList() 
                );
        }



        public static Users? FromEntityToUsers(UsersEntity entity)
        {
            return entity is null ? null : new Users(

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

        public static ClosedUserAnswers FromEntityToClosedUserAnswers(ClosedUserAnswersEntity entity)
        {

            return new ClosedUserAnswers(
                id: entity.Id,
                user: entity.User is null ? null : FromEntityToUsers(entity.User),
                answer: null, //FromEntityToAnswers(entity.Answer),
                email: entity.Email is null ? null : entity.Email
                );
        }

        public static OpenUserAnswers FromEntityToOpenUserAnswers(OpenUserAnswersEntity entity)
        {

            return new OpenUserAnswers(
                id: entity.Id,
                user: entity.User is null ? null : FromEntityToUsers(entity.User),
                answer: null, //FromEntityToAnswers(entity.Answer),
                answerText: entity.AnswerText,
                email: entity.Email is null ? null : entity.Email
                );
        }













    }
}
