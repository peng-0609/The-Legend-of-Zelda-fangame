using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class ProjectileSpriteFactory
    {
        private Texture2D bombSpritesheet;
        private Texture2D useBombSpritesheet;
        private Texture2D boomerangSpritesheet;
        private Texture2D useBoomerangSpritesheet;
        private Texture2D attackSwordUpSpriteSheet;
        private Texture2D attackSwordDownSpriteSheet;
        private Texture2D attackSwordLeftSpriteSheet;
        private Texture2D attackSwordRightSpriteSheet;
        private Texture2D shootedArrowUpSpriteSheet;
        private Texture2D shootedArrowDownSpriteSheet;
        private Texture2D shootedArrowLeftSpriteSheet;
        private Texture2D shootedArrowRightSpriteSheet;
        private Texture2D fireBallSpriteSheet;

        private static ProjectileSpriteFactory instance;

        public static ProjectileSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectileSpriteFactory();
                }
                return instance;
            }
        }

        private ProjectileSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bombSpritesheet = content.Load<Texture2D>("ProjectileSprites/Bomb");
            useBombSpritesheet = content.Load<Texture2D>("ProjectileSprites/UseBomb");
            boomerangSpritesheet = content.Load<Texture2D>("ProjectileSprites/Boomerang");
            useBoomerangSpritesheet = content.Load<Texture2D>("ProjectileSprites/UseBoomerang");
            attackSwordUpSpriteSheet = content.Load<Texture2D>("ProjectileSprites/AttackSwordUp");
            attackSwordDownSpriteSheet = content.Load<Texture2D>("ProjectileSprites/AttackSwordDown");
            attackSwordLeftSpriteSheet = content.Load<Texture2D>("ProjectileSprites/AttackSwordLeft");
            attackSwordRightSpriteSheet = content.Load<Texture2D>("ProjectileSprites/AttackSwordRight");
            shootedArrowUpSpriteSheet = content.Load<Texture2D>("ProjectileSprites/ShootedArrowUp");
            shootedArrowDownSpriteSheet = content.Load<Texture2D>("ProjectileSprites/ShootedArrowDown");
            shootedArrowLeftSpriteSheet = content.Load<Texture2D>("ProjectileSprites/ShootedArrowLeft");
            shootedArrowRightSpriteSheet = content.Load<Texture2D>("ProjectileSprites/ShootedArrowRight");
            fireBallSpriteSheet = content.Load<Texture2D>("ProjectileSprites/FireBall");
        }

        public ISprite CreateBombSprite()
        {
            return new NonAnimatedSprite(bombSpritesheet);
        }

        public ISprite CreateUseBombSprite()
        {
            return new AnimatedNonLoopSprite(useBombSpritesheet, 4, 1);
        }

        public ISprite CreateBoomerangSprite()
        {
            return new NonAnimatedSprite(boomerangSpritesheet);
        }

        public ISprite CreateUseBoomerangSprite()
        {
            return new AnimatedSprite(useBoomerangSpritesheet, 1, 3);
        }

        public ISprite CreateAttackSwordSprite(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return new NonAnimatedSprite(attackSwordUpSpriteSheet);
                case Direction.DOWN:
                    return new NonAnimatedSprite(attackSwordDownSpriteSheet);
                case Direction.LEFT:
                    return new NonAnimatedSprite(attackSwordLeftSpriteSheet);
                case Direction.RIGHT:
                    return new NonAnimatedSprite(attackSwordRightSpriteSheet);
                default:
                    return null;
            }
        }

        public ISprite CreateShootedArrowSprite(Direction direction)
        {
            switch (direction)
            {
                case Direction.UP:
                    return new NonAnimatedSprite(shootedArrowUpSpriteSheet);
                case Direction.DOWN:
                    return new NonAnimatedSprite(shootedArrowDownSpriteSheet);
                case Direction.LEFT:
                    return new NonAnimatedSprite(shootedArrowLeftSpriteSheet);
                case Direction.RIGHT:
                    return new NonAnimatedSprite(shootedArrowRightSpriteSheet);
                default:
                    return null;
            }
        }

        public ISprite CreateFireBallSprite()
        {
            return new NonAnimatedSprite(fireBallSpriteSheet);
        }
    }
}
