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
    public enum Direction
    {
        UP, DOWN, LEFT, RIGHT
    }
    public class Link: IPlayer
    {
        public ILinkState State { get; set; }
        public Vector2 Position { get; set; }
        public LinkPhysicalProperty linkphysicalProperty { get; set; }
        public bool IsAttacking { get; set; }
        public bool OneHpMode { get; set; }
        public LinkInventoryProperty Inventory { get; set; }

        private Game1 game;



        public Link(int x, int y, Game1 game)
        {
            linkphysicalProperty = new LinkPhysicalProperty(this);
            this.game = game;
            this.OneHpMode = false;
            Position = new Vector2(x, y);
            Inventory = new LinkInventoryProperty(this);
            State = new LinkDownIdleState(this, game);
            
        }

        public void TakeDamage()
        {
            Inventory.Health--;
            if (this.Inventory.Health > 0)
            {
                State.TakeDamage();
                SoundEffectFactory.Instance.PlayLinkHurtSoundEffect();
            }
            else
                this.Die();
        }
        public void Die()
        {
            State.Die();
        }

        public void FaceUp()
        {
            State.FaceUp();
        }

        public void FaceDown()
        {
            State.FaceDown();
        }
        public void FaceLeft()
        {
            State.FaceLeft();
        }

        public void FaceRight()
        {
            State.FaceRight();
        }

        public void Run()
        {
            State.Run();
        }

        public void Attack()
        {
            State.Attack();
            SoundEffectFactory.Instance.PlaySwordSlashSoundEffect();
        }

        //TODO: Add itemName parameter
        public void PickUpItem(String itemName)
        {
            Inventory.PickUpItem(itemName);
            State.PickUpItem();
        }

        public void UseBomb()
        {
            if (Inventory.BombCount > 0)
            { 
                State.UseBomb();
                //Inventory.BombCount--;
                SoundEffectFactory.Instance.PlayBombDropSoundEffect();
            }
        }

        public void UseBoomerang()
        {
            if (Inventory.BoomerangPicked)
            {
                State.UseBoomerang();
                SoundEffectFactory.Instance.PlayArrowBoomerangSoundEffect();
            }
        }

        public void Shoot()
        {
            if (Inventory.BowPicked)
            {
                State.Shoot();
                SoundEffectFactory.Instance.PlayArrowBoomerangSoundEffect();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, State.Width, State.Height);
        }

        public void Update(GameTime gameTime)
        {
            State.Update();
            linkphysicalProperty.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch);
        }

        public void SetPos(Vector2 pos)
        {
            this.Position = pos;
        }
    }
}
