using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF
{
    public class DomainCheckEntity
    {
        public int Id { get; set; }

        public int SurveyId { get; init; }

        public string Domain_Name { get; init; }

    }
}
