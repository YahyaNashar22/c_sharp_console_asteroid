using System;
using System.Collections.Generic;
using System.Text;

namespace Asteroid
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; }
        public char Symbol { get; }

        public Player(int startX, int startY, char symbol)
        {
            X = startX;
            Y = startY;
            Symbol = symbol;
        }

        public void MoveLeft(int minX)
        {
            if (X > minX)
            {
                X--;
            }
        }
        public void MoveRight(int maxX)
        {
            if (X < maxX)
            {
                X++;
            }
        }

        public Bullet Shoot()
        {
            return new Bullet(X, Y - 1, GameSettings.BulletSymbol);
        }
    }
}
