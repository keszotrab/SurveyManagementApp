using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class OpenUserAnswersDto
    {
        public int Id { get; set; }
        public int? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public int? UserId { get; set; }
        public string? Email { get; set; }

        public static OpenUserAnswersDto? of(OpenUserAnswers answer)
        {
            if (answer is null)
            {
                return null;
            }
            else
                return new OpenUserAnswersDto()
                {
                    Id = answer.Id,
                    AnswerId = null, //answer.Answer.Id,
                    UserId = answer.User is null ? null : answer.User.Id,
                    Email = answer.Email is null ? null : answer.Email,
                    AnswerText = answer.AnswerText
                };
        }
    }
}

