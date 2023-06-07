using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class QuestionsDto
    {
        public int Id { get; set; }

        public int SurveysId { get; set; }

        public string Question { get; set; }

        public List<AnswersDto> ?AnswersDtos { get; set; }
    }
}
