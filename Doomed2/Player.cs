using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Doomed
{
    public class Player
    {
        public Point Position { get; set; }
        public double Heading { get; set; }
        public int FOV { get; set; }
    }
}
