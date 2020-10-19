using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class HUDSprite : ISprite
    {
        private Texture2D sprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public HUDSprite(Texture2D texture)
        {
            sprite = texture;
            Width = texture.Width * 2;
            Height = texture.Height * 2;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Width / 2, Height / 2);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
