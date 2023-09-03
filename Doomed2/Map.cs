using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doomed2
{
    public class Map
    {
        private List<(Point startPoint, Point endPoint)> _walls;

        public List<(Point startPoint, Point endPoint)> Walls => _walls;

        public Map()
        {
            _walls = new List<(Point startPoint, Point endPoint)>();
        }

        public void Load(string mapFile)
        {
            //eventually, load map data from file. For now hard code it
            _walls.Add((new Point(-10, -10), new Point(10, -10)));
            _walls.Add((new Point(10, -10), new Point(10, 10)));
            _walls.Add((new Point(10, 10), new Point(-10, 10)));
            _walls.Add((new Point(-10, 10), new Point(-10, -10)));
        }
    }
}
