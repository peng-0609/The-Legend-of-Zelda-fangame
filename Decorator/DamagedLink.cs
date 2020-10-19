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
    public class DamagedLink : IPlayer
    {
        private Game1 game;
        private IPlayer decoratedLink;
        private int timer = 50;
        public ILinkState State { get; set; }
        public Vector2 Position { get; set; }
        public LinkPhysicalProperty linkphysicalProperty { get; set; }
        public LinkInventoryProperty Inventory { get; set; }
        public bool IsAttacking { get; set; }
        public bool OneHpMode { get; set; }
        public int Health { get; set; }

        public DamagedLink(IPlayer link, Game1 game) 
        {
            this.decoratedLink = link;
            linkphysicalProperty = link.linkphysicalProperty;
            this.State = link.State;
            this.Position = new Vector2(link.Position.X,link.Position.Y);
            this.game = game;
            this.Inventory = link.Inventory;
            this.OneHpMode = link.OneHpMode;
        }

        public void Attack()
        {
            decoratedLink.Attack();
        }

        public void Die()
        {
            decoratedLink.Die();
        }

        public void FaceDown()
        {
            decoratedLink.FaceDown();
        }

        public void FaceLeft()
        {
            decoratedLink.FaceLeft();
        }

        public void FaceRight()
        {
            decoratedLink.FaceRight();
        }

        public void FaceUp()
        {
            decoratedLink.FaceUp();
        }

        public void PickUpItem(String itemName)
        {
            decoratedLink.PickUpItem(itemName);
        }

        public void UseBomb()
        {
            decoratedLink.UseBomb();
        }

        public void UseBoomerang()
        {
            decoratedLink.UseBoomerang();
        }

        public void Shoot()
        {
            decoratedLink.Shoot();
        }

        public void Run()
        {
            decoratedLink.Run();
        }

        public void TakeDamage()
        {
            //Does not take damage in current state.
        }

        public void Update(GameTime gameTime)
        {
            
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
            decoratedLink.Update(gameTime);
            this.Position = new Vector2(decoratedLink.Position.X, decoratedLink.Position.Y);
        }

        private void RemoveDecorator()
        {
            game.Link = decoratedLink;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (timer %10 <7)
            {
                decoratedLink.Draw(spriteBatch);
            }
        }

        public Rectangle GetRectangle()
        {
            return decoratedLink.GetRectangle();
        }

        public void SetPos(Vector2 pos)
        {
            this.Position = pos;
            decoratedLink.Position = pos;
        }
    }
}
