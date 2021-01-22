# SimpleLinux
Helps with creating linux related files


## Docker compose command
Try 
```
var cmd = new DockerComposeCommand
{
    Option = new DockerComposeUpOptions()
        .WithRemoveOrphans()
        .WithDetach()
        .WithBuild(),
    Common = new DockerComposeCommonOptions()
       .WithVerbose()
};
var dockerComposeCommand = cmd.GetCode();
```
the return value is
```
docker-compose --verbose up -d --build --remove-orphans
```
