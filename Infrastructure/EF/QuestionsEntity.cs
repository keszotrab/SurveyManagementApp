using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF
{
    public class QuestionsEntity
    {
        public int Id { get; set; }
        public int SurveysId { get; init; }
        public string Question { get; init; }
        public ISet<AnswersEntity> Answers { get; set; } = new HashSet<AnswersEntity>();

    }
}
