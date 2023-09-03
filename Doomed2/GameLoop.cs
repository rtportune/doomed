using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doomed2
{
    public class GameLoop
    {
        private const int UpdateRate = 1000 / 60;

        private Game _game;
        private DateTime _lastUpdate;
        private Thread _gameThread;

        public bool IsRunning { get; private set; }

        public void Load(Game gameObj)
        {
            _game = gameObj;
            _game.Load();
        }

        public void Start()
        {
            if (_game == null) throw new Exception("No game");

            IsRunning = true;

            _gameThread = new Thread(GameThread);
            _gameThread.SetApartmentState(ApartmentState.STA);
            _gameThread.Start();
        }

        public void GameThread()
        {
            while (IsRunning)
            {
                var elapsed = DateTime.Now - _lastUpdate;
                if (elapsed.TotalMilliseconds > UpdateRate)
                {
                    _lastUpdate = DateTime.Now;

                    _game.Update(elapsed);
                }
            }
        }

        public void Stop()
        {
            IsRunning = false;
            _game.Unload();
        }
    }
}
