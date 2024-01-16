using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class Question : Tracking
{
    [Key] public int Id { get; set; }
    public string QuestionText { get; set; }
    public int order { get; set; }
    public int GroupId { get; set; }
    [ForeignKey("GroupId")] public virtual Group Group { get; set; }
    public virtual ICollection<Choice> Choices { get; set; }
}