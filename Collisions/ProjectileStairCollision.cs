using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileStairCollision
    {
        public static void HandleCollision(IProjectile Projectile, IStair Stair, Direction direction)
        {
            Stair.CollidedWithProjectile(Projectile, direction);
        }
        public static void UpateLocation(IProjectile Projectile, IStair Stair, Direction direction)
        {
            if (!Projectile.Name.Equals("Bomb"))
            {
                switch (direction)
                {
                    case Direction.UP:
                        Projectile.Position = new Vector2(Projectile.Position.X, Stair.Position.Y - Projectile.GetRectangle().Height);
                        Projectile.CollidedWithStair();
                        break;

                    case Direction.LEFT:
                        Projectile.Position = new Vector2(Stair.Position.X - Projectile.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithStair();
                        break;

                    case Direction.RIGHT:
                        Projectile.Position = new Vector2(Stair.Position.X + Stair.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithStair();
                        break;

                    case Direction.DOWN:
                        Projectile.Position = new Vector2(Projectile.Position.X, Stair.Position.Y + Stair.GetRectangle().Height);
                        Projectile.CollidedWithStair();
                        break;
                }
            }

        }
    }
}
