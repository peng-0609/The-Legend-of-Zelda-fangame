using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyWaterCollision
    {
        public static void HandleCollision(IEnemy enemy, IWater water, Direction direction)
        {
            water.CollidedWithEnemy(enemy, direction);
        }
        public static void UpateLocation(IEnemy enemy, IWater water, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    enemy.Position = new Vector2(enemy.Position.X, water.Position.Y - enemy.GetRectangle().Height);
                    enemy.CollidedWithWater();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.LEFT:
                    enemy.Position = new Vector2(water.Position.X - enemy.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithWater();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.RIGHT:
                    enemy.Position = new Vector2(water.Position.X + water.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithWater();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    enemy.Position = new Vector2(enemy.Position.X, water.Position.Y + water.GetRectangle().Height);
                    enemy.CollidedWithWater();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
