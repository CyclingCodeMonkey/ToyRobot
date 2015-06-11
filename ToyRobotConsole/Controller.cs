using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotConsole
{
    public class Controller : IController
    {
        private const char Delimiter = ' ';
        private const char SubDelimiter = ',';
        readonly List<string> _validCommands = new List<string> { "PLACE", "MOVE", "REPORT", "LEFT", "RIGHT" };
        readonly List<string> _validDirections = new List<string> { "NORTH", "SOUTH", "EAST", "WEST" };

        private readonly Map _map;
        private IRobot _robot;

    	public Controller(Map map)
    	{
    	    _map = map;
    	}
        /// <summary>
        /// this contructor is for the purpose of mocking only
        /// </summary>
        /// <param name="map"></param>
        /// <param name="robot"></param>
        public Controller(Map map, IRobot robot)
        {
            _map = map;
            _robot = robot;
        }

    	public string Command(string command)
    	{
    	    if (string.IsNullOrWhiteSpace(command)) return string.Empty;

            var words = command.ToUpper().Split(Delimiter);
            if (!IsValidCommand(words[0])) return string.Empty;

    	    // must be a place, move or report
    	    if (_robot != null && words[0] == "MOVE")
    	    {
    	        _robot.Move();
    	    }
    	    else if (_robot != null && words[0] == "REPORT")
    	    {
    	        return _robot.Report();
    	    }
            else if (_robot != null && (words[0] == "LEFT" || words[0] == "RIGHT"))
            {
                _robot.Turn(GetDirection(words[0]));
            }
            else
    	    {
                PlaceRobot(words);
    	    }
    	    return string.Empty;
    	}

        private void PlaceRobot(IList<string> words)
        {
            if (words.Count() < 2) return;

            var location = words[1].Split(SubDelimiter);
            if (location.Count() != 3) return;

            int x;
            int y;
            
            if (!int.TryParse(location[0], out x) || !int.TryParse(location[1], out y)) return;

            if (!_map.IsOnMap(x, y) || !IsValidDirection(location[2])) return;

            _robot = new Robot(_map);
            _robot.Place(x, y, GetCompass(location[2]));
        }


        private bool IsValidCommand(string word)
    	{
    	    return !string.IsNullOrEmpty(word) && _validCommands.Contains(word.Trim(), StringComparer.CurrentCultureIgnoreCase);
    	}

        private bool IsValidDirection(string word)
        {
            return !string.IsNullOrEmpty(word) && _validDirections.Contains(word.Trim(), StringComparer.CurrentCultureIgnoreCase);
        }

        private Compass GetCompass(string direction)
        {
            if (direction == "WEST")
                return Compass.West;
            if (direction == "EAST")
                return Compass.East;
            return direction == "SOUTH" ? Compass.South : Compass.North;
        }

        private Direction GetDirection(string word)
        {
            return word == "LEFT" ? Direction.Left : Direction.Right;
        }
    }
}
