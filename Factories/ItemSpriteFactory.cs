using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class ItemSpriteFactory
    {
        private Texture2D arrowSpritesheet;
        private Texture2D bowSpritesheet;
        private Texture2D clockSpritesheet;
        private Texture2D fairySpritesheet;
        private Texture2D heartSpritesheet;
        private Texture2D heartcontainerSpritesheet;
        private Texture2D keySpritesheet;
        private Texture2D compassSpritesheet;
        private Texture2D swordSpritesheet;
        private Texture2D triforceSpritesheet;
        private Texture2D yellowrupySpritesheet;
        private Texture2D bluerupySpritesheet;
        private Texture2D mapSpritesheet;
        private Texture2D detailedMapSpritesheet;


        private static ItemSpriteFactory instance;

        public static ItemSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemSpriteFactory();
                }
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            arrowSpritesheet = content.Load<Texture2D>("ItemSprites/Arrow");
            bowSpritesheet = content.Load<Texture2D>("ItemSprites/Bow");
            clockSpritesheet = content.Load<Texture2D>("ItemSprites/Clock");
            fairySpritesheet = content.Load<Texture2D>("ItemSprites/Fairy");
            heartSpritesheet = content.Load<Texture2D>("ItemSprites/Heart");
            heartcontainerSpritesheet = content.Load<Texture2D>("ItemSprites/HeartContainer");
            keySpritesheet = content.Load<Texture2D>("ItemSprites/Key");
            compassSpritesheet = content.Load<Texture2D>("ItemSprites/Compass");
            swordSpritesheet = content.Load<Texture2D>("ItemSprites/Sword");
            triforceSpritesheet = content.Load<Texture2D>("ItemSprites/Triforce");
            yellowrupySpritesheet = content.Load<Texture2D>("ItemSprites/YellowRupy");
            bluerupySpritesheet = content.Load<Texture2D>("ItemSprites/BlueRupy");
            mapSpritesheet = content.Load<Texture2D>("ItemSprites/Map");
            detailedMapSpritesheet = content.Load<Texture2D>("RoomSprites/DetailedMap");
        }

        public ISprite CreateArrowSprite()
        {
            return new NonAnimatedSprite(arrowSpritesheet);
        }

        public ISprite CreateBowSprite()
        {
            return new NonAnimatedSprite(bowSpritesheet);
        }

        public ISprite CreateClockSprite()
        {
            return new NonAnimatedSprite(clockSpritesheet);
        }
        public ISprite CreateFairySprite()
        {
            return new AnimatedSprite(fairySpritesheet, 1, 2);
        }

        public ISprite CreateHeartSprite()
        {
            return new AnimatedSprite(heartSpritesheet, 1, 2);
        }
        public ISprite CreateHeartContainerSprite()
        {
            return new NonAnimatedSprite(heartcontainerSpritesheet);
        }

        public ISprite CreateKeySprite()
        {
            return new NonAnimatedSprite(keySpritesheet);
        }

        public ISprite CreateCompassSprite()
        {
            return new NonAnimatedSprite(compassSpritesheet);
        }

        public ISprite CreateSwordSprite()
        {
            return new NonAnimatedSprite(swordSpritesheet);
        }

        public ISprite CreateTriforceSprite()
        {
            return new AnimatedSprite(triforceSpritesheet, 2, 1);
        }
        public ISprite CreateYellowRupySprite()
        {
            return new NonAnimatedSprite(yellowrupySpritesheet);
        }

        public ISprite CreateBlueRupySprite()
        {
            return new NonAnimatedSprite(bluerupySpritesheet);
        }

        public ISprite CreateMapSprite()
        {
            return new NonAnimatedSprite(mapSpritesheet);
        }

        public ISprite CreateDetailedMapSprite()
        {
            return new NonAnimatedSprite(detailedMapSpritesheet);
        }
    }
}
