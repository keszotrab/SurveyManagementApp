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
        public bool SaveClosedAnswer(int answerId, int userId, string email);
        public bool SaveOpenAnswer(int answerId, int userId, string email, string answerText);
        public string ReturnFirstSurveyName();

    }
}
