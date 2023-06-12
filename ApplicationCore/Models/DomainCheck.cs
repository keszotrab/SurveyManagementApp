using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class DomainCheck
    {
        public int Id { get; set; }

        public string Domain_Name { get; init; }

        public int SurveyId { get; set; }


        public DomainCheck(int id, string domain_Name, int surveyId)
        {
            Id = id;
            Domain_Name = domain_Name;
            SurveyId = surveyId;
        }
    }
}
