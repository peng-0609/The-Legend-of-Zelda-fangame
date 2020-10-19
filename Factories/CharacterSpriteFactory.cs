using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class CharacterSpriteFactory
    {
        private Texture2D oldmanSpritesheet;

        private static CharacterSpriteFactory instance;

        public static CharacterSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacterSpriteFactory();
                }
                return instance;
            }
        }

        private CharacterSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            oldmanSpritesheet = content.Load<Texture2D>("CharacterSprites/Oldman");
        }

        public ISprite CreateOldmanSprite()
        {
            return new AnimatedSprite(oldmanSpritesheet, 1, 2);
        }
    }
}
