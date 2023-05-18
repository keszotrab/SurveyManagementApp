using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.Entities
{
    public class AnswersEntity
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public QuestionsEntity Question { get; set; }

        public string Answer { get; set; }
        public string AnswerType { get; set; }

        public ICollection<OpenUserAnswersEntity> OpenUserAnswers { get; set; }
        public ICollection<AlreadyAnswerdEntity> AlreadyAnswerd { get; set; }
        public ICollection<ClosedUserAnswersEntity> ClosedUserAnswers { get; set; }
    }
}
