using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SofthouseDev.Services;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using SofthouseDev.Utilities;
using SofthouseDev.Models;

namespace SofthouseDev.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGithubClient _githubClient;
        private readonly ISerializer _serializer;

        public Project Project { get; set; }

        public IndexModel(IGithubClient githubClient, ISerializer serializer)
        {
            _githubClient = githubClient;
            _serializer = serializer;
        }

        public async Task<IActionResult> OnGet()
        {
            var githubProject = await _githubClient.GetProject();
            
            if (!string.IsNullOrEmpty(githubProject))
            {
                Project = _githubClient.RepositoryDetails(githubProject);
                _serializer.SaveToFile(Project, SerializationFormat.Json, "project.json");
            }

            return Page();
        }
    }
}