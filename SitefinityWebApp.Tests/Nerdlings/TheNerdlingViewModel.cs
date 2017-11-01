using System;
using Xunit;
using SitefinityWebApp.Nerdlings;
using System.Dynamic;
using System.Runtime.CompilerServices;
using SitefinityWebApp.Models.GitHub;

namespace SitefinityWebApp.Tests
{
    public class TheNerdlingViewModel
    {
        NerdlingViewModel _viewModel;
        GitHubProfile _fakeGitHubProfile;

        [Fact]
        public void HasATitle()
        {
            Arrange();
            Assert.Equal("Yo this be my title dawg", _viewModel.Title);
        }

        [Fact]
        public void HasAGitHubProfile()
        {
            Arrange();
            Assert.Equal(_fakeGitHubProfile, _viewModel.GitHubProfile);
        }

        void Arrange()
        {
            dynamic nerdling = new ExpandoObject();
            dynamic nerdlingFields = new ExpandoObject();
            nerdlingFields.Title = "Yo this be my title dawg";
            nerdlingFields.GitHubUrl = "RobertMcCoy";
            nerdling.Fields = nerdlingFields;
            _fakeGitHubProfile = new GitHubProfile
            {
                Name = "testuser"
            };
            _viewModel = new TestableNerdlingViewModel(nerdling, _fakeGitHubProfile);
        }

        class TestableNerdlingViewModel : NerdlingViewModel
        {
            readonly GitHubProfile _fakeGitHubProfile;

            public TestableNerdlingViewModel(ExpandoObject nerdling, GitHubProfile fakeGitHubProfile) : base(nerdling)
            {
                _fakeGitHubProfile = fakeGitHubProfile;
            }

            public override GitHubProfile GitHubProfile
            {
                get
                {
                    return _fakeGitHubProfile;
                }
            }
        }
    }
}
