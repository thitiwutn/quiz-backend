using quiz_api.Entities.Models.Base;

namespace quiz_api.Services.Models.Response;

public class QuizResponse : Tracking
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public ICollection<AnswerResponse> Answers { get; set; }
    public int TotalScore { get; set; }
    public int MaxScore { get; set; }
    public bool IsCompleted { get; set; }
}