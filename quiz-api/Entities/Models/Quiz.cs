using System.ComponentModel.DataAnnotations.Schema;
using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class Quiz : Tracking
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }
    public int UserId { get; set; }
    public virtual ICollection<Answer> Answers { get; set; }
    public int TotalScore { get; set; }
    public bool IsCompleted { get; set; }
}