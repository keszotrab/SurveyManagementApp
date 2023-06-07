using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public int SurveysId { get; init; }
        public string Question { get; init; }
        public List<Answers> Answers { get; init; }

        public Questions(int id, int surveysId, string question, List<Answers> answers)
        {
            Id = id;
            SurveysId = surveysId;
            Question = question;
            Answers = answers;
        }
    }
}
