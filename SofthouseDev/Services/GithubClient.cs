using SofthouseDev.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SofthouseDev.Services
{
    public class GithubClient : IGithubClient
    {
        private readonly HttpClient _httpClient;
        private const string _owner = "Strayko";
        private const string _repo = "Devixon";

        public GithubClient() 
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("SofthouseDev");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "{token}");
        }

        public async Task<string> GetProject()
        {
            var response = await _httpClient.GetAsync($"repos/{_owner}/{_repo}");
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public Project RepositoryDetails(string githubProject)
        {
            JsonNode repositoryDetails = JsonNode.Parse(githubProject);
            var project = new Project
            {
                Owner = repositoryDetails["owner"]?["login"].ToString(),
                Name = repositoryDetails["name"].ToString(),
                Description = repositoryDetails["description"].ToString()
            };
            return project;
        }
    }
}
