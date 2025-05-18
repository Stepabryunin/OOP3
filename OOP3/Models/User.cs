namespace OOP3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<UserGroupa>? UserGroups { get; set; } = new List<UserGroupa>();
        public List<Post>? Posts { get; set; } = new List<Post>();
    }
}
