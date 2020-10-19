using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyBlockCollision
    {
        public static void HandleCollision(IEnemy enemy, IBlock block, Direction direction)
        {
            block.CollidedWithEnemy(enemy, direction);
        }
        public static void UpateLocation(IEnemy enemy, IBlock block, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    enemy.Position = new Vector2(enemy.Position.X, block.Position.Y - enemy.GetRectangle().Height);
                    enemy.CollidedWithBlock();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.LEFT:
                    enemy.Position = new Vector2(block.Position.X - enemy.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithBlock();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.RIGHT:
                    enemy.Position = new Vector2(block.Position.X + block.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithBlock();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    enemy.Position = new Vector2(enemy.Position.X, block.Position.Y + block.GetRectangle().Height);
                    enemy.CollidedWithBlock();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
