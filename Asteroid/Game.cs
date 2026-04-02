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

        public Game()
        {
            _width = GameSettings.Width;
            _height = GameSettings.Height;

            int playerStartX = _width / 2;
            int playerStartY = _height - 2;

            _player = new Player(playerStartX, playerStartY, GameSettings.PlayerSymbol);
        }

        public void Run()
        {
            InitializeConsole();
            _isRunning = true;

            while(_isRunning)
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
            while(Console.KeyAvailable)
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

                    case ConsoleKey.Escape:
                        _isRunning = false;
                        break;
                }
            }
        }

        private void Update()
        {

        }

        private void Render()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder buffer = new StringBuilder();

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    bool isBorder =
                        y == 0 ||
                        y == _height - 1 ||
                        x == 0 ||
                        x == _width - 1;

                    if ( isBorder )
                    {
                        buffer.Append('#');
                    }
                    else if (x == _player.X && y == _player.Y)
                    {
                        buffer.Append(_player.Symbol);
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
    }
}



