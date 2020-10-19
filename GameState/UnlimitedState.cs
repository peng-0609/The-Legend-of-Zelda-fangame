using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint2;

namespace Sprint2
{
    public class UnlimitedState : IGameState
    {
        public bool isPause { get; set; }


        GameStateManager gameStateManager;
        public UnlimitedState(GameStateManager gameStateManagerClass)
        {
            isPause = false;
            this.gameStateManager = gameStateManagerClass;
            gameStateManager.Unlimited = true;
            gameStateManager.GameClass.Level = LevelLoaderFactory.Instance.LoadContents(gameStateManager.GameClass, gameStateManager.GameClass.XmlString2, 21);
            gameStateManager.GameClass.Link.Inventory.BombCount = 10;
            gameStateManager.GameClass.Link.Inventory.BoomerangPicked = true;
            gameStateManager.GameClass.Link.Inventory.BowPicked = true;
            gameStateManager.GameClass.collisionDetection = new AllCollisionHandler(gameStateManager);
        }


        public void Action()
        {
            isPause = true;
            gameStateManager.state = new GamePausingState(gameStateManager);
        }

        public void Down()
        {
            gameStateManager.GameClass.Link.FaceDown();

            gameStateManager.GameClass.Link.Run();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            gameStateManager.GameClass.Level.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, null, null, null, null, gameStateManager.GameClass.MenuCamera.ViewMatrix);
            gameStateManager.GameClass.DungeonHUD.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            gameStateManager.GameClass.Link.Draw(spriteBatch);
            spriteBatch.End();
        }


        public void Item()
        {
            gameStateManager.state = new ItemSelectionState(gameStateManager);
        }
        public void Left()
        {
            gameStateManager.GameClass.Link.FaceLeft();

            gameStateManager.GameClass.Link.Run();

        }

        public void Right()
        {
            gameStateManager.GameClass.Link.FaceRight();

            gameStateManager.GameClass.Link.Run();
        }

        public void Up()
        {
            gameStateManager.GameClass.Link.FaceUp();

            gameStateManager.GameClass.Link.Run();

        }

        public void Resume()
        {
            gameStateManager.Reset();
            gameStateManager.state = new MenuState(gameStateManager);

        }
        public void Update(GameTime gameTime)
        {

        }
    }
}
