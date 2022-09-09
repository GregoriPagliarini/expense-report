
namespace User.Data.ValueObjects
{
    public class UserModelValueObject
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public string ImageUrl { get; set; }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                password = System.Text.Encoding.ASCII.GetString(data);
            }
        }
    }
}
