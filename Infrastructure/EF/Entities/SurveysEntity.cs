using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.EF.Entities;

public class SurveysEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } //public, private, domain. Mozna tu walnąć enuma teorytycznie
    public bool IsFilled { get; set; } = false;


    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public UsersEntity User { get; set; }


    public ICollection<DomainCheckEntity> Checks { get; set; } //domeny które mogą odpowiadać na tą ankiete
    public ICollection<QuestionsEntity> Questions { get; set; } //lista wszystkich pytań tej ankiety

}