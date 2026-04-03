using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroid
{
    public class Game
    {
        private readonly int _width;
        private readonly int _height;

        private bool _isRunning;
        private readonly Player _player;
        private readonly List<Bullet> _bullets;

        public Game()
        {
            _width = GameSettings.Width;
            _height = GameSettings.Height;

            int playerStartX = _width / 2;
            int playerStartY = _height - 2;

            _player = new Player(playerStartX, playerStartY, GameSettings.PlayerSymbol);
            _bullets = new List<Bullet>();
        }

        public void Run()
        {
            InitializeConsole();
            _isRunning = true;

            while (_isRunning)
            {
                HandleInput();
                Update();
                Render();

                Thread.Sleep(GameSettings.FrameDelayMs);
            }
        }

        private void InitializeConsole()
        {
            Console.CursorVisible = false;
            Console.Clear();
        }

        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(intercept: true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        _player.MoveLeft(minX: 1);
                        break;

                    case ConsoleKey.RightArrow:
                        _player.MoveRight(maxX: _width - 2);
                        break;

                    case ConsoleKey.Spacebar:
                        _bullets.Add(_player.Shoot());
                        break;

                    case ConsoleKey.Escape:
                        _isRunning = false;
                        break;
                }
            }
        }

        private void Update()
        {
            UpdateBullets();
            RemoveInactiveBullets();
        }

        private void UpdateBullets()
        {
            foreach (Bullet bullet in _bullets)
            {
                bullet.Update();
            }
        }

        private void RemoveInactiveBullets()
        {
            _bullets.RemoveAll(bullet => !bullet.IsActive);
        }

        private void Render()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder buffer = new StringBuilder();

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {

                    if (IsBorder(x, y))
                    {
                        buffer.Append('#');
                    }
                    else if (IsPlayerAtPosition(x,y))
                    {
                        buffer.Append(_player.Symbol);
                    }
                    else if (TryGetBulletAtPosition(x, y, out Bullet? bullet))
                    {
                        buffer.Append(bullet!.Symbol);
                    }
                    else
                    {
                        buffer.Append(' ');
                    }
                }
                buffer.AppendLine();
            }
            buffer.Append($"Use Left/Right arrows to move, ESC to quit");

            Console.Write(buffer.ToString());
        }

        private bool IsBorder(int x, int y)
        {
            return y == 0 ||
                    y == _height - 1 ||
                    x == 0 ||
                    x == _width - 1;

        }

        private bool IsPlayerAtPosition(int x, int y)
        {
            return x == _player.X && y == _player.Y;
        }

        private bool TryGetBulletAtPosition(int x, int y, out Bullet? foundBullet)
        {
            foreach (Bullet bullet in _bullets)
            {
                if (bullet.X == x && bullet.Y == y && bullet.IsActive)
                {
                    foundBullet = bullet;
                    return true;
                }
            }
            foundBullet = null;
            return false;
        }
    }
}



