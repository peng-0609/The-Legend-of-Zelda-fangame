using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint2
{
    public class LeftMovingAquamentusState : IEnemyState
    {
        private ILevel level;
        private Aquamentus aquamentus;
        private ISprite aquamentusSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public LeftMovingAquamentusState(Aquamentus aquamentus,ILevel level)
        {
            this.aquamentus = aquamentus;
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusWalkLeftSprite();
            this.Width = aquamentusSprite.Width;
            this.Height = aquamentusSprite.Height;
            this.level = level;
        }
        public void Attack()
        {
            FireBall fireball = new FireBall((int)aquamentus.Position.X, ((int)aquamentus.Position.Y+20), aquamentus.Enemyphysics.Direction);
            //Boomerang b = new Boomerang((int)aquamentus.Position.X - 20, (int)aquamentus.Position.Y, aquamentus.Enemyphysics.Direction);
            fireball.UseProjectile();
            // game.Level.Projectiles.Add(fireball);
            //b.UseProjectile();
            level.Projectiles.Add(fireball);
        }
        public void MoveUp()
        {

        }

        public void MoveDown()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            aquamentus.State = new RightMovingAquamentusState(aquamentus,level);
        }

        public void Bekilled()
        {
            aquamentus.State = new DeadAquamentusState(aquamentus);
        }

        public void Update()
        {
            aquamentusSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aquamentusSprite.Draw(spriteBatch, aquamentus.Position);
        }
    }
}