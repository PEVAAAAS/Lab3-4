using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Bonus : GameObject
    {
        private PowerUp powerType;
        public PowerUp PowerType { get { return powerType; } }
        public Bonus(int x, int y, PowerUp powerType) : base(x, y)
        {
            this.powerType = powerType;
        }

        public override void Draw(Graphics graphics)
        {
            if(powerType == PowerUp.Clock)
            {
                graphics.DrawImage(Resource1.Timer, X, Y, Settings.Size, Settings.Size);
            }
            else if(powerType == PowerUp.Helm)
            {
                graphics.DrawImage(Resource1.Helmet, X, Y, Settings.Size, Settings.Size);
            }
            else if(powerType == PowerUp.Grenade)
            {
                graphics.DrawImage(Resource1.Grenade,X,Y, Settings.Size, Settings.Size);
            }
            else if(powerType == PowerUp.Tank)
            {
                graphics.DrawImage(Resource1.Tank, X, Y, Settings.Size, Settings.Size);
            }
            else if(powerType == PowerUp.Star)
            {
                graphics.DrawImage(Resource1.Star, X, Y, Settings.Size, Settings.Size);
            }
            else
            {
                graphics.DrawImage(Resource1.Shovel, X, Y, Settings.Size, Settings.Size);
            }
        }
    }
}
