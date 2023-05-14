using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF
{
    public class ClosedUserAnswersEntity
    {
        public int Id { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }
        //public UsersEntity User { get; set; }

        //[ForeignKey("Answer")]
        public int AnswerId { get; set; }
        //public AnswersEntity Answer { get; set; }

        public string Email { get; set; }
    }
}
