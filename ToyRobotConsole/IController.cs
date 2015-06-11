
namespace ToyRobotConsole
{
    public interface IController
    {
        // validate command
        // on start or place validate and create new robot if no robot 
        // issue command

        string Command(string instruction);
    }
}
