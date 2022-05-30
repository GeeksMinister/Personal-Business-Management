using System.Text.Json.Serialization;

namespace PersonalBusinessManagement.Models;
public class GithubRepo
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

