namespace OOP3.Models
{
    public class Groupa
    {
        public int Id { get; set; }
        public string? Name { get; set; }
 
        public List<UserGroupa>? Users { get; set; }=new List<UserGroupa>();
    }
}
