using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public Questions Question { get; set; }
        public string Answer { get; init; }
        public string AnswerType { get; init; }
    }
}
