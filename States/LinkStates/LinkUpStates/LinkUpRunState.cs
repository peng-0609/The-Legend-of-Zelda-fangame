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
    class LinkUpRunState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private Game1 game;
        public int Width { get; set; }
        public int Height { get; set; }
        public LinkUpRunState(Link link, Game1 game)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkWalkUpSprite();
            this.game = game;
            this.Width = linkSprite.Width;
            this.Height = linkSprite.Height;
            this.link.linkphysicalProperty.direction = Direction.UP;
            this.link.linkphysicalProperty.IsIdle = false;
            this.link.IsAttacking = false;
        }

        public void TakeDamage()
        {
            game.Link = new DamagedLink(link, game);
        }

        public void PickUpItem()
        {
            link.State = new LinkPickUpState(link, game);
        }
        public void UseBomb()
        {
            link.State = new LinkUpIdleState(link, game);
            link.UseBomb();
        }
        public void UseBoomerang()
        {
            link.State = new LinkUpIdleState(link, game);
            link.UseBoomerang();
        }

        public void Shoot()
        {
            link.State = new LinkUpIdleState(link, game);
            link.Shoot();
        }


        public void Attack()
        {
            link.State = new LinkUpAttackState(link, game);
        }

        public void Run()
        {
            
            //Do nothing: Link is already in this State.
        }

        public void Die()
        {
            link.State = new LinkDeadState(link, game);
        }

        public void FaceDown()
        {
            link.State = new LinkDownIdleState(link, game);
        }

        public void FaceLeft()
        {
            link.State = new LinkLeftIdleState(link, game);
        }

        public void FaceRight()
        {
            link.State = new LinkRightIdleState(link, game);
        }

        public void FaceUp()
        {
            link.State = new LinkUpIdleState(link, game);
        }

        public void Update()
        {
            linkSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, link.Position);
        }
    }
}
