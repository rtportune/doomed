using Doomed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Doomed2
{
    public class Game
    {
        private const double RotationSpeed = 90;
        private const double MoveSpeed = 10;

        private Renderer _renderer;
        private Player _player;
        private Map _map;

        public Renderer Renderer => _renderer;
        public Player Player => _player;
        public Map Map => _map;

        public void Load() 
        {
            _renderer = new Renderer(); 
            _player = new Player();
            _player.Position = new System.Windows.Point(0, 0);
            _player.Heading = 0;
            _player.FOV = 60;
            _map = new Map();
            _map.Load(null);
        }

        public void Unload() 
        { 
            //clean up
        }

        public void Update(TimeSpan timeStep) 
        {
            var elapsed = timeStep.TotalMilliseconds / 1000;

            //update game things
            if (Keyboard.IsKeyDown(Key.Q))
            {
                var dTheta = RotationSpeed * elapsed;
                var newPlayerHeading = _player.Heading - dTheta;
                if (newPlayerHeading < 0) newPlayerHeading = 360 + newPlayerHeading;

                _player.Heading = newPlayerHeading;
            }
            else if (Keyboard.IsKeyDown(Key.E))
            {
                var dTheta = RotationSpeed * elapsed;
                var newPlayerHeading = _player.Heading + dTheta;
                if (newPlayerHeading > 360) newPlayerHeading = newPlayerHeading - 360;

                _player.Heading = newPlayerHeading;
            }
            else if (Keyboard.IsKeyDown(Key.W))
            {
                var dirVector = new Vector(Math.Cos(_player.Heading * Math.PI / 180), Math.Sin(_player.Heading * Math.PI / 180));
                dirVector.Normalize();

                _player.Position = new Point(_player.Position.X + (dirVector.X * MoveSpeed * elapsed), _player.Position.Y + (dirVector.Y * MoveSpeed * elapsed));
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                var dirVector = new Vector(Math.Cos(_player.Heading * Math.PI / 180), Math.Sin(_player.Heading * Math.PI / 180));
                dirVector.Normalize();

                _player.Position = new Point(_player.Position.X - (dirVector.X * MoveSpeed * elapsed), _player.Position.Y - (dirVector.Y * MoveSpeed * elapsed));
            }
        }
    }
}
