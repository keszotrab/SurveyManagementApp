using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dto
{
    public class ClosedUserAnswersDto
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }



        //public List<QuizItemDto> Items { get; set; }

        /*
        public static QuizDto of(Quiz quiz)
        {
            if (quiz is null)
            {
                return null;
            }
            return new QuizDto()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = quiz.Items.Select(QuizItemDto.of).ToList()
            };
        }
        */

    }
}
