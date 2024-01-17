namespace quiz_api.Services.Models;

public class QuestionModel
{
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<ChoiceModel> Choices { get; set; }
}