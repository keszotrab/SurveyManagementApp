using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.Entities
{
    public class OpenUserAnswersEntity
    {
        public int Id { get; set; }



        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public UsersEntity User { get; set; }



        public int AnswerId { get; set; }
        [ForeignKey("AnswersId")]
        public AnswersEntity Answers { get; set; }


        public string AnswerText { get; set; }


        public string Email { get; set; }

    }
}
