using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Infrastructure;
using Infrastructure.EF.Entities;

namespace ApplicationCore.Interfaces
{
    public class UserSurveyService
    {
        private readonly Infrastructure.SurveysDbContext _dbContext;

        UserSurveyService(SurveysDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool SaveClosedAnswer(ClosedUserAnswersEntity answer)
        {
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

        //TODO
        /// dodać interfejs do tego serwisu z funkcjami


    }
}
