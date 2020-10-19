using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IStair
    {
        Vector2 Position { get; set; }
        Rectangle GetRectangle();
        Direction Destination { get; set; }
        void CollidedWithProjectile(IProjectile projectile, Direction direction);
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void CollidedWithLink(IPlayer link, Direction direction);
    }
}
