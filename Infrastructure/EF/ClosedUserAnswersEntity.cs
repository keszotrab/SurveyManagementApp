namespace Infrastructure.EF
{
    public class ClosedUserAnswersEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public string Email { get; set; }
    }
}
