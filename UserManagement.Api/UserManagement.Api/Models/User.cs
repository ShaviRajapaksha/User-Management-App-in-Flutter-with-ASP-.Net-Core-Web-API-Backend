using System.ComponentModel.DataAnnotations;

namespace UserManagement.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String PasswordHash { get; set; }
        public String Role { get; set; } = "User";
    }
}
