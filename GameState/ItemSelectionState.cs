using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class ItemSelectionState : IGameState
    {
        public bool isPause { get; set; }
        private enum Option { Bomb,Boomerang,Arrow };
        private Vector2[] optionsLocations;
        private int OptionIndex;
        private ISprite selector;
        private Option[] options;

        GameStateManager gameStateManager;
        public ItemSelectionState(GameStateManager gameStateManagerClass)
        {
            this.gameStateManager = gameStateManagerClass;
            gameStateManager.GameClass.MenuCamera.MoveUp();
            isPause = true;
            selector = MenuSpriteFactory.Instance.CreateItemSelector();
            OptionIndex = Util.Instance.ZERO;
            options = new Option[3];
            optionsLocations = new Vector2[] { new Vector2(318,174), new Vector2(367,174), new Vector2(416,174) };
            options[0] = Option.Boomerang;
            options[1] = Option.Bomb;
            options[2] = Option.Arrow;  
        }
        public void Action()
        {
            switch (options[OptionIndex])
            {
                case Option.Arrow:
                    if (!gameStateManager.GameClass.Link.Inventory.BowPicked) return;
                    gameStateManager.ArrowIsSelected = true;
                    gameStateManager.bombIsSelected = false;
                    gameStateManager.boomerangIsSelected = false;
                    break;
                case Option.Bomb:
                    if (gameStateManager.GameClass.Link.Inventory.BombCount <= 0) return;
                    gameStateManager.ArrowIsSelected = false;
                    gameStateManager.bombIsSelected = true;
                    gameStateManager.boomerangIsSelected = false;
                    break;
                case Option.Boomerang:
                    if (!gameStateManager.GameClass.Link.Inventory.BoomerangPicked) return;
                    gameStateManager.ArrowIsSelected = false;
                    gameStateManager.bombIsSelected = false;
                    gameStateManager.boomerangIsSelected = true;
                    break;
            }
            

        }

        public void Down()
        {
           
        }
       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, gameStateManager.GameClass.MenuCamera.ViewMatrix);
            gameStateManager.GameClass.DungeonHUD.Draw(spriteBatch);
            selector.Draw(spriteBatch, optionsLocations[OptionIndex]);
            spriteBatch.End();


        }

        public void Left()
        {
            if (OptionIndex == 0)
            {
                OptionIndex = 2;
            }
            else if(OptionIndex == 2)
            {
                OptionIndex = 1;
            }
            else
            {
                OptionIndex = 0;
            }
        }

        public void Right()
        {
            if (OptionIndex == 0)
            {
                OptionIndex = 1;
            }
            else if (OptionIndex == 2)
            {
                OptionIndex = 0;
            }
            else
            {
                OptionIndex = 2;
            }
        }

        public void Up()
        {
            
        }
        public void Item() { }
        public void Resume()
        {
            gameStateManager.GameClass.MenuCamera.MoveDown();
            if (this.gameStateManager.GameClass.Link.OneHpMode)
            {
                this.gameStateManager.state = new WorldState(this.gameStateManager);
                this.gameStateManager.GameClass.Link.OneHpMode = true;
                gameStateManager.GameClass.Link.Inventory.OneHpMode();
            }
            else if (this.gameStateManager.Unlimited)
            {
                this.gameStateManager.state = new UnlimitedState(this.gameStateManager);
                this.gameStateManager.Unlimited = true;
            }
            else
            {
                this.gameStateManager.state = new WorldState(this.gameStateManager);
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
