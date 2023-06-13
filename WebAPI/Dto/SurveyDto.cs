using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int AuthorId { get; set; }
        public bool IsFilled { get; set; } = false;

        public List<QuestionsDto> QuestionsDtos { get; set; }
        public List<DomainChecksDto> DomainChecksDtos { get; set; }

        public static SurveyDto? of(Surveys survey)
        {
            if (survey is null)
            {
                return null;
            }
            else
                return new SurveyDto()
                {
                    Id = survey.Id,
                    Name = survey.Name,
                    Type = survey.Type,
                    AuthorId = survey.Author.Id,
                    IsFilled = survey.IsFilled,
                    QuestionsDtos = survey.Questions is null ? null : survey.Questions.Select(QuestionsDto.of).ToList(),
                    DomainChecksDtos = survey.Checks is null ? null : survey.Checks.Select(DomainChecksDto.of).ToList(),

                };
        }



    }
}
