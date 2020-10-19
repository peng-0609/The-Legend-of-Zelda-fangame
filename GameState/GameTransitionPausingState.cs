using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    class GameTransitionPausingState : IGameState
    {
        public Boolean isPause { get; set; }
        private enum Option { Restart, Quit };
        private SpriteFont spriteFont;
        private int timer;


        GameStateManager gameStateManager;
        public GameTransitionPausingState(GameStateManager gameStateManager, Direction direction)
        {
            spriteFont = MenuSpriteFactory.Instance.CreateSpriteFont();
            isPause = true;
            this.gameStateManager = gameStateManager;
            switch (direction)
            {
                case Direction.UP:
                    timer = 45;
                    break;

                case Direction.LEFT:
                    timer = 65;
                    break;

                case Direction.RIGHT:
                    timer = 65;
                    break;

                case Direction.DOWN:
                    timer = 45;
                    break;
            }
        }

        public void Action() { }
       

        public void Item() { }
        public void Down() { }
       

        public void Draw(SpriteBatch spriteBatch)
        {

        }



        public void Left() { }
       

        public void Right() { }

        public void Resume() { }

        public void Up() { }


        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {
                gameStateManager.state = new WorldState(gameStateManager);
                MusicFactory.Instance.Resume();
            }
        }
    }
}
