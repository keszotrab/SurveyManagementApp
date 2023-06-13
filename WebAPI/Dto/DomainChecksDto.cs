using ApplicationCore.Models;
using Infrastructure.EF.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Dto
{
    public class DomainChecksDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Domain_Name { get; init; }

        public static DomainChecksDto of(DomainCheck question)
        {
            if (question is null)
            {
                return null;
            }
            else
                return new DomainChecksDto()
                {
                    Id = question.Id,
                    SurveyId = question.SurveyId,
                    Domain_Name = question.Domain_Name,


                };
        }
    }
}
