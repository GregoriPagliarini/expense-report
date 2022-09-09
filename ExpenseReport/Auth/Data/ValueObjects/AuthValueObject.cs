namespace Auth.Data.ValueObjects
{
    public class AuthValueObject
    {
        public string Name { get; set; }

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
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
