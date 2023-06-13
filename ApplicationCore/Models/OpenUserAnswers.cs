using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class OpenUserAnswers
    {
        public int Id { get; set; }
        public Users? User { get; set; }
        public Answers Answer { get; set; }
        public string AnswerText { get; set; }
        public string? Email { get; set; }

        public OpenUserAnswers(int id, Users? user, Answers answer, string answerText, string? email)
        {
            Id = id;
            User = user;
            Answer = answer;
            AnswerText = answerText;
            Email = email;
        }
    }
}
