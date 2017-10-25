using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

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

        public string GitHubProfile
        {
            get
            {
                return _nerdling.Fields?.GitHubUrl;
            }
        }

        public virtual string GitHubProfileImageUrl
        {
            get
            {
                WebClient request = new WebClient();
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                var result = request.DownloadString($"https://api.github.com/users/{GitHubProfile}");
                var gitHubProfile = JsonConvert.DeserializeObject<GitHubProfile>(result);
                return gitHubProfile.AvatarUrl;
            }
        }
    }
}