
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MenuState : IGameState
    {
        public bool isPause { get; set; }

        GameStateManager gameStateManager;
        private enum Option { Play, Quit, OneHp, Unlimited };
        private int OptionIndex;
        private ISprite logo;
        private Option[] options;
        private Vector2[] optionsLocations;
        private ISprite selector;
        SpriteFont spriteFont;
        public MenuState(GameStateManager gameStateManager)
        {
            this.gameStateManager = gameStateManager;
            logo = MenuSpriteFactory.Instance.CreateLogoSprite();
            selector = MenuSpriteFactory.Instance.CreateSelector();
            spriteFont = MenuSpriteFactory.Instance.CreateSpriteFont();
            OptionIndex = Util.Instance.ZERO;
            gameStateManager.Unlimited = false;
            isPause = true;
            options = new Option[4];
            optionsLocations = new Vector2[] { new Vector2(130, 20), new Vector2(130, 60), new Vector2(130, 100), new Vector2(130, 140) };
            options[0] = Option.Play;
            options[1] = Option.Quit;
            options[2] = Option.OneHp;
            options[3] = Option.Unlimited;
            MusicFactory.Instance.PlayTitleTheme();
        }
        // TODO: Change the use of magic variables and number to refering constants in Util class
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            logo.Draw(spriteBatch, Vector2.Zero);
            spriteBatch.DrawString(spriteFont, "Start", new Vector2(200,20), Color.Black);
            spriteBatch.DrawString(spriteFont, "Quit", new Vector2(200,60), Color.Black);
            spriteBatch.DrawString(spriteFont, "One Hp Mode", new Vector2(200, 100), Color.Black);
            spriteBatch.DrawString(spriteFont, "Unlimited Mode", new Vector2(200, 140), Color.Black);
            selector.Draw(spriteBatch, optionsLocations[OptionIndex]);
            spriteBatch.End();
        }
        public void Up()
        {
            if (OptionIndex == 0)
            {
                OptionIndex = 3;
            }else if (OptionIndex == 3)
            {
                OptionIndex = 2;
            }
            else if (OptionIndex == 2)
            {
                OptionIndex = 1;
            }
            else 
            {
                OptionIndex = 0;
            }
        }
        public void Down()
        {     
            if (OptionIndex == 0)
            {
                OptionIndex = 1;
            }
            else if (OptionIndex == 1)
            {
                OptionIndex = 2;
            }
            else if (OptionIndex == 2)
            {
                OptionIndex = 3;
            }
            else
            {
                OptionIndex = 0;
            }
        }
        public void Left(){ }
        public void Right() { }
        public void Resume() { }
        public void Item() { }
        public void Action()
        {
            switch (options[OptionIndex])
            {
                case Option.Play:
                    gameStateManager.state = new WorldState(gameStateManager);
                    MusicFactory.Instance.PlayDungeonTheme();
                    break;
                case Option.Quit:
                    gameStateManager.Quit();
                    break;
                case Option.OneHp:
                    gameStateManager.state = new WorldState(gameStateManager);
                    gameStateManager.GameClass.Link.OneHpMode = true;
                    gameStateManager.GameClass.Link.Inventory.OneHpMode();
                    MusicFactory.Instance.PlayDungeonTheme();
                    break;
                case Option.Unlimited:
                    gameStateManager.state = new UnlimitedState(gameStateManager);
                    MusicFactory.Instance.PlayDungeonTheme();
                    break;
            }
        }
        public void Update(GameTime gameTime)
        {
            logo.Update();
        }
    }
}
