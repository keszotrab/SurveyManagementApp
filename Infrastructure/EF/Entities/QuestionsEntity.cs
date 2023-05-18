using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.Entities
{
    public class QuestionsEntity
    {
        public int Id { get; set; }

        public int SurveysId { get; init; }

        [ForeignKey("SurveysId")]
        public SurveysEntity Surveys { get; set; }


        public string Question { get; init; }



        public ISet<AnswersEntity> Answers { get; set; } = new HashSet<AnswersEntity>();

    }
}
