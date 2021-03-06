﻿using System.Collections.Generic;
using iSukces.Code;
using iSukces.SimpleLinux.AutoCode.Generators;
using iSukces.SimpleLinux.Docker;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class DockerComposeSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_UpOptions(enumsGenerator);
            Add_ConfigOptions(enumsGenerator);
            Add_BuildOptions(enumsGenerator);
            Add_PortOptions(enumsGenerator);
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
            item.Tags["name"] = "build";
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
                .WithEnum("Docker.DockerComposeCommon", optionsToParse)
                .WithStringValue("--file", "alternate compose file")
                .WithEnumValue("--log-level", "DEBUG, INFO, WARNING, ERROR, CRITICAL".Split(","))
                .WithStringValue("--tlscacert", "Trust certs signed only by this CA")
                .WithStringValue("--tlscert", "Path to TLS certificate file")
                .WithStringValue("--tlskey", "Path to TLS key file")
                .WithStringValue("--project-name", "alternate project name")
                .WithStringValue("--host", "daemon socket to connect to")
                .WithStringValue("--project-directory", "alternate working directory");
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
                .WithIntegerValue("--scale")
                .WithIntegerValue("--timeout", "timeout in seconds")
                .WithStringValue("--exit-code-from", "service name");
            item.Tags["name"] = "up";
            CommonSetup(item);
        }
        
         private static void Add_PortOptions(EnumsGenerator enumsGenerator)
         {
             const string optionsToParse = @"
    --protocol=proto  tcp or udp [default: tcp]
    --index=index     index of the container if there are multiple
                      instances of a service [default: 1]
";
             var item = enumsGenerator
                 .WithEnum("Docker.DockerComposePort", optionsToParse)
                 .WithIntegerValue("--index")
                 .WithEnumValue("--protocol", "tcp,udp".Split(','));
            item.Tags["name"] = "port";
            CommonSetup(item);
        }
        
           private static void Add_ConfigOptions(EnumsGenerator enumsGenerator)
        {
            const string optionsToParse = @"
    --resolve-image-digests  Pin image tags to digests.
    --no-interpolate         Don't interpolate environment variables.
    -q, --quiet              Only validate the configuration, don't print
                             anything.
    --services               Print the service names, one per line.
    --volumes                Print the volume names, one per line.
    --hash=servicesOrWild    Print the service config hash, one per line.
                             Set ""service1,service2"" for a list of specified services
                             or use the wildcard symbol to display all services.
";
            var item = enumsGenerator
                .WithEnum("Docker.DockerComposeConfig", optionsToParse)
                .WithStringValue("--hash", "services");
            item.Tags["name"] = "config";
            CommonSetup(item);
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            var isCommon = item.EnumName == "DockerComposeCommon";
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\_dockerCompose\\{2}");
            if (isCommon)
                item.WithInterface<ICommandsPartsProvider>();
            else
            {
                item.WithInterface<IDockerComposeOption>();
                var name = item.Tags["name"];
                item.AddCustomCreator(c =>
                {
                    var p = c.AddProperty("Name", "string")
                        .WithIsPropertyReadOnly()
                        .WithNoEmitField()
                        .WithOwnGetter(name.CsEncode());
                    p.OwnGetterIsExpression = true;
                });
            }

            item.AddCustomCreator(c =>
            {
                c.AddMethod("GetItems", c.GetTypeName(typeof(IEnumerable<string>)))
                    .WithBody("return GetCodeItems();");
            });
           
        }
    }
}