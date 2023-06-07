using Infrastructure.EF.Entities;
using System.Threading.Channels;
using Infrastructure;
using ApplicationCore.Models;

namespace Infrastructure.Mappers
{
    public class SurveyMapper
    {
        public static Surveys FromEntityToSurvey(SurveysEntity entity)
        {
            return new Surveys(

                id: entity.Id,
                name: entity.Name,
                author: FromEntityToUsers(entity.User),
                type: entity.Type,
                checks: entity.Checks.Select(FromEntityToDomainCheck).ToList(),
                questions: entity.Questions.Select(FromEntityQuestions).ToList() 
                );
        }

        public static Users FromEntityToUsers(UsersEntity entity)
        {
            //Mapper i model Usera do przemyślenia, ale narazie jest ok
            return new Users(

                id: entity.Id,
                username: entity.UserName,
                password: "",
                role: "",
                email: entity.Email
                
                );

        }

        public static Questions FromEntityQuestions(QuestionsEntity entity)
        {
            return new Questions(

                id: entity.Id,
                surveysId: entity.SurveysId,
                question: entity.Question,
                answers: entity.Answers.Select(FromEntityAnswers).ToList()

                );
        }

        public static Answers FromEntityAnswers(AnswersEntity entity)
        {
            return new Answers(

                id: entity.Id,
                answer: entity.Answer,
                answerType: entity.AnswerType,
                questionId: entity.QuestionId

                );
        }

        public static DomainCheck FromEntityToDomainCheck(DomainCheckEntity entity)
        {

            return new DomainCheck(

                id: entity.Id,
                surveyId: entity.SurveyId,
                domain_Name: entity.Domain_Name

                );


        }

    }
}
