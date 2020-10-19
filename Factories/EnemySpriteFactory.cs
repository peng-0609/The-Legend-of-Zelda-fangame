using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class EnemySpriteFactory
    {
        private Texture2D goriyaWalkDownSpritesheet;
        private Texture2D goriyaWalkUpSpritesheet;
        private Texture2D goriyaWalkLeftSpritesheet;
        private Texture2D goriyaWalkRightSpritesheet;

        private Texture2D gelWalkSpritesheet;

        private Texture2D stalfosWalkSpritesheet;

        private Texture2D keeseWalkSpritesheet;

        private Texture2D trapSpritesheet;

        private Texture2D wallmasterWalkUpLeftSpritesheet;
        private Texture2D wallmasterWalkDownRightSpritesheet;

        private Texture2D aquamentusWalkLeftSpritesheet;
        private Texture2D aquamentusWalkRightSpritesheet;

        private Texture2D enemyCloudSpritesheet;

        private static EnemySpriteFactory instance;

        public static EnemySpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnemySpriteFactory();
                }
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            goriyaWalkDownSpritesheet = content.Load<Texture2D>("EnemySprites/GoriyaWalkDown");
            goriyaWalkUpSpritesheet = content.Load<Texture2D>("EnemySprites/GoriyaWalkUp");
            goriyaWalkLeftSpritesheet = content.Load<Texture2D>("EnemySprites/GoriyaWalkLeft");
            goriyaWalkRightSpritesheet = content.Load<Texture2D>("EnemySprites/GoriyaWalkRight");
            gelWalkSpritesheet = content.Load<Texture2D>("EnemySprites/GelWalk");
            stalfosWalkSpritesheet = content.Load<Texture2D>("EnemySprites/StalfosWalk");
            keeseWalkSpritesheet = content.Load<Texture2D>("EnemySprites/KeeseWalk");
            trapSpritesheet = content.Load<Texture2D>("EnemySprites/Trap");
            wallmasterWalkUpLeftSpritesheet = content.Load<Texture2D>("EnemySprites/WallmasterWalkUpLeft");
            wallmasterWalkDownRightSpritesheet = content.Load<Texture2D>("EnemySprites/WallmasterWalkDownRight");
            aquamentusWalkLeftSpritesheet = content.Load<Texture2D>("EnemySprites/AquamentusWalkLeft");
            aquamentusWalkRightSpritesheet = content.Load<Texture2D>("EnemySprites/AquamentusWalkRight");
            enemyCloudSpritesheet = content.Load<Texture2D>("EnemySprites/EnemyCloud");
        }

        public ISprite CreateGoriyaWalkDownSprite()
        {
            return new AnimatedSprite(goriyaWalkDownSpritesheet, 2, 1);
        }

        public ISprite CreateGoriyaWalkUpSprite()
        {
            return new AnimatedSprite(goriyaWalkUpSpritesheet, 2, 1);
        }

        public ISprite CreateGoriyaWalkLeftSprite()
        {
            return new AnimatedSprite(goriyaWalkLeftSpritesheet, 2, 1);
        }

        public ISprite CreateGoriyaWalkRightSprite()
        {
            return new AnimatedSprite(goriyaWalkRightSpritesheet, 2, 1);
        }

        public ISprite CreateGelWalkSprite()
        {
            return new AnimatedSprite(gelWalkSpritesheet, 2, 1);
        }

        public ISprite CreateStalfosWalkSprite()
        {
            return new AnimatedSprite(stalfosWalkSpritesheet, 1, 2);
        }

        public ISprite CreateKeeseWalkSprite()
        {
            return new AnimatedSprite(keeseWalkSpritesheet, 1, 2);
        }

        public ISprite CreateTrapSprite()
        {
            return new NonAnimatedSprite(trapSpritesheet);
        }

        public ISprite CreateWallmasterWalkUpLeftSprite()
        {
            return new AnimatedSprite(wallmasterWalkUpLeftSpritesheet, 2, 1);
        }

        public ISprite CreateWallmasterWalkDownRightSprite()
        {
            return new AnimatedSprite(wallmasterWalkDownRightSpritesheet, 2, 1);
        }

        public ISprite CreateAquamentusWalkLeftSprite()
        {
            return new AnimatedSprite(aquamentusWalkLeftSpritesheet, 1, 4);
        }

        public ISprite CreateAquamentusWalkRightSprite()
        {
            return new AnimatedSprite(aquamentusWalkRightSpritesheet, 1, 4);
        }

        public ISprite CreateEnemyCloudSprite()
        {
            return new AnimatedNonLoopSprite(enemyCloudSpritesheet, 1, 3);
        }
    }
}