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
    class LinkPickUpState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private Game1 game;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 60;

        public LinkPickUpState(Link link, Game1 game)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkPickUpSprite();
            this.link.linkphysicalProperty.IsIdle = true;
            this.link.linkphysicalProperty.direction = Direction.DOWN;
            this.game = game;
            this.Width = linkSprite.Width;
            this.Height = linkSprite.Height;
            this.link.IsAttacking = true;
        }

        public void TakeDamage()
        {
            game.Link = new DamagedLink(link, game);
        }

        public void Attack()
        {
            link.State = new LinkDownAttackState(link, game);
        }

        public void Die()
        {
            link.State = new LinkDeadState(link, game);
        }

        public void PickUpItem()
        {
            //Do nothing: Link is already in this state.
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

        public void Run()
        {
            link.State = new LinkDownRunState(link, game);
        }

        public void UseBomb()
        {
            //Do nothing. Link cannot use item in this state.
        }

        public void UseBoomerang()
        {
            //Do nothing. Link cannot use item in this state.
        }

        public void Shoot()
        {
            //Do nothing. Link cannot use item in this state.
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                link.State = new LinkDownIdleState(link, game);
            }
            linkSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, link.Position);
        }
    }
}
