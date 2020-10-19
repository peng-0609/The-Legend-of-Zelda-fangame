using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public interface IRoom
    {
        int RoomNum { get; set; }
        void Update();
        void DrawCoordHUD(SpriteBatch spriteBatch);
        void DrawCoordMenu(SpriteBatch spriteBatch);
        void Draw(SpriteBatch spriteBatch);
        Rectangle GetRectangle();
    }
}
