using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{

    public class Aquamentus : IEnemy
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
        private int timer = 150;
        private Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        public Aquamentus(int x, int y,ILevel level)
        {
            Position = new Vector2(x, y);
            State = new LeftMovingAquamentusState(this,level);
            Enemyphysics = new EnemyPhysicalProperty(this);
            this.IsDead = false;
            this.IsIdle = false;
            this.IsDisappeared = false;
            this.IsAccelerating = false;
            this.Name = "Aquamentus";
            SoundEffectFactory.Instance.PlayBossScreamSoundEffect();
        }

        public void Bekilled()
        {
            State.Bekilled();
        }

        public void MoveDown()
        {

        }

        public void MoveUp()
        {

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
            if (this.Enemyphysics.Direction == Direction.LEFT)
            {
                this.Enemyphysics.Direction = Direction.RIGHT;
                State.MoveRight();
            }
            else if (this.Enemyphysics.Direction == Direction.RIGHT)
            {
                this.Enemyphysics.Direction = Direction.LEFT;
                State.MoveLeft();
            }
        }
        public void CollidedWithLink(IPlayer link, Direction direction,bool isRec, bool xSame, bool ySame)
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
        public void CollidedWithDoor()
        {
            SwitchDirection();
        }
        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer == 0)
            {
                timer = 150;
                State.Attack();
            }
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
        public void Attack()
        {
            State.Attack();
            //SoundEffectFactory.Instance.xxxxxxxSoundEffect();
        }
        public void CollidedWithProjectile()
        {
            Bekilled();
        }
        public Vector2 CurrentPos()
        {
            return new Vector2((int)Position.X, (int)Position.Y);
        }
    }
}
