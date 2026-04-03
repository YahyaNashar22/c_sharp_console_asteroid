using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroid
{
    public static class GameSettings
    {
        public const int Width = 40;
        public const int Height = 40;
        public const int FrameDelayMs = 50;

        public const char PlayerSymbol = 'A';
        public const char BulletSymbol = '|';
        public const char AsteroidSymbol = 'O';

        public const int BulletSpeed = 1;
        public const int AsteroidSpeed = 1;

        public const int AsteroidSpawnIntervalFrames = 10;
    }
}
