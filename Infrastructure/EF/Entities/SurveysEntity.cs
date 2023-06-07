using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.EF.Entities;

public class SurveysEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } //public, private, domain. Mozna tu walnąć enuma teorytycznie


    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public UsersEntity User { get; set; }


    public ICollection<DomainCheckEntity> Checks { get; set; } //domeny które mogą odpowiadać na tą ankiete
    public ICollection<QuestionsEntity> Questions { get; set; } //lista wszystkich pytań tej ankiety

    //public virtual Questions Questions { get; set; }\\
    //public virtual AlreadyAnswerd AlreadyAnswerd { get; set; }

    //Potrzebne?
    //public virtual Users Users { get; set; }
    //public virtual DomainCheck DomainCheck { get; set; }
}