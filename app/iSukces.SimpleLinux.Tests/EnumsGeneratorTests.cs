using iSukces.SimpleLinux.AutoCode.Generators;
using iSukces.SimpleLinux.Docker;
using Xunit;

namespace iSukces.SimpleLinux.Tests
{
    public class EnumsGeneratorTests
    {
        [Fact]
        public void T01_Should_parse_sample_options()
        {
            var q = OptionsCollection.Parse(sampleOptions, ParserKind.Default);
            Assert.Equal(17, q.Values.Count);
            {
                var a = q.Values[0];
                Assert.Equal("d", a.ShortOption);
                Assert.Equal("detach", a.LongOption);
                Assert.Equal(
                    "Detached mode: Run containers in the background, print new container names. Incompatible with --abort-on-container-exit.",
                    a.Description);
            }
            {
                var a = q.Values[16];
                Assert.Equal("scale", a.LongOption);
                Assert.Equal("SERVICE", a.Parameter.Name);
                Assert.Equal("NUM", a.Parameter.Value);
            }
        }

        [Fact]
        public void T02a_Should_compute_namespace_and_name()
        {
            var tmp = new EnumsGeneratorItem
            {
                Names       = "Bla",
                Options        = OptionsCollection.Parse(sampleOptions, ParserKind.Default),
                TargetAssembly = typeof(EnumsGeneratorTests).Assembly
            };
            Assert.Equal("iSukces.SimpleLinux.Tests", tmp.Namespace);
            Assert.Empty(tmp.OwnerClasses);
            Assert.Equal("Bla", tmp.EnumName);
        }


        [Fact]
        public void T02b_Should_compute_namespace_and_name()
        {
            var tmp = new EnumsGeneratorItem
            {
                Names       = "Other.Bla",
                Options        = OptionsCollection.Parse(sampleOptions, ParserKind.Default),
                TargetAssembly = typeof(EnumsGeneratorTests).Assembly
            };
            Assert.Equal("iSukces.SimpleLinux.Tests.Other", tmp.Namespace);
            Assert.Empty(tmp.OwnerClasses);
            Assert.Equal("Bla", tmp.EnumName);
        }

        [Fact]
        public void T03_should_create_DockerComposeUpOptions()
        {
            var q = new DockerComposeUpOptions()
                .WithRemoveOrphans()
                .WithForceRecreate();
            var aa = q.Flags.OptionsToString(OptionPreference.Long);
            var bb = string.Join(" ", aa);
            Assert.Equal("--force-recreate --remove-orphans", bb);
        }

        private const string sampleOptions = @"
    -d, --detach               Detached mode: Run containers in the background,
                               print new container names. Incompatible with
                               --abort-on-container-exit.
    --no-color                 Produce monochrome output.
    --quiet-pull               Pull without printing progress information
    --no-deps                  Don't start linked services.
    --force-recreate           Recreate containers even if their configuration
                               and image haven't changed.
    --always-recreate-deps     Recreate dependent containers.
                               Incompatible with --no-recreate.
    --no-recreate              If containers already exist, don't recreate
                               them. Incompatible with --force-recreate and 
                               --renew-anon-volumes.
    --no-build                 Don't build an image, even if it's missing.
    --no-start                 Don't start the services after creating them.
    --build                    Build images before starting containers.
    --abort-on-container-exit  Stops all containers if any container was
                               stopped. Incompatible with --detach.
    --attach-dependencies      Attach to dependent containers.
    -t, --timeout TIMEOUT      Use this timeout in seconds for container
                               shutdown when attached or when containers are
                               already running. (default: 10)
    -V, --renew-anon-volumes   Recreate anonymous volumes instead of retrieving
                               data from the previous containers.
    --remove-orphans           Remove containers for services not defined
                               in the Compose file.
    --exit-code-from SERVICE   Return the exit code of the selected service
                               container. Implies --abort-on-container-exit.
    --scale SERVICE=NUM        Scale SERVICE to NUM instances. Overrides the
                               `scale` setting in the Compose file if present.";
    }
}