using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyWallCollision
    {
        public static void HandleCollision(IEnemy enemy, IWall wall, Direction direction)
        {
            wall.CollidedWithEnemy(enemy, direction);
        }
        public static void UpateLocation(IEnemy enemy, IWall wall, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    enemy.Position = new Vector2(enemy.Position.X, wall.Position.Y - enemy.GetRectangle().Height);
                    enemy.CollidedWithWall();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.LEFT:
                    enemy.Position = new Vector2(wall.Position.X - enemy.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithWall();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.RIGHT:
                    enemy.Position = new Vector2(wall.Position.X + wall.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithWall();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    enemy.Position = new Vector2(enemy.Position.X, wall.Position.Y + wall.GetRectangle().Height);
                    enemy.CollidedWithWall();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
