using System.ComponentModel.DataAnnotations;

namespace PersonalBusinessManagement.Models;

public class Project
{
    [Key]
    public int Id { get; set; }
    [StringLength(100, ErrorMessage = "Name is too big. 100 charactera max!")]
    public string Name { get; set; } = "Project Name";
    [StringLength(1250, ErrorMessage = "1250 charactera max!")]
    public string? Description { get; set; }
    public bool Delivered { get; set; }
    public Project()
    {

    }

}
