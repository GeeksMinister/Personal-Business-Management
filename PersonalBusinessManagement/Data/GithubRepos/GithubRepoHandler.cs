using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalBusinessManagement.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PersonalBusinessManagement.Data.GithubRepos;

public static class GithubRepoHandler
{
    private const string githubUri = "https://api.github.com/users/GeeksMinister/repos";
    private const string errorReportPath = "Data\\GithubRepos\\ErrorReport.txt";
    private static HttpClient client = new HttpClient();
    public static async Task<List<GithubRepo>?> GetRepos()
    {
        try
        {
            client.DefaultRequestHeaders.Add("User-Agent", "PersonalBusinessManagement");
            var response = await client.GetStringAsync(githubUri);
           return JsonConvert.DeserializeObject<List<GithubRepo>>(response);
        }
        catch (Exception e)
        {
            await File.AppendAllTextAsync($"{errorReportPath}", "Error! Failed to retreive" +
            $" data {DateTime.Now}\n{e.Message}\n\n");
            return null;
        }



    }
}

