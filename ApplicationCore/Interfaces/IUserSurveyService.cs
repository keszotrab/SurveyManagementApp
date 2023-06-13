using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public  interface IUserSurveyService
    {
        public IEnumerable<Surveys> FindAllSurveys();
        //public bool SaveClosedAnswer(int answerId, int userId, string email);
        //public bool SaveOpenAnswer(int answerId, int userId, string email, string answerText);
        public string ReturnFirstSurveyName();


        public Answers FindAnswerById(int answerId);
        public Questions FindQuestionById(int questionId);
        public Surveys FindSurveyById(int surveyId);



        public Surveys CreateSurvey(string name, string type, int AuthorId);
        public Questions AddQuestion(int quizId, string question, int userId);
        public Answers AddAnswer(int qustionId, string answer, string answerType, int userId);
        public bool RemoveQuestion(int questionId, int userId);
        public bool RemoveAnswer(int answerId, int userId);
        public bool RemoveSurvey(int surveyId, int userId);

        public bool RemoveDomainCheck(int domainCheckId, int userId);
        public DomainCheck AddDomainCheck(int surveyId, string domainName, int userId);




        public ClosedUserAnswers PublicClosedAnswer(int answerId, string email);
        public OpenUserAnswers PublicOpenAnswer(int answerId, string email, string answer);

        public ClosedUserAnswers PrivateClosedAnswer(int answerId, int userId);
        public OpenUserAnswers PrivateOpenAnswer(int answerId, int userId, string answerText);

        public ClosedUserAnswers DomainClosedAnswer(int answerId, string domain);
        public OpenUserAnswers DomainOpenAnswer(int answerId, string domain, string answerText);

        /*
        public Surveys CreateSurvey(string Name, string Type);   ///////// 1
        public Questions AddQuestion(int surveyId, string Question); ///////// 2
        public Answers AddAnswers(int QuestionId, string Answer, string AnswerType); /////// 3
        */
    }
}
