using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface ISprite
    {
        int Width { get; set; }
        int Height { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
