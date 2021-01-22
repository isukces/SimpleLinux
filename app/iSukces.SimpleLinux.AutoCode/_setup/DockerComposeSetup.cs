using iSukces.SimpleLinux.AutoCode.Generators;
using iSukces.SimpleLinux.Docker;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class DockerComposeSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_UpOptions(enumsGenerator);
            Add_BuildOptions(enumsGenerator);
            Add_Common(enumsGenerator);
        }

        private static void Add_BuildOptions(EnumsGenerator enumsGenerator)
        {
            const string optionsToParse = @"
    --build-arg key=val     Set build-time variables for services.
    --compress              Compress the build context using gzip.
    --force-rm              Always remove intermediate containers.
    -m, --memory MEM        Set memory limit for the build container.
    --no-cache              Do not use cache when building the image.
    --no-rm                 Do not remove intermediate containers after a successful build.
    --parallel              Build images in parallel.
    --progress string       Set type of progress output (`auto`, `plain`, `tty`).
    --pull                  Always attempt to pull a newer version of the image.
    -q, --quiet             Don't print anything to `STDOUT`.";
            var item = enumsGenerator
                .WithEnum("Docker.DockerComposeBuild", optionsToParse);
            CommonSetup(item);
        }

        private static void Add_Common(EnumsGenerator enumsGenerator)
        {
            const string optionsToParse = @"
  -f, --file FILE             Specify an alternate compose file
                              (default: docker-compose.yml)
  -p, --project-name NAME     Specify an alternate project name
                              (default: directory name)
  --verbose                   Show more output
  --log-level LEVEL           Set log level (DEBUG, INFO, WARNING, ERROR, CRITICAL)
  --no-ansi                   Do not print ANSI control characters
  -v, --version               Print version and exit
  -H, --host HOST             Daemon socket to connect to

  --tls                       Use TLS; implied by --tlsverify
  --tlscacert CA_PATH         Trust certs signed only by this CA
  --tlscert CLIENT_CERT_PATH  Path to TLS certificate file
  --tlskey TLS_KEY_PATH       Path to TLS key file
  --tlsverify                 Use TLS and verify the remote
  --skip-hostname-check       Don't check the daemon's hostname against the
                              name specified in the client certificate
  --project-directory PATH    Specify an alternate working directory
                              (default: the path of the Compose file)
  --compatibility             If set, Compose will attempt to convert deploy
                              keys in v3 files to their non-Swarm equivalent
";
            var item = enumsGenerator
                .WithEnum("Docker.DockerComposeCommon", optionsToParse);
            CommonSetup(item);
        }


        private static void Add_UpOptions(EnumsGenerator enumsGenerator)
        {
            const string optionsToParse = @"
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
            var item = enumsGenerator
                .WithEnum("Docker.DockerComposeUp", optionsToParse)
                .WithInteger("--scale");
            CommonSetup(item);
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            var isCommon = item.EnumName == "DockerComposeCommon";
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\_dockerCompose\\{2}");
            if (isCommon)
                item.WithInterface<ICommandsPartsProvider>();
            else
                item.WithInterface<IDockerComposeOption>();
        }
    }
}