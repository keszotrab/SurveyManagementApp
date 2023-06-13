using ApplicationCore.Models;
using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dto
{
    public class AnswersDto
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string AnswerType { get; set; }

        public static AnswersDto of(Answers answer)
        {
            if (answer is null)
            {
                return null;
            }
            else
                return new AnswersDto()
                {
                    Id = answer.Id,
                    QuestionId = answer.QuestionId,
                    Answer = answer.Answer,
                    AnswerType = answer.AnswerType,
                    

                };
        }

    }
}
