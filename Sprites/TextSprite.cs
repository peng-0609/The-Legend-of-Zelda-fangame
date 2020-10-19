using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class TextSprite
    {
        private SpriteFont text;

        public TextSprite(SpriteFont font)
        {
            text = font;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(text, "Press Arrow Keys or WASD to move Link\nPress Number Key 1 to use selected projectile\nPress Number Key 2 to attack using Sword\nPress Enter to Pause/Restart the game\nPress I to enter Menu In Menu: Press Left / Right Keys to select projectile for attacking Press Enter to determine\nPress Q to return from HUD to game and to return from game to Menu\nCheat codes: MR/MB/MK/MH to maximize Rupee/Bomb/Key/Health", location, Color.White);
        }
    }
}
