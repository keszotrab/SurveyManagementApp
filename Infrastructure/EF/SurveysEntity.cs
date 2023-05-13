using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF;

public class SurveysEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } //public, private, domain. Mozna tu walnąć enuma teorytycznie


    [ForeignKey("Users")]
    public int AuthorId { get; set; } 
    public UsersEntity Users { get; set; }









    public ICollection<DomainCheckEntity> Checks { get; set; } //domeny które mogą odpowiadać na tą ankiete
    public ICollection<QuestionsEntity> Questions { get; set; } //lista wszystkich pytań tej ankiety

    //public virtual Questions Questions { get; set; }
    //public virtual AlreadyAnswerd AlreadyAnswerd { get; set; }

    //Potrzebne?
    //public virtual Users Users { get; set; }
    //public virtual DomainCheck DomainCheck { get; set; }
}