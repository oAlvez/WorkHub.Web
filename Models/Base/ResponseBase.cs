namespace WorkHub.Web.Models.Base;
public class ResponseBase
{
    public Guid CreatedId { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}
