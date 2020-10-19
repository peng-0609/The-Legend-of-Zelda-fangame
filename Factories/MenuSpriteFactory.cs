using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class MenuSpriteFactory
    {
        private Texture2D SelectorSpritesheet;
        private Texture2D ItemSelectorSpritesheet;
        private Texture2D LogoSpritesheet;
        private SpriteFont spriteFont;

        private static MenuSpriteFactory instance;

        public static MenuSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuSpriteFactory();
                }
                return instance;
            }
        }

        private MenuSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            ItemSelectorSpritesheet = content.Load<Texture2D>("HUDSprites/SelectBox");
            SelectorSpritesheet = content.Load<Texture2D>("ProjectileSprites/Bomb");
            LogoSpritesheet = content.Load<Texture2D>("HUDSprites/logo");
            spriteFont = content.Load<SpriteFont>("HUDSprites/Font");
        }

        public ISprite CreateLogoSprite()
        {
            return new AnimatedSprite(LogoSpritesheet,2,2);
        }

        public ISprite CreateItemSelector()
        {
            return new HUDSprite(ItemSelectorSpritesheet);
        }

        public ISprite CreateSelector()
        {
            return new HUDSprite(SelectorSpritesheet);
        }

        public SpriteFont CreateSpriteFont()
        {
            return spriteFont;
        }
    }
}
