using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SitefinityWebApp.Models.GitHub;
using System.Net;
using Newtonsoft.Json;

namespace SitefinityWebApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class GitHubController : Controller
    {
        [HttpGet]
        public IEnumerable<GitHubProfile> Get()
        {
            WebClient request = new WebClient();
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
            var result = request.DownloadString($"https://api.github.com/users");
            var gitHubProfiles = JsonConvert.DeserializeObject<IList<GitHubProfile>>(result);
            return gitHubProfiles;
        }

        [HttpGet("{name}")]
        public GitHubProfile Get(string name)
        {
            WebClient request = new WebClient();
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
            var result = request.DownloadString($"https://api.github.com/users/{name}");
            var gitHubProfile = JsonConvert.DeserializeObject<GitHubProfile>(result);
            return gitHubProfile;
        }
    }
}
