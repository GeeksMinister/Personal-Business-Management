using System.ComponentModel.DataAnnotations;

namespace PersonalBusinessManagement.Models;

public class Todo
{
#pragma warning disable CS8618
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Range(1, 5)]
    public int? Priority { get; set; } = null;

    public Todo()
    {

    }

}

