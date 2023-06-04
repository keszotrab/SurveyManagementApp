using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "Pole Username jest wymagane.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nazwa użytkownika musi mieć od 3 do 20 znaków")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Pole Password jest wymagane")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Hasło musi zawierać co najmniej 8 znaków, jedną małą literę, jedną dużą literę i jedną cyfrę.")]
        public string Password { get; set; }
    }
}
