using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class GamePausingState : IGameState
    {
        public Boolean isPause { get; set; }
        private enum Option { Restart, Quit };
        private SpriteFont spriteFont;


        GameStateManager gameStateManager;
        public GamePausingState(GameStateManager gameStateManager)
        {
            spriteFont = MenuSpriteFactory.Instance.CreateSpriteFont();
            isPause = true;
            MusicFactory.Instance.Pause();
            this.gameStateManager = gameStateManager;
        }

        public void Action()
        {
            isPause = !isPause;
            if (this.gameStateManager.GameClass.Link.OneHpMode)
            {
                this.gameStateManager.state = new WorldState(this.gameStateManager);
                this.gameStateManager.GameClass.Link.OneHpMode = true;
                gameStateManager.GameClass.Link.Inventory.OneHpMode();
            }
            else if (this.gameStateManager.Unlimited)
            {
                gameStateManager.Reset();
                this.gameStateManager.state = new UnlimitedState(this.gameStateManager);
                this.gameStateManager.Unlimited = true;
            }
            else
            {
                this.gameStateManager.state = new WorldState(this.gameStateManager);
            }
            MusicFactory.Instance.Resume();
        }

        public void Item() { }
        public void Down()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, "Pause", new Vector2(300, 250), Color.White);
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
            

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
