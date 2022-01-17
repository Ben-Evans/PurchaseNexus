namespace PurchaseNexus.Shared.Models;

public class AuthenticationUser
{
    public AuthenticationUser(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}
