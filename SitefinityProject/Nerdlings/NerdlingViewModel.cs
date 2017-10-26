using System.Net;
using Newtonsoft.Json;
using SitefinityWebApp.Models.GitHub;

namespace SitefinityWebApp.Nerdlings
{
    public class NerdlingViewModel
    {
        dynamic _nerdling;

        public NerdlingViewModel(dynamic nerdling)
        {
            _nerdling = nerdling;
        }

        public string Title
        {
            get
            {
                return _nerdling.Fields?.Title;
            }
        }

        public virtual GitHubProfile GitHubProfile
        {
            get
            {
                return GetGitHubProfileFromUsername();
            }
        }

        GitHubProfile GetGitHubProfileFromUsername()
        {
            WebClient request = new WebClient();
            var result = request.DownloadString($"/api/GitHub/{GitHubProfile}");
            var gitHubProfile = JsonConvert.DeserializeObject<GitHubProfile>(result);
            return gitHubProfile;
        }
    }
}