namespace iSukces.SimpleLinux.Docker
{
    public interface IDockerComposeOption:ICommandsPartsProvider
    {
        string Name { get; }
    }
}