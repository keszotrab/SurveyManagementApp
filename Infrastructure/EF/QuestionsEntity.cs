using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF
{
    public class QuestionsEntity
    {
        public int Id { get; set; }



        [ForeignKey("Surveys")]
        public int SurveysId { get; init; }
        public SurveysEntity Surveys { get; init; }




        public string Question { get; init; }



        public ISet<AnswersEntity> Answers { get; set; } = new HashSet<AnswersEntity>();

    }
}
