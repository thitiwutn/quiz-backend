using System.ComponentModel.DataAnnotations.Schema;
using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class User : Tracking
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }
    [ForeignKey("GroupId")] public virtual Group Group { get; set; }
}