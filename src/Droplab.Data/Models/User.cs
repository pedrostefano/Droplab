namespace Droplab.Data.Models
{
    public class User : BaseEntity
    {
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    
    }
}