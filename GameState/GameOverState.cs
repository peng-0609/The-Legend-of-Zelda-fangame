using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{ 
    class GameOverState : IGameState
    {
        public Boolean isPause { get; set; }
        private enum Option { Restart, Quit };
        private SpriteFont spriteFont;
        private Vector2[] optionsLocations;
        private int OptionIndex;
        private ISprite selector;
        private Option[] options;


        GameStateManager gameStateManager;
        public GameOverState(GameStateManager gameStateManager)
        {
            spriteFont = MenuSpriteFactory.Instance.CreateSpriteFont();
            selector = MenuSpriteFactory.Instance.CreateSelector();
            OptionIndex = Util.Instance.ZERO;
            options = new Option[2];
            optionsLocations = new Vector2[] { new Vector2(150,290), new Vector2(150,370) };
            options[0] = Option.Restart;
            options[1] = Option.Quit;
            isPause = true;
            this.gameStateManager = gameStateManager;
        }

        public void Action()
        {
            switch (options[OptionIndex])
            {
                case Option.Restart:
                    gameStateManager.Reset();
                    gameStateManager.state = new MenuState(gameStateManager);                
                    break;
                case Option.Quit:
                    gameStateManager.Quit();
                    break;
            }

        }

        public void Item() { }
        public void Down()
        {
            if (OptionIndex == 0)
            {
                OptionIndex = 1;
            }
            else
            {
                OptionIndex = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, "Game Over!", new Vector2(200, 170), Color.Red);
            if (gameStateManager.Unlimited)
            {
                spriteBatch.DrawString(spriteFont, "You Scored " + gameStateManager.GameClass.Link.Inventory.Score.ToString() + " points in Unlimited Mode!", new Vector2(130, 220), Color.DarkCyan);
            }
            spriteBatch.DrawString(spriteFont, "Restart", new Vector2(200, 290), Color.Blue);
            spriteBatch.DrawString(spriteFont, "Quit", new Vector2(200, 370), Color.Blue);
            selector.Draw(spriteBatch, optionsLocations[OptionIndex]);
            spriteBatch.End();
        }

       

        public void Left()
        {
        
        }

        public void Right()
        { 
        
        }
        public void Resume()
        {

        }
        public void Up()
        {
            if (OptionIndex == 0)
            {
                OptionIndex = 1;
            }
            else
            {
                OptionIndex = 0;
            }

        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}
