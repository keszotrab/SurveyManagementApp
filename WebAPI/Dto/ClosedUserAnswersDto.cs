using ApplicationCore.Models;
using Microsoft.VisualStudio.Services.Users;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
    public class ClosedUserAnswersDto
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public int? UserId { get; set; }
        public string? Email { get; set; }

        public static ClosedUserAnswersDto? of(ClosedUserAnswers answer)
        {
            if (answer is null)
            {
                return null;
            }
            else
                return new ClosedUserAnswersDto()
                {
                    Id = answer.Id,
                    AnswerId = null, //answer.Answer.Id,
                    UserId = answer.User is null ? null : answer.User.Id,
                    Email = answer.Email is null ? null : answer.Email,



                };
        }

    }
}
