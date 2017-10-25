using System;
using Xunit;
using SitefinityWebApp.Nerdlings;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace SitefinityWebApp.Tests
{
    public class TheNerdlingViewModel
    {
        NerdlingViewModel _viewModel;

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
            Assert.Equal("RobertMcCoy", _viewModel.GitHubProfile);
        }

        [Fact]
        public void GetsTheGitHubProfileImage()
        {
            Arrange();
            Assert.Equal($"http://github.com/{_viewModel.GitHubProfile}/testimage.png", _viewModel.GitHubProfileImageUrl);
        }

        void Arrange()
        {
            dynamic nerdling = new ExpandoObject();
            dynamic nerdlingFields = new ExpandoObject();
            nerdlingFields.Title = "Yo this be my title dawg";
            nerdlingFields.GitHubUrl = "RobertMcCoy";
            nerdling.Fields = nerdlingFields;
            _viewModel = new TestableNerdlingViewModel(nerdling);
        }

        class TestableNerdlingViewModel : NerdlingViewModel
        {
            public TestableNerdlingViewModel(ExpandoObject nerdling) : base(nerdling)
            {
            }

            public override string GitHubProfileImageUrl
            {
                get
                {
                    return $"http://github.com/{GitHubProfile}/testimage.png";
                }
            }
        }
    }
}
