using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1;

namespace WinFormsApp1
{
    internal abstract class Tank : GameObject
    {
        public Tank(int x, int y, TankType type, Direction moveDirection) : base(x, y)
        {
            Type = type;
            MoveDirection = moveDirection;
        }
        public TankType Type { get; set; }
        public Direction MoveDirection { get; set; }
        public int Speed()
        {
            if(Type == TankType.Basic)
            {
                return 1;
            }
            else if(Type == TankType.Light)
            {
                return 2;
            }
            else if(Type == TankType.Medium)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
        public void MoveTank(Direction direction)
        {
            MoveDirection = direction;
            if (direction == Direction.North)
            {
                Y -= Speed();
            }
            else if (direction == Direction.South)
            {
                Y += Speed();
            }
            else if (direction == Direction.West)
            {
                X -= Speed();
            }
            else
            {
                X += Speed();
            }
        }
        
    }
}
