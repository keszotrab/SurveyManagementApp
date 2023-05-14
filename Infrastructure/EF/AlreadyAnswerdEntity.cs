using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF
{
    /// Pytanie czy ta klasa modelu jest wogle potrzebna?
    public class AlreadyAnswerdEntity
    {
        public int Id { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }
        //public UsersEntity User { get; set; }

        //[ForeignKey("Answer")]
        public int AnswerId { get; set; }
        //public AnswersEntity Answer { get; set; }

        //public string Email { get; set; } //czy jest potrzebne???
    }
}

