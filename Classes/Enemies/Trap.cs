using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Trap : IEnemy
    {
        public IEnemyState State { get; set; }
        public Vector2 Position { get; set; }
        public Direction initialDir { get; set; }
        public String Name { get; set; }
        public EnemyPhysicalProperty Enemyphysics { get; set; }
        public bool IsDead { get; set; }
        public bool IsIdle { get; set; }
        public bool IsDisappeared { get; set; }
        public bool IsAccelerating { get; set; }
        private Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);

        public Trap(int x, int y)
        {
            Position = new Vector2(x, y);
            State = new LeftMovingTrapState(this);
            Enemyphysics = new EnemyPhysicalProperty(this);
            this.Name = "Trap";
            this.IsIdle = true;
            this.IsDead = false;
            this.IsDisappeared = false;
            this.IsAccelerating = true;
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
            if (this.initialDir == Direction.LEFT)
            {
                if (this.Enemyphysics.Direction == Direction.LEFT) {
                    this.Enemyphysics.Direction = Direction.RIGHT;
                    this.Enemyphysics.Velocity = new Vector2(-this.Enemyphysics.Velocity.X, Util.Instance.ZERO);
                    this.MoveRight();
                }
                else if(this.Enemyphysics.Direction == Direction.RIGHT){
                    this.Enemyphysics.Direction = Direction.LEFT;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, Util.Instance.ZERO);
                    this.IsIdle = true;
                }                    
            }
            else if (this.initialDir == Direction.DOWN)
            {
                if (this.Enemyphysics.Direction == Direction.DOWN)
                {
                    this.Enemyphysics.Direction = Direction.UP;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, -this.Enemyphysics.Velocity.Y);
                    this.MoveUp();
                }
                else if (this.Enemyphysics.Direction == Direction.UP)
                {
                    this.Enemyphysics.Direction = Direction.DOWN;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, Util.Instance.ZERO);
                    this.IsIdle = true;
                }
            }
            else if (this.initialDir == Direction.RIGHT)
            {
                if (this.Enemyphysics.Direction == Direction.RIGHT)
                {
                    this.Enemyphysics.Direction = Direction.LEFT;
                    this.Enemyphysics.Velocity = new Vector2(-this.Enemyphysics.Velocity.X, Util.Instance.ZERO);
                    this.MoveLeft();
                }
                else if (this.Enemyphysics.Direction == Direction.LEFT)
                {
                    this.Enemyphysics.Direction = Direction.RIGHT;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, Util.Instance.ZERO);
                    this.IsIdle = true;

                }
            }
            else
            {
                if (this.Enemyphysics.Direction == Direction.UP)
                {
                    this.Enemyphysics.Direction = Direction.DOWN;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, -this.Enemyphysics.Velocity.Y);
                    this.MoveDown();
                }
                else if (this.Enemyphysics.Direction == Direction.DOWN)
                {
                    this.Enemyphysics.Direction = Direction.UP;
                    this.Enemyphysics.Velocity = new Vector2(Util.Instance.ZERO, Util.Instance.ZERO);
                    this.IsIdle = true;
                }
            }
        }
        public void CollidedWithDoor()
        {
            SwitchDirection();
        }
        public void CollidedWithLink(IPlayer link, Direction direction,bool isRec,bool xSame, bool ySame)
        {

            if (link.IsAttacking && direction.Equals(link.linkphysicalProperty.direction))
            {
                Bekilled();
            }
            else
            {
                // or change state?
                if (isRec)
                {
                    LinkEnemyCollision.UpateLocation(link, this, xSame,ySame);
                }
                else
                {
                    link.TakeDamage();
                    LinkEnemyCollision.UpateLocation(link, this,  xSame, ySame);
                }
               
                
            }
        }
        public void CollidedWithBlock()
        {
            SwitchDirection();
        }
        public void CollidedWithWall()
        {
            SwitchDirection();
        }
        public void CollidedWithProjectile()
        {
            Bekilled();
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
