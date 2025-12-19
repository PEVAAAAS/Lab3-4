using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Eagle : GameObject
    {
        private bool defeat;
        public int Defence {  get; set; }
        public Eagle(int x, int y) : base(x, y)
        {
        }
        public void GameOver()
        {
            defeat = true;
        }
        public override void Draw(Graphics graphics)
        {
            if (defeat == true)
            {
                graphics.DrawImage(Resource1.Eagle2, X, Y, Settings.Size, Settings.Size);
            }
            else
            {
                graphics.DrawImage(Resource1.Eagle, X, Y, Settings.Size, Settings.Size); 
            }
        }
    }
}
