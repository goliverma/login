using System.ComponentModel.DataAnnotations;

namespace models
{
    public class Register
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}