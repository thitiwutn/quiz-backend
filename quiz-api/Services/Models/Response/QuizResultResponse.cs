namespace quiz_api.Services.Models.Response;

public class QuizResultResponse
{
    public string UserName { get; set; }
    public string GroupName { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
    public int RankNo { get; set; }
}