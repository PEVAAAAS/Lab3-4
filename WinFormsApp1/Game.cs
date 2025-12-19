using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    internal class Game
    {
        private Bonus bonus;
        private PlayerTank player;
        private List<GameObject> gameObjects = new List<GameObject>();
        private int width;
        private int height;

        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void LoadLevel(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int x = 0, y = 0;
            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'B':
                            {
                                Wall wall = new Wall(x, y, WallType.Brick);
                                gameObjects.Add(wall);
                                break;
                            }
                        case 'S':
                            {
                                Wall wall = new Wall(x, y, WallType.Steal);
                                gameObjects.Add(wall);
                                break;
                            }
                        case 'F':
                            {
                                Wall wall = new Wall(x, y, WallType.Forest);
                                gameObjects.Add(wall);
                                break;
                            }
                        case 'W':
                            {
                                Wall wall = new Wall(x, y, WallType.Water);
                                gameObjects.Add(wall);
                                break;
                            }
                        case 'H':
                            {
                                Eagle eagle = new Eagle(x, y);
                                gameObjects.Add(eagle);
                                player = new PlayerTank(x-2*Settings.Size, y,TankType.Basic,Direction.North);
                                break;
                            }
                    }
                    x += Settings.Size;
                }
                x = 0;
                y += Settings.Size;
            }

        }
        public void ReplaceEagleWalls(WallType type)
        {
            Eagle eagle = gameObjects.OfType<Eagle>().FirstOrDefault();
            for (int i = eagle.X-1*Settings.Size; i <= eagle.X+1*Settings.Size; i+= Settings.Size)
            {
                for (int j = eagle.Y-1*Settings.Size; j <= eagle.Y; j+= Settings.Size)
                {
                    if(i == eagle.X && j == eagle.Y)
                    {
                        continue;
                    }
                    gameObjects.RemoveAll(t => t.X == i && t.Y == j);
                    Wall wall = new Wall(i, j, type);
                    gameObjects.Add(wall);
                }
            }
        }
        public bool Tick()
        {
            if(bonus != null)
            {
                if(bonus.PowerType == PowerUp.Helm)
                {
                    player.Invincible -= 1;
                    if(player.Invincible == 0)
                    {
                        return true;
                    }
                }
                if(bonus.PowerType == PowerUp.Shovel)
                {
                    Eagle eagle = gameObjects.OfType<Eagle>().FirstOrDefault();
                    eagle.Defence -= 1;
                    if(eagle.Defence == 0)
                    {
                        ReplaceEagleWalls(WallType.Brick);
                    }
                }
            }
            return false;
        }
        public void MovePlayer(Direction direction)
        {
            player.MoveTank(direction);
            if(player.X < 0)
            {
                player.X = 0;
            }
            if(player.Y < 0)
            {
                player.Y = 0;
            }
            if(player.X+Settings.Size > width)
            {
                player.X = width - Settings.Size;
            }
            if(player.Y+Settings.Size > height)
            {
                player.Y = height - Settings.Size;
            }
            if(bonus != null&& bonus.IsCross(player))
            {
                if(bonus.PowerType == PowerUp.Helm)
                {
                    player.Invincible = 10;
                    bonus = null;
                }
                else if(bonus.PowerType==PowerUp.Shovel)
                {
                    Eagle eagle = gameObjects.OfType<Eagle>().FirstOrDefault();
                    eagle.Defence = 20;
                    ReplaceEagleWalls(WallType.Steal);
                    bonus = null;
                }
            }
            if (gameObjects.Any(t => t.IsCross(player)))
            {
                GameObject obj = gameObjects.First(t=>t.IsCross(player));

                if(direction == Direction.North)
                {
                    if(player.Y < obj.Y+Settings.Size)
                    {
                        player.Y = obj.Y+Settings.Size;
                    }
                }
                else if(direction == Direction.South)
                {
                    if(player.Y > obj.Y-Settings.Size)
                    {
                        player.Y=obj.Y-Settings.Size;
                    }
                }
                else if(direction == Direction.West)
                {
                    if(player.X < obj.X+Settings.Size)
                    {
                        player.X = obj.X+Settings.Size;
                    }
                }
                else if(direction== Direction.East)
                {
                    if(player.X > obj.X-Settings.Size)
                    {
                        player.X = obj.X-Settings.Size;
                    }
                }

            }
        }
        public void SpawnPowerUp(PowerUp powerUp)
        {
            if(bonus != null)
            {
                return;
            }
            Random random = new Random();
            while (true)
            {
                int x = random.Next(0, width/Settings.Size) * Settings.Size;
                int y = random.Next(0, height/Settings.Size) * Settings.Size;
                if(!gameObjects.Any(t=>t.X == x && t.Y == y))
                {
                    bonus = new Bonus(x, y, powerUp);
                    break;
                }
            }
        }
        public void NullPowerUp()
        {
            bonus = null;
        }
        public void Draw(Graphics graphics)
        {
            foreach (var item in gameObjects)
            {
                item.Draw(graphics);
            }
            player.Draw(graphics);
            if (bonus != null)
            {
                bonus.Draw(graphics);
            }
        }
    }
}
