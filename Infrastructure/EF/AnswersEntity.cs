using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF
{
    public class AnswersEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string AnswerType { get; set; }
    }
}
