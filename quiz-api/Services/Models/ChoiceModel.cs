namespace quiz_api.Services.Models;

public class ChoiceModel
{
    public int ChoiceId { get; set; }
    public string ChoiceText { get; set; }
    public bool IsSelected { get; set; }
}