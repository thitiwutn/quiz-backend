using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class Choice : Tracking
{
    public int Id { get; set; }
    public string ChoiceText { get; set; }
    public int point { get; set; }
    public int QuestionId { get; set; }
    public virtual Question Question { get; set; }
}