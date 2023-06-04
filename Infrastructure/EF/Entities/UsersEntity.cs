using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.Entities;

public class UsersEntity : IdentityUser<int>
{
    public string Salt { get; set; } = string.Empty;
    public ICollection<SurveysEntity> Surveys { get; set; }
}