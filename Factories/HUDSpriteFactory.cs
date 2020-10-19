using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class HUDSpriteFactory
    {
        private Texture2D HUDSpritesheet;
        private Texture2D mapIconSpritesheet;
        private Texture2D mapPropSpritesheet;
        private Texture2D greenPointSpritesheet;
        private Texture2D redPointSpritesheet;
        private Texture2D selectBoxSpritesheet;
        private Texture2D zeroHealthSpritesheet;
        private Texture2D oneHealthSpritesheet;
        private Texture2D twoHealthSpritesheet;
        private Texture2D threeHealthSpritesheet;
        private Texture2D fourHealthSpritesheet;
        private Texture2D fiveHealthSpritesheet;
        private Texture2D sixHealthSpritesheet;
        private Texture2D fullHeartSpritesheet;
        private Texture2D halfHeartSpritesheet;
        private Texture2D emptyHeartSpritesheet;

        private static HUDSpriteFactory instance;

        public static HUDSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HUDSpriteFactory();
                }
                return instance;
            }
        }

        private HUDSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            HUDSpritesheet = content.Load<Texture2D>("HUDSprites/HUD");
            mapIconSpritesheet = content.Load<Texture2D>("HUDSprites/MapIcon");
            mapPropSpritesheet = content.Load<Texture2D>("HUDSprites/MapProp");
            greenPointSpritesheet = content.Load<Texture2D>("HUDSprites/GreenPoint");
            redPointSpritesheet = content.Load<Texture2D>("HUDSprites/RedPoint");
            selectBoxSpritesheet = content.Load<Texture2D>("HUDSprites/SelectBox");
            zeroHealthSpritesheet = content.Load<Texture2D>("HUDSprites/0HP");
            oneHealthSpritesheet = content.Load<Texture2D>("HUDSprites/1HP");
            twoHealthSpritesheet = content.Load<Texture2D>("HUDSprites/2HP");
            threeHealthSpritesheet = content.Load<Texture2D>("HUDSprites/3HP");
            fourHealthSpritesheet = content.Load<Texture2D>("HUDSprites/4HP");
            fiveHealthSpritesheet = content.Load<Texture2D>("HUDSprites/5HP");
            sixHealthSpritesheet = content.Load<Texture2D>("HUDSprites/6HP");
            fullHeartSpritesheet = content.Load<Texture2D>("HUDSprites/FullHeart");
            halfHeartSpritesheet = content.Load<Texture2D>("HUDSprites/HalfHeart");
            emptyHeartSpritesheet = content.Load<Texture2D>("HUDSprites/EmptyHeart");
        }


        public ISprite CreateHUDSprite()
        {
            return new HUDSprite(HUDSpritesheet);
        }

        public ISprite CreateMapIconSprite()
        {
            return new HUDSprite(mapIconSpritesheet);
        }

        public ISprite CreateMapPropSprite()
        {
            return new HUDSprite(mapPropSpritesheet);
        }

        public ISprite CreateGreenPointSprite()
        {
            return new HUDSprite(greenPointSpritesheet);
        }

        public ISprite CreateRedPointSprite()
        {
            return new HUDSprite(redPointSpritesheet);
        }

        public ISprite CreateSelectBoxSprite()
        {
            return new HUDSprite(selectBoxSpritesheet);
        }

        public ISprite CreateZeroHealthSprite()
        {
            return new HUDSprite(zeroHealthSpritesheet);
        }

        public ISprite CreateOneHealthSprite()
        {
            return new HUDSprite(oneHealthSpritesheet);
        }

        public ISprite CreateTwoHealthSprite()
        {
            return new HUDSprite(twoHealthSpritesheet);
        }

        public ISprite CreateThreeHealthSprite()
        {
            return new HUDSprite(threeHealthSpritesheet);
        }

        public ISprite CreateFourHealthSprite()
        {
            return new HUDSprite(fourHealthSpritesheet);
        }

        public ISprite CreateFiveHealthSprite()
        {
            return new HUDSprite(fiveHealthSpritesheet);
        }

        public ISprite CreateSixHealthSprite()
        {
            return new HUDSprite(sixHealthSpritesheet);
        }

        public ISprite CreateFullHeartSprite()
        {
            return new HUDSprite(fullHeartSpritesheet);
        }

        public ISprite CreateHalfHeartSprite()
        {
            return new HUDSprite(halfHeartSpritesheet);
        }

        public ISprite CreateEmptyHeartSprite()
        {
            return new HUDSprite(emptyHeartSpritesheet);
        }
    }
}
