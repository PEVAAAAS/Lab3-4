using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Wall : GameObject
    {
        public WallType Type{ get; set; }
        public Wall(int x, int y, WallType type) : base(x, y)
        {
            Type = type;
        }

        public override void Draw(Graphics graphics)
        {
            if (Type == WallType.Brick)
            {
                graphics.DrawImage(Resource1.BrickWall, X, Y, Settings.Size, Settings.Size);
            }
            else if (Type == WallType.Steal) {
                graphics.DrawImage(Resource1.StealWall, X, Y, Settings.Size, Settings.Size);
            }
            else if (Type == WallType.Water)
            {
                graphics.DrawImage(Resource1.Water, X, Y, Settings.Size, Settings.Size);
            }
            else if (Type == WallType.Forest)
            {
                graphics.DrawImage(Resource1.Forest, X,Y, Settings.Size, Settings.Size);
            }

        }
    }
}
