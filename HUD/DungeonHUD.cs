using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class DungeonHUD : IHUD
    {
        private Game1 myGame;
        private ISprite HUDSprite;
        private SpriteFont font;
        private IPlayer link;
        private bool firstPicked;

        public DungeonHUD(Game1 game)
        {
            myGame = game;
            font = MenuSpriteFactory.Instance.CreateSpriteFont();
            HUDSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            link = game.Link;
            firstPicked = false;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            HUDSprite.Draw(spriteBatch, new Vector2(0, 0));

            /* Handling the map when picked */
            if (link.Inventory.MapPicked)
            {
                ItemSpriteFactory.Instance.CreateMapSprite().Draw(spriteBatch, new Vector2(140, 300));
                HUDSpriteFactory.Instance.CreateMapIconSprite().Draw(spriteBatch, new Vector2(90, 488));
                HUDSpriteFactory.Instance.CreateMapPropSprite().Draw(spriteBatch, new Vector2(246, 253));
                /* In the original game, the GreenPoint will show on the MapProp only when Link picks up the Map. */
                myGame.Level.Room.DrawCoordMenu(spriteBatch);
            }
            /* Handling the compass when picked */
            if (link.Inventory.CompassPicked)
            {
                ItemSpriteFactory.Instance.CreateCompassSprite().Draw(spriteBatch, new Vector2(140, 382));
                HUDSpriteFactory.Instance.CreateRedPointSprite().Draw(spriteBatch, new Vector2(191, 497));
            }
            /* Handling the GreenPoint */
            myGame.Level.Room.DrawCoordHUD(spriteBatch);
            /* Handling the sword when picked */
            if (link.Inventory.SwordPicked)
            {
                ItemSpriteFactory.Instance.CreateSwordSprite().Draw(spriteBatch, new Vector2(366, 493));
            }
            /* Handling the boomerang when picked */
            if (link.Inventory.BoomerangPicked)
            {
                ProjectileSpriteFactory.Instance.CreateBoomerangSprite().Draw(spriteBatch, new Vector2(332, 185));
                /* if it is the first one to be picked, it will be the default iventory in use. */
                if (!firstPicked)
                {
                    firstPicked = true;
                    myGame.gameStateManager.boomerangIsSelected = true;
                    ProjectileSpriteFactory.Instance.CreateBoomerangSprite().Draw(spriteBatch, new Vector2(318, 500));
                    ProjectileSpriteFactory.Instance.CreateBoomerangSprite().Draw(spriteBatch, new Vector2(188, 178));
                }
                /* Handling the boomerang when selected */
                if (myGame.gameStateManager.boomerangIsSelected)
                {
                    ProjectileSpriteFactory.Instance.CreateBoomerangSprite().Draw(spriteBatch, new Vector2(188, 178));
                    ProjectileSpriteFactory.Instance.CreateBoomerangSprite().Draw(spriteBatch, new Vector2(318, 500));
                }
            }
            /* Handling the bomb when picked */
            if (link.Inventory.BombCount > 0)
            {
                ProjectileSpriteFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Vector2(378, 178));
                /* if it is the first one to be picked, it will be the default iventory in use. */
                if (!firstPicked)
                {
                    firstPicked = true;
                    myGame.gameStateManager.bombIsSelected = true;
                    ProjectileSpriteFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Vector2(314, 493));
                    ProjectileSpriteFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Vector2(185, 172));
                }
                /* Handling the bomb when selected */
                if (myGame.gameStateManager.bombIsSelected)
                {
                    ProjectileSpriteFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Vector2(185, 172));
                    ProjectileSpriteFactory.Instance.CreateBombSprite().Draw(spriteBatch, new Vector2(314, 493));
                }
            }
            /* Handling the bow when picked */
            if (link.Inventory.BowPicked)
            {
                ItemSpriteFactory.Instance.CreateBowSprite().Draw(spriteBatch, new Vector2(428, 178));
                /* if it is the first one to be picked, it will be the default iventory in use. */
                if (!firstPicked)
                {
                    firstPicked = true;
                    myGame.gameStateManager.ArrowIsSelected = true;
                    ItemSpriteFactory.Instance.CreateBowSprite().Draw(spriteBatch, new Vector2(315, 495));
                    ItemSpriteFactory.Instance.CreateBowSprite().Draw(spriteBatch, new Vector2(186, 172));
                }
                /* Handling the bow when selected */
                if (myGame.gameStateManager.ArrowIsSelected)
                {
                    ItemSpriteFactory.Instance.CreateBowSprite().Draw(spriteBatch, new Vector2(186, 172));
                    ItemSpriteFactory.Instance.CreateBowSprite().Draw(spriteBatch, new Vector2(315, 495));
                }
            }
            /* Handling Link's health */
            /* Normal Mode */
            if (!link.OneHpMode)
            {
                switch (link.Inventory.MaxHealth - link.Inventory.Health)
                {
                    case 6:
                        HUDSpriteFactory.Instance.CreateZeroHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 5:
                        HUDSpriteFactory.Instance.CreateOneHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 4:
                        HUDSpriteFactory.Instance.CreateTwoHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 3:
                        HUDSpriteFactory.Instance.CreateThreeHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 2:
                        HUDSpriteFactory.Instance.CreateFourHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 1:
                        HUDSpriteFactory.Instance.CreateFiveHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    case 0:
                        HUDSpriteFactory.Instance.CreateSixHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                    default:
                        HUDSpriteFactory.Instance.CreateZeroHealthSprite().Draw(spriteBatch, new Vector2(431, 525));
                        break;
                }
                /* Handling the HeartContainer when picked */
                if (link.Inventory.HeartContainerPicked)
                {
                    if (link.Inventory.MaxHealth - link.Inventory.Health <= 6)
                        HUDSpriteFactory.Instance.CreateFullHeartSprite().Draw(spriteBatch, new Vector2(415, 525));
                    else if (link.Inventory.MaxHealth - link.Inventory.Health == 7)
                        HUDSpriteFactory.Instance.CreateHalfHeartSprite().Draw(spriteBatch, new Vector2(415, 525));
                    else if (link.Inventory.MaxHealth - link.Inventory.Health == 8)
                        HUDSpriteFactory.Instance.CreateEmptyHeartSprite().Draw(spriteBatch, new Vector2(415, 525));
                }
            }/* One Hp Mode*/
            else
            {
                if (link.Inventory.Health == 1)
                    HUDSpriteFactory.Instance.CreateHalfHeartSprite().Draw(spriteBatch, new Vector2(415, 525));
                else
                    HUDSpriteFactory.Instance.CreateEmptyHeartSprite().Draw(spriteBatch, new Vector2(415, 525));
            }

            /* Handling the changing count of items */
            spriteBatch.DrawString(font, link.Inventory.RupeeCount.ToString(), new Vector2(264, 478), Color.White);
            spriteBatch.DrawString(font, link.Inventory.KeyCount.ToString(), new Vector2(264, 512), Color.White);
            spriteBatch.DrawString(font, link.Inventory.BombCount.ToString(), new Vector2(264, 527), Color.White);

            if (myGame.gameStateManager.Unlimited)
            {
                spriteBatch.DrawString(font, "Score: " + myGame.Link.Inventory.Score.ToString(), new Vector2(520, 520), Color.White);
            }
        }
    }
}

