namespace WorkHub.Web.Models.User; 
public class UserSessionData
{
    public string FullName { get; set; } = string.Empty;
    public List<string> Permissions { get; set; } = new();
}