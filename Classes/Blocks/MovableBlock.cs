using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class MovableBlock : IBlock
    {
        public IBlockState State { get; set; }
        public Vector2 Position { get; set; }
        public bool IsMovable { get; set; }

        public MovableBlock(int x, int y)
        {
            State = new BlockIdleState(this);
            Position = new Vector2(x, y);
            this.IsMovable = true;
        }

        public void Move()
        {
            State.Move();
        }

        public void CollidedWithLink(IPlayer Link)
        {
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        }

        public void CollidedWithLink(IPlayer link, Direction direction)
        {
            LinkBlockCollision.UpateLocation(link, this, direction);
        }

        public void CollidedWithEnemy(IEnemy enemy, Direction direction)
        {
            EnemyBlockCollision.UpateLocation(enemy, this, direction);
        }

        public void Update()
        {
            State.Update();
        }

        public void CollidedWithProjectile(IProjectile projectile, Direction direction)
        {
            ProjectileBlockCollision.UpateLocation(projectile, this, direction);
        }
    }
}
