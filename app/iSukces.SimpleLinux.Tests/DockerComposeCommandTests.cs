﻿using iSukces.SimpleLinux.Docker;
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
            var actual = cmd.GetCode();
            const string expected =
                "docker-compose --verbose --no-ansi up -d --build --remove-orphans --scale serv1=3 --scale serv2=11";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void T03_should_create_up_command_with_exitCodeFrom()
        {
            var cmd = new DockerComposeCommand
            {
                Option = new DockerComposeUpOptions()
                    .WithRemoveOrphans()
                    .WithDetach()
                    .WithExitCodeFrom("myservice")
            };
            var          actual   = cmd.GetCode();
            const string expected = "docker-compose up -d --remove-orphans --exit-code-from myservice";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void T04_should_create_up_command_with_debug_level()
        {
            var cmd = new DockerComposeCommand
            {
                Option = new DockerComposeUpOptions()
                    .WithDetach(),
                Common = new DockerComposeCommonOptions()
                    .WithLogLevel(DockerComposeCommonLogLevelValues.Debug)
            };

            var          actual   = cmd.GetCode();
            const string expected = "docker-compose --log-level DEBUG up -d";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void T05_should_create_port_command()
        {
            var cmd = new DockerComposeCommand
            {
                Option = new DockerComposePortOptions()
                    .WithIndex(11)
                    .WithProtocol(DockerComposePortProtocolValues.Tcp),
                Common = new DockerComposeCommonOptions()
                    .WithLogLevel(DockerComposeCommonLogLevelValues.Debug)
            };

            var          actual   = cmd.GetCode();
            const string expected = "docker-compose --log-level DEBUG port --protocol tcp --index 11";
            Assert.Equal(expected, actual);
        }
    }
}