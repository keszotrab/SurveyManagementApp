using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF
{
    public class OpenUserAnswersEntity
    {
        public int Id { get; set; }


        //[ForeignKey("Users")]
        public int UserId { get; set; }
        //public UsersEntity Users { get; set; }


        //[ForeignKey("Answers")]
        public int AnswerId { get; set; }
        //public AnswersEntity Answers { get; set; }


        public string AnswerText { get; set; }


        public string Email { get; set; }

    }
}
