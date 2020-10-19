using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Goriya : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public Direction initialDir { get; set; }
        public String Name { get; set; }
        public EnemyPhysicalProperty Enemyphysics { get; set; }
        public bool IsDead { get; set; }
        public bool IsDisappeared { get; set; }
        public bool IsIdle { get; set; }
        public bool IsAccelerating { get; set; }
        private Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);

        public Goriya(int x, int y)
        {
            Position = new Vector2(x, y);
            Enemyphysics = new EnemyPhysicalProperty(this);
            State = new LeftMovingGoriyaState(this);
            this.Name = "Goriya";
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
        public void CollidedWithProjectile()
        {
            Bekilled();
        }
        public void CollidedWithDoor()
        {
            SwitchDirection();
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
        public void Update(GameTime gameTime)
        {
            State.Update();
            Enemyphysics.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatct)
        {
            State.Draw(spriteBatct);
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
