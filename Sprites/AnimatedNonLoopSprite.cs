using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class AnimatedNonLoopSprite : ISprite
    {
        private Texture2D sprite;
        private int rows;
        private int columns;
        private int currentFrame;
        private int totalFrames;
        private int timer;
        public int Width { get; set; }
        public int Height { get; set; }

        public AnimatedNonLoopSprite(Texture2D texture, int rs, int cs)
        {
            sprite = texture;
            rows = rs;
            columns = cs;
            currentFrame = 0;
            totalFrames = rows * columns;
            timer = 0;
            Width = texture.Width / columns * 2;
            Height = texture.Height / rows * 2;
        }

        public void Update()
        {
            timer++;
            if (timer == 15)
            {
                timer = 0;
                if (currentFrame != totalFrames - 1)
                {
                    currentFrame++;
                }

            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // int width = sprite.Width / columns;
            // int height = sprite.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(Width / 2 * column, Height / 2 * row, Width / 2, Height / 2);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            //spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            //spriteBatch.End();
        }
    }
}
