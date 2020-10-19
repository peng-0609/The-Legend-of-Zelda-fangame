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
    public class FireBall : IProjectile
    {
        public Vector2 Position { get; set; }
        
        public ProjectilePhysicalProperty FireBallPhysics { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDisappeared { get; set; }
        private ISprite fireBallSprite;
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, fireBallSprite.Width, fireBallSprite.Height);
        private Rectangle InitialR { get; set; }
        private Direction InitialD { get; set; }
        public String Name { get; set; }
        public FireBall(int x, int y, Direction direction)
        {
            Position = new Vector2(x, y);
            fireBallSprite = ProjectileSpriteFactory.Instance.CreateFireBallSprite();
            FireBallPhysics = new ProjectilePhysicalProperty(this);
            this.IsUsed = true;
            this.IsDisappeared = false;
            FireBallPhysics.direction = direction;
            this.InitialR = GetRectangle();
            InitialD = direction;
            this.Name = "FireBall";
        }

        public void Update(GameTime gameTime)
        {
            fireBallSprite.Update();
            FireBallPhysics.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fireBallSprite.Draw(spriteBatch,Position);
        }

        public void UseProjectile()
        {
            IsUsed = true;
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
        public void CollidedWithLink(IPlayer link)
        {
            link.TakeDamage();
            this.IsDisappeared = true;
        }
        public Direction getDirection()
        {
            return FireBallPhysics.direction;
        }
    }
}
