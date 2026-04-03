using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroid
{
    public class Asteroid
    {
        public int X { get; }
        public int Y { get; private set; }
        public char Symbol { get; }
        public bool IsActive { get; private set; }

        public Asteroid(int startX, int startY, char symbol)
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
            IsActive = true;
        }

        public void Update()
        {
            Y += GameSettings.AsteroidSpeed;
            if ( Y >= GameSettings.Height -1 )
            {
                IsActive = false;
            }
        }
    }
}
