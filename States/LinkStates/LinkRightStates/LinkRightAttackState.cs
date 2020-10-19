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
    class LinkRightAttackState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private Game1 game;
        private int timer = 60;
        private AttackSword sword;
        public int Width { get; set; }
        public int Height { get; set; }

        public LinkRightAttackState(Link link, Game1 game)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkAttackRightSprite();
            this.game = game;
            this.Width = linkSprite.Width;
            this.Height = linkSprite.Height;
            this.link.linkphysicalProperty.direction = Direction.RIGHT;
            this.link.linkphysicalProperty.IsIdle = true;
            this.link.IsAttacking = true;
            sword = new AttackSword((int)link.Position.X + 24, (int)link.Position.Y + 13, link.linkphysicalProperty.direction);
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
            if (timer <= 50)
            {
                game.Level.Projectiles.Remove(sword);
                link.State = new LinkRightAttackState(link, game);
            }
        }

        public void Run()
        {
            //link.State = new LinkRightRunState(link, game);
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
                link.State = new LinkRightIdleState(link, game);
            }
            linkSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, link.Position);
        }
    }
}
