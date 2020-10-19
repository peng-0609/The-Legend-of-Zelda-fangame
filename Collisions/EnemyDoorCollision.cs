using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class EnemyDoorCollision
    {
        public static void HandleCollision(IEnemy enemy, IDoor door, Direction direction)
        {
            door.CollidedWithEnemy(enemy, direction);
        }
        public static void UpateLocation(IEnemy enemy, IDoor door, Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    enemy.Position = new Vector2(enemy.Position.X, door.Position.Y - enemy.GetRectangle().Height);
                    enemy.CollidedWithDoor();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.LEFT:
                    enemy.Position = new Vector2(door.Position.X - enemy.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithDoor();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.RIGHT:
                    enemy.Position = new Vector2(door.Position.X + door.GetRectangle().Width, enemy.Position.Y);
                    enemy.CollidedWithDoor();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;

                case Direction.DOWN:
                    enemy.Position = new Vector2(enemy.Position.X, door.Position.Y + door.GetRectangle().Height);
                    enemy.CollidedWithDoor();
                    enemy.Enemyphysics.Velocity = new Vector2(0, 0);
                    break;
            }

        }
    }
}
