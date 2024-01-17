using quiz_api.Entities.Models.Base;

namespace quiz_api.Services.Models.Response;

public class QuizResponse
{
    public int QuizId { get; set; }
    public ICollection<QuestionModel> Questions { get; set; }
}