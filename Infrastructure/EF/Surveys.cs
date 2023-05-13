using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF;

public class Surveys
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuthorId { get; set; } //od razu można przypisać autora
    public string Type { get; set; } //public, private, domain. Mozna tu walnąć enuma teorytycznie

    public List<DomainCheckEntity> Checks { get; set; } //domeny które mogą odpowiadać na tą ankiete
    public List<QuestionsEntity> Questions { get; set; } //lista wszystkich pytań tej ankiety

    //public virtual Questions Questions { get; set; }
    //public virtual AlreadyAnswerd AlreadyAnswerd { get; set; }

    //Potrzebne?
    //public virtual Users Users { get; set; }
    //public virtual DomainCheck DomainCheck { get; set; }
}