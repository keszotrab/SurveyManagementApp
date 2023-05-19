using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.Entities;

public class UsersEntity : IdentityUser<int>
{
    public string Salt { get; set; }
    public ICollection<SurveysEntity> Surveys { get; set; }
}