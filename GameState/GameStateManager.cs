using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class GameStateManager
    {
     
        public IGameState state { get; set; }
        public TextSprite textSprite { get; set; }
        public  Game1 GameClass { get; set; }
        public bool Unlimited { get; set; }
        public bool bombIsSelected{get;set;}
        public bool boomerangIsSelected { get; set; }
        public bool ArrowIsSelected { get; set; }

        public GameStateManager(Game1 game)
        {
            state = new MenuState(this);
            Unlimited = false;
            GameClass = game;
            ArrowIsSelected = false;
            bombIsSelected = false;
            boomerangIsSelected = false;
        }
        public void Action()
        {
            state.Action();
        }

        public void Item()
        {
            state.Item();
        }
        public void Up()
        {
            state.Up();

        }
        public void Down()
        {
            state.Down();
        }
        public void Left()
        {
            state.Left();
        }
        public void Right()
        {
            state.Right();
        }
        public void Attack()
        {
            if (state.isPause) return;
            GameClass.Link.Attack();
        }
        public void UseItem()
        {
            if (state.isPause) return;
            if (ArrowIsSelected)
            {
                GameClass.Link.Shoot();
            }
            else if (bombIsSelected)
            {
                GameClass.Link.UseBomb();
            }
            else if(boomerangIsSelected)
            {
                GameClass.Link.UseBoomerang();
            }
        }
        public void UseMap()
        {
            if (state.isPause) return;            
        }
        public void Pause()
        {
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }
        public void Resume()
        {
            state.Resume();
            MusicFactory.Instance.Resume();
        }
        public void Update(GameTime gameTime)
        {

            if (this.GameClass.Link.Inventory.Health <= 0 && !state.isPause) {
                state = new GameOverState(this);
            } else if (this.GameClass.Link.Inventory.TriforcePicked && !state.isPause)
            {
                state = new GameWinState(this);
            }
            state.Update(gameTime);
        }
        public void ChangeRoom(Direction direction, int doorNum)
        {
            //create new level
            GameClass.Level = LevelLoaderFactory.Instance.LoadContents(GameClass, GameClass.XmlString1, doorNum);
            switch (direction)
            {
                case Direction.UP:
                    GameClass.MapCamera.MoveUp();
                    break;

                case Direction.LEFT:
                    GameClass.MapCamera.MoveLeft();
                    break;

                case Direction.RIGHT:
                    GameClass.MapCamera.MoveRight();
                    break;

                case Direction.DOWN:
                    GameClass.MapCamera.MoveDown();
                    break;
            }
            state = new GameTransitionPausingState(this, direction);
            GameClass.collisionDetection = new AllCollisionHandler(GameClass.gameStateManager);
            GameClass.ControllerList = new List<IController>();
            GameClass.ControllerList.Add(new KeyboardController(GameClass));
            foreach (IController controller in GameClass.ControllerList)
            {
                controller.RegisterCommand();
            }

        }
        public void Reset()
        {
            this.GameClass.Reset();
        }

        public void Quit()
        {
            this.GameClass.Exit();
        }
    }
}

