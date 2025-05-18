using OOP3.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace OOP3
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Groupa> Groups => Set<Groupa>();   // groupa потому что group уже есть(((
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<UserGroupa> UserGroups => Set<UserGroupa>();
        public ApplicationContext(DbContextOptions options) => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
