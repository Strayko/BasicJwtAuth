using SofthouseDev.Models.Github;

namespace SofthouseDev.Services
{
    public interface IGithubClient
    {
        Task<string> GetProject();
        Project RepositoryDetails(string githubProject);
    }
}
