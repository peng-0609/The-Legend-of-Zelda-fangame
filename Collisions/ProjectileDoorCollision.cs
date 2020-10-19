using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileDoorCollision
    {
        public static void HandleCollision(IProjectile Projectile, IDoor Door, Direction direction)
        {
            Door.CollidedWithProjectile(Projectile, direction);
        }
        public static void UpateLocation(IProjectile Projectile, IDoor Door, Direction direction)
        {
            if (!Projectile.Name.Equals("Bomb"))
            {
                switch (direction)
                {
                    case Direction.UP:
                        Projectile.Position = new Vector2(Projectile.Position.X, Door.Position.Y - Projectile.GetRectangle().Height);
                        Projectile.CollidedWithDoor();
                        break;

                    case Direction.LEFT:
                        Projectile.Position = new Vector2(Door.Position.X - Projectile.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithDoor();
                        break;

                    case Direction.RIGHT:
                        Projectile.Position = new Vector2(Door.Position.X + Door.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithDoor();
                        break;

                    case Direction.DOWN:
                        Projectile.Position = new Vector2(Projectile.Position.X, Door.Position.Y + Door.GetRectangle().Height);
                        Projectile.CollidedWithDoor();
                        break;
                }
            }
        }
    }
}
