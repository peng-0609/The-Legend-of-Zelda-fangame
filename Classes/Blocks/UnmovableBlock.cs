using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class UnmovableBlock : IWall
    {
        public Vector2 Position { get; set; }
        private int width;
        private int height;

        public UnmovableBlock(int x, int y, int width, int height)
        {
            Position = new Vector2(x, y);
            this.width = width;
            this.height = height;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, width, height);
        }
        public void CollidedWithLink(IPlayer link, Direction direction)
        {
            LinkWallCollision.UpateLocation(link, this, direction);
        }

        public void CollidedWithEnemy(IEnemy enemy, Direction direction)
        {
            EnemyWallCollision.UpateLocation(enemy, this, direction);
        }
        public void CollidedWithBlock(IBlock block, Direction direction)
        {
            BlockWallCollision.UpateLocation(block, this, direction);
        }
        
        public void Update()
        {

        }

        public void CollidedWithProjectile(IProjectile projectile, Direction direction)
        {
            ProjectileWallCollision.UpateLocation(projectile, this, direction);
        }
    }
}
