namespace CHUACSystem.Service.ViewModels
{
    public class UserBase
    {
        public string Email { get; set; }
    }
    public class UserView : UserBase
    {
        public long Id { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
