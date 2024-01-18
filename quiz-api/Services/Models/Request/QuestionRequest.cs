namespace quiz_api.Services.Models.Request;

public class QuestionRequest
{
    public int QuestionId { get; set; }
    public int? SelectedChoiceId { get; set; }
}