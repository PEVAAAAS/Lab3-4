using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class EnemyTank : Tank
    {
        public EnemyTank(int x, int y, TankType type, Direction moveDirection) : base(x, y, type, moveDirection)
        {
        }

        public override void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
