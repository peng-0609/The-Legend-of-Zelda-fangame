using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IBlock
    {
        IBlockState State { get; set; }
        Vector2 Position { get; set; }
        bool IsMovable { get; set; }
        void Move();
        Rectangle GetRectangle();
        void CollidedWithLink(IPlayer link, Direction direction);
        void CollidedWithEnemy(IEnemy enemy, Direction direction);
        void CollidedWithProjectile(IProjectile projectile, Direction direction);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
