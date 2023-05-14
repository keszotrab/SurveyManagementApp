using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF;

public class UsersEntity : IdentityUser<int>{

    public ICollection<SurveysEntity> Surveys { get; set; }



    /*
    [Key]
    public int Id { get; set; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string Role { get; init; }
    public string Email { get; init; }

 
    



    public ICollection<ClosedUserAnswersEntity> ClosedUserAnswers { get; set; }
    public ICollection<OpenUserAnswersEntity> OpenUserAnswers { get; set; }
    public ICollection<SurveysEntity> UsersSurveys { get; set; }
    */


    //public List<Answers> AlreadyAnswerd { get; set; } 
    // Czy to jest potrzebne?  No nie, bo zależnie od typu pytania wystarczy sprawdzic jedno z dwóch poniżej. A szybciej sprawdzic 2 mniejsze listy zaleznie od typu odpowiedzi niz 1 duza(?)
}