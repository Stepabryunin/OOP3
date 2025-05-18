namespace OOP3.Models
{
    public class UserGroupa
    {
        public int Id { get; set; }
        public int? UserID { get; set; }
        public int? GroupID { get; set; }
        public User? User { get; set; }
        public Groupa? Groupa { get; set; }
    }
}
