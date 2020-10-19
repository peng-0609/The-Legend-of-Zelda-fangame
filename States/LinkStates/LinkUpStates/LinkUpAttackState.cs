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
    class LinkUpAttackState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private Game1 game;
        private int timer = 60;
        private AttackSword sword;
        public int Width { get; set; }
        public int Height { get; set; }

        public LinkUpAttackState(Link link, Game1 game)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkAttackUpSprite();
            this.game = game;
            this.Width = linkSprite.Width;
            this.Height = linkSprite.Height;
            this.link.linkphysicalProperty.direction = Direction.UP;
            this.link.linkphysicalProperty.IsIdle = true;
            this.link.IsAttacking = true;
            sword = new AttackSword((int)link.Position.X, ((int)link.Position.Y - 24), link.linkphysicalProperty.direction);
            sword.UseProjectile();
            game.Level.Projectiles.Add(sword);
        }

        public void TakeDamage()
        {
            game.Link = new DamagedLink(link, game);
        }

        public void PickUpItem()
        {
            //link.State = new LinkPickUpState(link, game);
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

        public void Attack()
        {
            //link.State = new LinkUpAttackState(link, game);
        }

        public void Run()
        {
            if (timer <= 50)
            {
                game.Level.Projectiles.Remove(sword);
                link.State = new LinkUpRunState(link, game);
            }
        }

        public void Die()
        {
            link.State = new LinkDeadState(link, game);
        }

        public void FaceDown()
        {
            //link.State = new LinkDownIdleState(link, game);
        }

        public void FaceLeft()
        {
            //link.State = new LinkLeftIdleState(link, game);
        }

        public void FaceRight()
        {
            //link.State = new LinkRightIdleState(link, game);
        }

        public void FaceUp()
        {
            //link.State = new LinkUpIdleState(link, game);
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                link.State = new LinkUpIdleState(link, game);
            }
            linkSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, link.Position);
        }
    }
}
