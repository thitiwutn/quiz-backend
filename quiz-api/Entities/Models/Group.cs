using quiz_api.Entities.Models.Base;

namespace quiz_api.Entities.Models;

public class Group : Tracking
{
    public int Id { get; set; }
    public string Name { get; set; }
}