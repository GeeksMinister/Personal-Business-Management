using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PersonalBusinessManagement.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;



public static class GithubRepoHandler
{
    private const string githubUri = "https://api.github.com/users/GeeksMinister/repos";
    private const string errorReportPath = "DataAccess\\Data\\GithubRepos\\ErrorReport.txt";
    private static HttpClient client = new HttpClient();
    public static async Task<List<GithubRepo>?> GetRepos()
    {
        try
        {
            client.DefaultRequestHeaders.Add("User-Agent", "PersonalBusinessManagement");
            return await client.GetFromJsonAsync<List<GithubRepo>>(githubUri);
        }
        catch (Exception e)
        {
            await File.AppendAllTextAsync($"{errorReportPath}", "Error! Failed to retreive" +
            $" data {DateTime.Now}\n{e.Message}\n\n");
            return null;
        }



    }
}

