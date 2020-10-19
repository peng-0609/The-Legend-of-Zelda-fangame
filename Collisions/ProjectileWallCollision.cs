using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileWallCollision
    {
        public static void HandleCollision(IProjectile Projectile, IWall wall, Direction direction)
        {
            wall.CollidedWithProjectile(Projectile, direction);
        }
        public static void UpateLocation(IProjectile Projectile, IWall wall, Direction direction)
        {
            if (!Projectile.Name.Equals("Bomb"))
            {
                switch (direction)
                {
                    case Direction.UP:
                        Projectile.Position = new Vector2(Projectile.Position.X, wall.Position.Y - Projectile.GetRectangle().Height);
                        Projectile.CollidedWithWall();
                        break;

                    case Direction.LEFT:
                        Projectile.Position = new Vector2(wall.Position.X - Projectile.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithWall();
                        break;

                    case Direction.RIGHT:
                        Projectile.Position = new Vector2(wall.Position.X + wall.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithWall();
                        break;

                    case Direction.DOWN:
                        Projectile.Position = new Vector2(Projectile.Position.X, wall.Position.Y + wall.GetRectangle().Height);
                        Projectile.CollidedWithWall();
                        break;
                }
            }
        }
    }
}
