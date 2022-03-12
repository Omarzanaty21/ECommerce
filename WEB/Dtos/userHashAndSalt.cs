namespace WEB.Dtos
{
    public class UserHashAndSalt
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}