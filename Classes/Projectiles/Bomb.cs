using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class Bomb: IProjectile
    {
        public Vector2 Position { get; set; }
        public IProjectileState State { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisappeared { get; set; }
        private Rectangle InitialR { get; set; }
        public String Name { get; set; }
        public Bomb(int x, int y)
        {
            Position = new Vector2(x, y);
            State = new BombIdleState(this);
            this.IsUsed = false;
            this.IsDisappeared = false;
            this.InitialR = GetRectangle();
            this.Name = "Bomb";
        }     

        public void UseProjectile()
        {
            State.UseProjectile();
        }
        public Rectangle GetRectangle()
        {
            if (!this.IsUsed)
            {
                return new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
            }
            else
            {
                return new Rectangle((int)Position.X - 40, (int)Position.Y - 40, State.Width + 80, State.Height + 80);
            }
        }
        public void CollidedWithWall() { }
        public void CollidedWithBlock() { }
        public void CollidedWithDoor() { }
        public void CollidedWithStair() { }

        public void Update(GameTime gameTime)
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }
        public Rectangle InitialRec()
        {
            return InitialR;
        }
        public Direction InitialDir()
        {
            return Direction.UP;
        }
        public void CollidedWithLink(IPlayer link) { }
        public Direction getDirection()
        {
            return Direction.UP;
        }
    }
}
