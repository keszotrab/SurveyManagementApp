using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; init; }
        public string AnswerType { get; init; }

        public Answers(int id, string answer, string answerType, int questionId)
        {
            Id = id;
            Answer = answer;
            AnswerType = answerType;
            QuestionId = questionId;
        }
    }
}
