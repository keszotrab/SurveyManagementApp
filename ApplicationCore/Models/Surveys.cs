using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models;

public class Surveys
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Users Author { get; set; } //od razu można przypisać autora
    public string Type { get; set; } //public, private, domain. Mozna tu walnąć enuma teorytycznie
    public bool IsFilled { get; set; } = false;

    public List<DomainCheck> Checks { get; set; } //domeny które mogą odpowiadać na tą ankiete
    public List<Questions> Questions { get; set; } //lista wszystkich pytań tej ankiety

    public Surveys(int id, string name, Users author, string type, bool isFilled, List<DomainCheck> checks, List<Questions> questions)
    {
        Id = id;
        Name = name;
        Author = author;
        Type = type;
        IsFilled = isFilled;
        Checks = checks;
        Questions = questions;
    }







    //public virtual Questions Questions { get; set; }
    //public virtual AlreadyAnswerd AlreadyAnswerd { get; set; }

    //Potrzebne?
    //public virtual Users Users { get; set; }
    //public virtual DomainCheck DomainCheck { get; set; }
}