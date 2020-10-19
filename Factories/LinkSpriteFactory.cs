using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class LinkSpriteFactory
    {
        private Texture2D linkIdleDownSpritesheet;
        private Texture2D linkIdleUpSpritesheet;
        private Texture2D linkIdleLeftSpritesheet;
        private Texture2D linkIdleRightSpritesheet;
        private Texture2D linkWalkDownSpritesheet;
        private Texture2D linkWalkUpSpritesheet;
        private Texture2D linkWalkLeftSpritesheet;
        private Texture2D linkWalkRightSpritesheet;
        private Texture2D linkAttackDownSpritesheet;
        private Texture2D linkAttackUpSpritesheet;
        private Texture2D linkAttackLeftSpritesheet;
        private Texture2D linkAttackRightSpritesheet;
        private Texture2D linkPickUpSpritesheet;
        private Texture2D linkDamagedSpritesheet;

        private static LinkSpriteFactory instance;

        public static LinkSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LinkSpriteFactory();
                }
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkIdleDownSpritesheet = content.Load<Texture2D>("LinkSprites/LinkIdleDown");
            linkIdleUpSpritesheet = content.Load<Texture2D>("LinkSprites/LinkIdleUp");
            linkIdleLeftSpritesheet = content.Load<Texture2D>("LinkSprites/LinkIdleLeft");
            linkIdleRightSpritesheet = content.Load<Texture2D>("LinkSprites/LinkIdleRight");
            linkWalkDownSpritesheet = content.Load<Texture2D>("LinkSprites/LinkWalkDown");
            linkWalkUpSpritesheet = content.Load<Texture2D>("LinkSprites/LinkWalkUp");
            linkWalkLeftSpritesheet = content.Load<Texture2D>("LinkSprites/LinkWalkLeft");
            linkWalkRightSpritesheet = content.Load<Texture2D>("LinkSprites/LinkWalkRight");
            linkAttackDownSpritesheet = content.Load<Texture2D>("LinkSprites/LinkAttackDown");
            linkAttackUpSpritesheet = content.Load<Texture2D>("LinkSprites/LinkAttackUp");
            linkAttackLeftSpritesheet = content.Load<Texture2D>("LinkSprites/LinkAttackLeft");
            linkAttackRightSpritesheet = content.Load<Texture2D>("LinkSprites/LinkAttackRight");
            linkPickUpSpritesheet = content.Load<Texture2D>("LinkSprites/LinkPickUp");
            linkDamagedSpritesheet = content.Load<Texture2D>("LinkSprites/LinkDamaged");
        }

        public ISprite CreateLinkIdleDownSprite()
        {
            return new NonAnimatedSprite(linkIdleDownSpritesheet);
        }

        public ISprite CreateLinkIdleUpSprite()
        {
            return new NonAnimatedSprite(linkIdleUpSpritesheet);
        }

        public ISprite CreateLinkIdleLeftSprite()
        {
            return new NonAnimatedSprite(linkIdleLeftSpritesheet);
        }

        public ISprite CreateLinkIdleRightSprite()
        {
            return new NonAnimatedSprite(linkIdleRightSpritesheet);
        }

        public ISprite CreateLinkWalkDownSprite()
        {
            return new AnimatedSprite(linkWalkDownSpritesheet, 2, 1);
        }

        public ISprite CreateLinkWalkUpSprite()
        {
            return new AnimatedSprite(linkWalkUpSpritesheet, 2, 1);
        }

        public ISprite CreateLinkWalkLeftSprite()
        {
            return new AnimatedSprite(linkWalkLeftSpritesheet, 2, 1);
        }

        public ISprite CreateLinkWalkRightSprite()
        {
            return new AnimatedSprite(linkWalkRightSpritesheet, 2, 1);
        }

        public ISprite CreateLinkAttackDownSprite()
        {
            return new AnimatedNonLoopSprite(linkAttackDownSpritesheet, 3, 1);
        }

        public ISprite CreateLinkAttackUpSprite()
        {
            return new AnimatedNonLoopSprite(linkAttackUpSpritesheet, 3, 1);
        }

        public ISprite CreateLinkAttackLeftSprite()
        {
            return new AnimatedNonLoopSprite(linkAttackLeftSpritesheet, 3, 1);
        }

        public ISprite CreateLinkAttackRightSprite()
        {
            return new AnimatedNonLoopSprite(linkAttackRightSpritesheet, 3, 1);
        }

        public ISprite CreateLinkPickUpSprite()
        {
            return new AnimatedNonLoopSprite(linkPickUpSpritesheet, 1, 2);
        }

        public ISprite CreateLinkDamagedSprite()
        {
            return new AnimatedNonLoopSprite(linkDamagedSpritesheet, 1, 3);
        }
    }
}
