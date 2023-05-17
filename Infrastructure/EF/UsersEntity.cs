using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF;

public class UsersEntity : IdentityUser<int>{

    public ICollection<SurveysEntity> Surveys { get; set; }
    public ICollection<OpenUserAnswersEntity> OpenUserAnswers { get; set; }
    public ICollection<AlreadyAnswerdEntity> AlreadyAnswerd { get; set; }
    public ICollection<ClosedUserAnswersEntity> ClosedUserAnswers { get; set; }



    //public List<Answers> AlreadyAnswerd { get; set; } 
    // Czy to jest potrzebne?  No nie, bo zależnie od typu pytania wystarczy sprawdzic jedno z dwóch poniżej. A szybciej sprawdzic 2 mniejsze listy zaleznie od typu odpowiedzi niz 1 duza(?)
}