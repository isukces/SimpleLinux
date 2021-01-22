using iSukces.SimpleLinux.Docker;
using Xunit;

namespace iSukces.SimpleLinux.Tests
{
    public class DockerComposeCommandTests
    {
        [Fact]
        public void T01()
        {
            var cmd = new DockerComposeCommand
            {
                Option = new DockerComposeUpOptions()
                    .WithRemoveOrphans()
                    .WithDetach()
                    .WithBuild(),
                Common = new DockerComposeCommonOptions()
                    .WithVerbose()
                    .WithNoAnsi()
            };
            Assert.Equal("docker-compose --verbose --no-ansi up -d --build --remove-orphans", cmd.GetCode());
        }
    }
}