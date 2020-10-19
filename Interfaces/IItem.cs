using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IItem
    {
        bool Picked { get; set; }
        String Name { get; set; }
        void IsPicked();
        Rectangle GetRectangle();
        void CollidedWithLink(IPlayer link);
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
