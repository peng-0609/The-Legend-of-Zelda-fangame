using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Wallmaster : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public String Name { get; set; }
        public Direction initialDir { get; set; }
        public EnemyPhysicalProperty Enemyphysics { get; set; }
        public bool IsDead { get; set; }
        public bool IsDisappeared { get; set; }
        public bool IsAccelerating { get; set; }
        public bool IsIdle { get; set; }
        private Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        public Wallmaster(int x, int y)
        {
            Position = new Vector2(x, y);
            State = new LeftMovingWallmasterState(this);
            Enemyphysics = new EnemyPhysicalProperty(this);
            this.Name = "Wallmaster";
            this.IsIdle = false;
            this.IsDead = false;
            this.IsDisappeared = false;
            this.IsAccelerating = false;
        }
        public void Attack() { }
        public void Bekilled()
        {
            State.Bekilled();
        }

        public void MoveUp()
        {
            State.MoveUp();
        }

        public void MoveDown()
        {
            State.MoveDown();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }
        public void CollidedWithDoor()
        {
            SwitchDirection();
        }
        public void SwitchDirection()
        {
            List<Direction> otherDirections = new List<Direction>
            {
                Direction.LEFT,
                Direction.DOWN,
                Direction.RIGHT,
                Direction.UP
            };
            // remove the current direction
            otherDirections.Remove(this.Enemyphysics.Direction);
            // pick a random direction
            Random rng = new Random();
            int randomNum = rng.Next(otherDirections.Count);
            Enemyphysics.Direction = otherDirections[randomNum];
        }
        public void CollidedWithProjectile()
        {
            Bekilled();
        }
        public void CollidedWithLink(IPlayer link, Direction direction, bool isRec, bool xSame, bool ySame)
        {

            if (link.IsAttacking && direction.Equals(link.linkphysicalProperty.direction))
            {
                Bekilled();
            }
            else
            {
                // or change state?
                link.TakeDamage();
            }
        }
        public void Update(GameTime gameTime)
        {
            State.Update();
            Enemyphysics.Update(gameTime);

        }
        public void CollidedWithBlock()
        {
            SwitchDirection();
        }
        public void CollidedWithWall()
        {
            SwitchDirection();
        }
        public void CollidedWithWater()
        {
            SwitchDirection();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public Rectangle GetRectangle()
        {
            return Rectangle;
        }
        public Vector2 CurrentPos()
        {
            return new Vector2((int)Position.X, (int)Position.Y);
        }
    }
}
