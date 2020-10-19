using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class BackgroundSprite : ISprite
    {
        private Texture2D sprite;
        private int rows;
        private int columns;
        private Dictionary<int, Rectangle> roomSource;
        private int room;
        private int originalWidth;
        private int originalHeight;
        public int Width { get; set; }
        public int Height { get; set; }

        public BackgroundSprite(Texture2D texture, int roomNum, int rs, int cs)
        {
            sprite = texture;
            rows = rs;
            columns = cs;
            originalWidth = texture.Width / columns;
            originalHeight = texture.Height / rows;
            Width = (int) (originalWidth * 2.5);
            Height = (int) (originalHeight * 2.5);
            room = roomNum;
            roomSource = new Dictionary<int, Rectangle>
            {
                { 1, new Rectangle(256, 880, originalWidth, originalHeight) },
                { 2, new Rectangle(512, 880, originalWidth, originalHeight) },
                { 3, new Rectangle(768, 880, originalWidth, originalHeight) },
                { 4, new Rectangle(512, 704, originalWidth, originalHeight) },
                { 5, new Rectangle(256, 528, originalWidth, originalHeight) },
                { 6, new Rectangle(512, 528, originalWidth, originalHeight) },
                { 7, new Rectangle(768, 528, originalWidth, originalHeight) },
                { 8, new Rectangle(0, 352, originalWidth, originalHeight) },
                { 9, new Rectangle(256, 352, originalWidth, originalHeight) },
                { 10, new Rectangle(512, 352, originalWidth, originalHeight) },
                { 11, new Rectangle(768, 352, originalWidth, originalHeight) },
                { 12, new Rectangle(1024, 352, originalWidth, originalHeight) },
                { 13, new Rectangle(256, 176, originalWidth, originalHeight) },
                { 14, new Rectangle(512, 176, originalWidth, originalHeight) },
                { 15, new Rectangle(1024, 176, originalWidth, originalHeight) },
                { 16, new Rectangle(1280, 176, originalWidth, originalHeight) },
                { 17, new Rectangle(256, 0, originalWidth, originalHeight) },
                { 18, new Rectangle(512, 0, originalWidth, originalHeight) },
                { 21, new Rectangle(0, 0, originalWidth, originalHeight) }
            };
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = roomSource[room];
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, Width, Height);

            //spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            //spriteBatch.End();
        }

    }
}
