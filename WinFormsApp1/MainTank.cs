using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class PlayerTank : Tank
    {
        public int Lives {  get; set; }
        public PlayerTank(int x, int y, TankType type, Direction moveDirection) : base(x, y, type, moveDirection)
        {
            Lives = 3;
        }

        public override void Draw(Graphics graphics)
        {
            if(MoveDirection == Direction.North)
            {
                graphics.DrawImage(Resource1.SmallTankPlayerUp, X, Y, Settings.TankSize, Settings.TankSize);
            }
            else if(MoveDirection == Direction.South)
            {
                graphics.DrawImage(Resource1.SmallTankPlayerDown, X, Y, Settings.TankSize, Settings.TankSize);
            }
            else if(MoveDirection == Direction.West)
            {
                graphics.DrawImage(Resource1.SmallTankPlayerLeft, X, Y, Settings.TankSize, Settings.TankSize);
            }
            else if(MoveDirection == Direction.East)
            {
                graphics.DrawImage(Resource1.SmallTankPlayerRight, X, Y, Settings.TankSize, Settings.TankSize);
            }
        }
    }
}
