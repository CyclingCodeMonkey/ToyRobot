
namespace ToyRobotConsole
{
    public interface IRobot
    {
        bool Place(int x, int y, Compass direction);
        void Turn(Direction direction);
        void Move();
        string Report();
    }
}
