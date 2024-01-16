namespace quiz_api.Services.Models.Request;

public class CreateUser
{
    public string Name { get; set; }
    public int GroupId { get; set; }
}