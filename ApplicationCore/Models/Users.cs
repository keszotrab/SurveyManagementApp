using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models;

public class Users
{


    public int Id { get; set; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string? Role { get; init; }
    public string Email { get; init; }

    public Users(int id, string username, string password, string role, string email)
    {
        Id = id;
        Username = username;
        Password = password;
        Role = role;
        Email = email;
    }




    //public List<Surveys> UsersSurveys { get; set; }

    //public List<Answers> AlreadyAnswerd { get; set; } 
    // Czy to jest potrzebne?  No nie, bo zależnie od typu pytania wystarczy sprawdzic jedno z dwóch poniżej. A szybciej sprawdzic 2 mniejsze listy zaleznie od typu odpowiedzi niz 1 duza(?)

    //public List<ClosedUserAnswers> ClosedUserAnswers { get; set; }
    //public List<OpenUserAnswers> OpenUserAnswers { get; set; }

}