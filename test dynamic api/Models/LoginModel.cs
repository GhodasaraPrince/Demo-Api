namespace test_dynamic_api.Models
{
    public class LoginModel
    {
        public string userName { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public string? Token { get; set; }
    }
}
