using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroid
{
    public class Bullet
    {
        public int X { get; }
        public int Y { get; private set; }
        public char Symbol { get;  }
        public bool IsActive { get; private set; }

        public Bullet(int startX, int startY, char symbol)
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
            IsActive = true;
        }

        public void Update()
        {
            Y -= GameSettings.BulletSpeed;
            if (Y <= 0)
            {
                IsActive = false;
            }
        }
    }
}
