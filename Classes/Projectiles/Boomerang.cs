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
    public class Boomerang : IProjectile
    {
        public Vector2 Position { get; set; }
        public IProjectileState State { get; set; }
        public ProjectilePhysicalProperty BoomerangPhysics { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisappeared { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        private Rectangle InitialR { get; set; }
        private Direction InitialD { get; set; }
        public String Name { get; set; }

        public Boomerang(int x, int y, Direction direction)
        {
            Position = new Vector2(x, y);
            State = new BoomerangIdleState(this);
            BoomerangPhysics = new ProjectilePhysicalProperty(this);
            this.IsUsed = false;
            this.IsDisappeared = false;
            BoomerangPhysics.direction = direction;
            this.InitialR = GetRectangle();
            InitialD = direction;
            this.Name = "Boomerang";
        }

        public void Update(GameTime gameTime)
        {
            State.Update();
            BoomerangPhysics.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void SwitchDirection()
        {
            if (this.BoomerangPhysics.direction == Direction.LEFT)
            {
                this.BoomerangPhysics.direction = Direction.RIGHT;
            }
            else if (this.BoomerangPhysics.direction == Direction.RIGHT)
            {
                this.BoomerangPhysics.direction = Direction.LEFT;
            }
            else if (this.BoomerangPhysics.direction == Direction.UP)
            {
                this.BoomerangPhysics.direction = Direction.DOWN;
            }
            else if (this.BoomerangPhysics.direction == Direction.DOWN)
            {
                this.BoomerangPhysics.direction = Direction.UP;
            }
        }

        public void CollidedWithWall()
        {
            SwitchDirection();
        }
        public void CollidedWithBlock()
        {
            SwitchDirection();
        }
        public void CollidedWithDoor()
        {
            SwitchDirection();
        }
        public void CollidedWithStair()
        {
            SwitchDirection();
        }
        public void UseProjectile()
        {
            State.UseProjectile();
        }

        public Rectangle GetRectangle()
        {
            return Rectangle;
        }
        public void CollidedWithLink(IPlayer link)
        {
            this.IsDisappeared = true;
        }
        public Rectangle InitialRec()
        {
            return InitialR;
        }
        public Direction InitialDir()
        {
            return InitialD;
        }
        public Direction getDirection()
        {
            return BoomerangPhysics.direction;
        }
    }
}
