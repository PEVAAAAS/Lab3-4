using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal abstract class GameObject
    {
        public GameObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {  get; set; }
        public int Y { get; set; }

        public bool IsCross(GameObject other)
        {
            Rectangle rect1 = new Rectangle(X, Y, Settings.Size, Settings.Size);
            Rectangle rect2 = new Rectangle(other.X, other.Y, Settings.TankSize, Settings.TankSize);
            if (rect1.IntersectsWith(rect2))
            {
                return true;
            }
            return false;
        }
        public abstract void Draw(Graphics graphics);
    }
}
