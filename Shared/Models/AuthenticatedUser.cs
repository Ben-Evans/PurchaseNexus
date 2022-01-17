namespace PurchaseNexus.Shared.Models;

public class AuthenticatedUser
{
    public AuthenticatedUser(string username, string accessToken)
    {
        Username = username;
        AccessToken = accessToken;
    }

    public string Username { get; set; }
    public string AccessToken { get; }
}
