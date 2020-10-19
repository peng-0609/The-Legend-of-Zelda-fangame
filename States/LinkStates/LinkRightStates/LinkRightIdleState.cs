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
    class LinkRightIdleState : ILinkState
    {
        private ISprite linkSprite;
        private Link link;
        private Game1 game;
        public int Width { get; set; }
        public int Height { get; set; }

        public LinkRightIdleState(Link link, Game1 game)
        {
            this.link = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkIdleRightSprite();
            this.game = game;
            this.Width = linkSprite.Width;
            this.Height = linkSprite.Height;
            this.link.linkphysicalProperty.direction = Direction.RIGHT;
            this.link.linkphysicalProperty.IsIdle = true;
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
            link.Inventory.BombCount--;
            Bomb bomb = new Bomb((int)link.Position.X + this.Width, (int)link.Position.Y);
            bomb.UseProjectile();
            game.Level.Projectiles.Add(bomb);
        }

        public void UseBoomerang()
        {
            Boomerang boomerang = new Boomerang((int)link.Position.X + this.Width, (int)link.Position.Y,link.linkphysicalProperty.direction);
            boomerang.UseProjectile();
            game.Level.Projectiles.Add(boomerang);
        }
        
        public void Shoot()
        {
            ShootedArrow arrow = new ShootedArrow((int)link.Position.X + this.Width, (int)link.Position.Y, link.linkphysicalProperty.direction);
            arrow.UseProjectile();
            game.Level.Projectiles.Add(arrow);
        }

        public void Attack()
        {
            link.State = new LinkRightAttackState(link, game);
        }

        public void Run()
        {
            link.State = new LinkRightRunState(link, game);
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
            //Do nothing: Link is already in this State.
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
