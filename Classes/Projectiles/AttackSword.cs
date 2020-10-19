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
    public class AttackSword : IProjectile
    {
        public Vector2 Position { get; set; }
        public IProjectileState State { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisappeared { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        private Rectangle InitialR { get; set; }
        private Direction InitialD { get; set; }
        public String Name { get; set; }
        public AttackSword(int x, int y, Direction direction)
        {
            Position = new Vector2(x, y);
            State = new SwordAttackState(this, direction);
            this.IsDisappeared = false;
            this.InitialR = GetRectangle();
            InitialD = direction;
            this.Name = "Sword";
        }

        public void Update(GameTime gameTime)
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void UseProjectile()
        {
            State.UseProjectile();
        }
        public void CollidedWithWall() { }
        public void CollidedWithBlock() { }
        public void CollidedWithDoor() { }
        public void CollidedWithStair() { }
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
        public Direction getDirection()
        {
            return InitialD;
        }
        public void CollidedWithLink(IPlayer link) { }
    }
}
