namespace quiz_api.Services.Models.Response;

public class AnswerResponse
{
    public int QuizId { get; set; }
    public int QuestionId { get; set; }
    public int ChoiceId { get; set; }
}