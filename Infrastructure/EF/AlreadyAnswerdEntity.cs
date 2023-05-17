using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.EF
{
    /// Pytanie czy ta klasa modelu jest wogle potrzebna?
    public class AlreadyAnswerdEntity
    {
        public int Id { get; set; }

        
        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public UsersEntity User { get; set; }


        public int AnswerId { get; set; }
        [ForeignKey("AnswerId")]
        public AnswersEntity Answer { get; set; }

    }
}

