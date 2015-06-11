
namespace ToyRobotConsole
{
    public class Robot : IRobot
    {
        int _locationX;
        int _locationY;
        Compass _facing;
        readonly Map _map;

        public Robot(Map map)
        {
            _map = map;
        }

        public bool Place(int x, int y, Compass direction)
        {
            if (_map.IsOnMap(x,y))
            {
                _locationX = x;
                _locationY = y;
                _facing = direction;
                return true;
            }
            return false;
        }

        public void Turn(Direction direction)
        {
            _facing = direction == Direction.Left ? RotateLeft(_facing) : RotateRight(_facing);
        }

        public void Move()
        {
            // depending on the direction increment either X or Y as long as it does not exceed Map parameters
            if (_facing == Compass.North && _map.IsOnMap(_locationX, _locationY + 1))
                _locationY++;

            if (_facing == Compass.East && _map.IsOnMap(_locationX + 1, _locationY))
                _locationX++;

            if (_facing == Compass.South && _map.IsOnMap(_locationX, _locationY - 1))
                _locationY--;

            if (_facing == Compass.West &&  _map.IsOnMap(_locationX - 1, _locationY))
                _locationX--;
        }

        public string Report()
        {
            return string.Format("{0}, {1}, {2}", _locationX, _locationY, _facing.ToString().ToUpper());
        }

        private static Compass RotateLeft(Compass facing)
        {
            if (facing == Compass.North)
                return Compass.West;
            if (facing == Compass.West)
                return Compass.South;
            if (facing == Compass.South)
                return Compass.East;
            return Compass.North;
        }

        private static Compass RotateRight(Compass facing)
        {
            if (facing == Compass.North)
                return Compass.East;
            if (facing == Compass.East)
                return Compass.South;
            if (facing == Compass.South)
                return Compass.West;
            return Compass.North;
        }
    }
}
