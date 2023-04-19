using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLab01;

public class Users : IIdentity<int>
{
    [Key]
    public int Id { get; set; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string Rank { get; init; }
    public string Email { get; init; }

}