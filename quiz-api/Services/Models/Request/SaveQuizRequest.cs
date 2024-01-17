
namespace quiz_api.Services.Models.Request;

public class SaveQuizRequest
{    
    public int QuizId { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public ICollection<QuestionModel> Questions { get; set; }
}



