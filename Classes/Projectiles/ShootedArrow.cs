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
    public class ShootedArrow : IProjectile
    {
        public Vector2 Position { get; set; }
        public IProjectileState State { get; set; }
        public ProjectilePhysicalProperty ArrowPhysics { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisappeared { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        private Rectangle InitialR { get; set; }
        private Direction InitialD { get; set; }
        public String Name { get; set; }
        public ShootedArrow(int x, int y, Direction direction)
        {
            Position = new Vector2(x, y);
            State = InitializeArrowState(direction);
            ArrowPhysics = new ProjectilePhysicalProperty(this);
            this.IsUsed = true;
            this.IsDisappeared = false;
            ArrowPhysics.direction = direction;
            this.InitialR = GetRectangle();
            InitialD = direction;
            this.Name = "Arrow";
        }

        public void Update(GameTime gameTime)
        {
            State.Update();
            ArrowPhysics.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void UseProjectile()
        {
            State.UseProjectile();
        }

        public Rectangle GetRectangle()
        {
            return Rectangle;
        }
        public Rectangle InitialRec()
        {
            return InitialR;
        }
        public Direction InitialDir()
        {
            return InitialD;
        }
        public void CollidedWithWall() { this.IsDisappeared = true; }
        public void CollidedWithBlock() { this.IsDisappeared = true; }
        public void CollidedWithDoor() { this.IsDisappeared = true; }
        public void CollidedWithStair() { this.IsDisappeared = true; }
        public void CollidedWithLink(IPlayer link) { }
        private IProjectileState InitializeArrowState(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return new ShootedArrowUpState(this);
                case Direction.DOWN:
                    return new ShootedArrowDownState(this);
                case Direction.LEFT:
                    return new ShootedArrowLeftState(this);
                case Direction.RIGHT:
                    return new ShootedArrowRightState(this);
                default:
                    return null;
            }
        }
        public Direction getDirection()
        {
            return ArrowPhysics.direction;
        }
    }
}
