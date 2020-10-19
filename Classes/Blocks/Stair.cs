using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Stair:IStair
    {
        public Vector2 Position { get; set; }
        public Direction Destination { get; set; }
        private int width;
        private int height;

        public Stair(int x, int y, int direction)
        {
            Position = new Vector2(x, y);
            this.width = 40;
            this.height = 40;
            if (direction==0)
                this.Destination = Direction.DOWN;
            else
                this.Destination = Direction.UP;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }
          public void CollidedWithLink(IPlayer link, Direction direction)
        {
            LinkStairCollision.UpateLocation(link, this, direction);
        }
        public void CollidedWithProjectile(IProjectile projectile, Direction direction)
        {
            ProjectileStairCollision.UpateLocation(projectile, this, direction);
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) { }
    }
}
