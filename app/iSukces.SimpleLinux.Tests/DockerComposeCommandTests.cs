using iSukces.SimpleLinux.Docker;
using Xunit;

namespace iSukces.SimpleLinux.Tests
{
    public class DockerComposeCommandTests
    {
        [Fact]
        public void T01_should_create_basic_up_command()
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
        
        [Fact]
        public void T02_should_create_up_command_with_scale()
        {
            var cmd = new DockerComposeCommand
            {
                Option = new DockerComposeUpOptions()
                    .WithRemoveOrphans()
                    .WithDetach()
                    .WithBuild()
                    .WithScale("serv1", 3)
                    .WithScale("serv2", 11),
                Common = new DockerComposeCommonOptions()
                    .WithVerbose()
                    .WithNoAnsi()

            };
            Assert.Equal("docker-compose --verbose --no-ansi up -d --build --remove-orphans --scale serv1=3 --scale serv2=11", cmd.GetCode());
        }
    }
}