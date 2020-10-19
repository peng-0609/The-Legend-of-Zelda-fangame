using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IWall
    {
        Vector2 Position { get; set; }
        Rectangle GetRectangle();
        void CollidedWithEnemy(IEnemy enemy, Direction direction);
        void CollidedWithBlock(IBlock block, Direction direction);
        void CollidedWithLink(IPlayer link, Direction direction);
        void CollidedWithProjectile(IProjectile projectile, Direction direction);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}