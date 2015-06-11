using System;

namespace ToyRobotConsole
{
    public class Map
    {
        private readonly int _height;
        private readonly int _width;
        
        public Map(int width, int height)
        {
            //check the width and height > 0
            if (height < 1)
                throw new ArgumentException("Invalid value, values must be > 0", "height");
            if (width < 1)
                throw new ArgumentException("Invalid value, values must be > 0", "width");

            _width = width;
            _height = height;
            
        }

        public bool IsOnMap(int x, int y)
        {
            if (x < 0 || y < 0) return false;
            if (_height < 1 || _width < 1) return false;

            return (x < _width && y < _height);
        }
    }
}
