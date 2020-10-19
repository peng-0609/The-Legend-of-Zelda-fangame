using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class ProjectileBlockCollision
    {
        public static void HandleCollision(IProjectile Projectile, IBlock Block, Direction direction)
        {
            Block.CollidedWithProjectile(Projectile, direction);
        }
        public static void UpateLocation(IProjectile Projectile, IBlock Block, Direction direction)
        {
            if (!Projectile.Name.Equals("Bomb"))
            {
                switch (direction)
                {
                    case Direction.UP:
                        Projectile.Position = new Vector2(Projectile.Position.X, Block.Position.Y - Projectile.GetRectangle().Height);
                        Projectile.CollidedWithBlock();
                        break;

                    case Direction.LEFT:
                        Projectile.Position = new Vector2(Block.Position.X - Projectile.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithBlock();
                        break;

                    case Direction.RIGHT:
                        Projectile.Position = new Vector2(Block.Position.X + Block.GetRectangle().Width, Projectile.Position.Y);
                        Projectile.CollidedWithBlock();
                        break;

                    case Direction.DOWN:
                        Projectile.Position = new Vector2(Projectile.Position.X, Block.Position.Y + Block.GetRectangle().Height);
                        Projectile.CollidedWithBlock();
                        break;
                }
            }
                

        }
    }
}
