using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doomed2
{
    public partial class GameWindow : Form
    {
        private Timer _graphicsTimer;
        private RectangleF _screenBounds;
        private Game _game;
        private GameLoop _gameLoop;

        public GameWindow()
        {
            InitializeComponent();

            //60fps timer
            _graphicsTimer = new Timer() { Interval = 1000 / 60 };
            _graphicsTimer.Tick += OnGraphicsTimer_Tick;
        }

        #region Local Events
        private void OnGameWindow_Paint(object sender, PaintEventArgs e)
        {
            if (_game.Renderer != null)
            {
                _game.Renderer.Draw(e.Graphics, _game.Player, _game.Map);
            }
        }

        private void OnGameWindow_Load(object sender, EventArgs e)
        {
            _screenBounds = new RectangleF(0, 0, Width, Height);
            _game = new Game();

            _gameLoop = new GameLoop();
            _gameLoop.Load(_game);
            _game.Renderer.RenderResolution = _screenBounds;

            _gameLoop.Start();

            _graphicsTimer.Start();
        }

        private void OnGraphicsTimer_Tick(object sender, EventArgs e)
        {
            //Initiate a draw call
            Invalidate();
        }
        private void OnGameWindow_Resize(object sender, EventArgs e)
        {
            _screenBounds = new RectangleF(0, 0, Width, Height);
            _game.Renderer.RenderResolution = _screenBounds;
        }
        private void OnGameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gameLoop?.Stop();
        }
        #endregion

    }
}
