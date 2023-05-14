using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.EF
{
    public class DomainCheckEntity
    {
        public int Id { get; set; }



        public int SurveyId { get; set; }

        [ForeignKey("SurveyId")]
        public SurveysEntity Surveys { get; set; }



        public string Domain_Name { get; init; }

    }
}
