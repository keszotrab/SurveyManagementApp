using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF.Entities
{
    public class ClosedUserAnswersEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public UsersEntity User { get; set; }


        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public AnswersEntity Answer { get; set; }

        public string Email { get; set; }
    }
}
