using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF;

public class UsersEntity : IdentityUser<int>{

public ICollection<SurveysEntity> Surveys { get; set; }
}