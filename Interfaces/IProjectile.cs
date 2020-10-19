using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IProjectile
    {
        
        bool IsUsed { get; set; }
        bool IsDisappeared { get; set; }
        Rectangle GetRectangle();
        void CollidedWithLink(IPlayer link);
        void CollidedWithBlock();
        void CollidedWithStair();
        void CollidedWithDoor();
        void CollidedWithWall();
        Vector2 Position { get; set; }
        void UseProjectile();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        Rectangle InitialRec();
        Direction InitialDir();
        Direction getDirection();
        String Name { get; set; }
    }
}
