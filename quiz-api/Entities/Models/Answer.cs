using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class Answer : Tracking
{
    [Key, Column(Order = 0)] public int QuizId { get; set; }
    [Key, Column(Order = 1)] public int QuestionId { get; set; }
    [Key, Column(Order = 2)] public int ChoiceId { get; set; }
    public int score { get; set; }
}