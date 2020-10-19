using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sprint2
{
    public class RightMovingAquamentusState : IEnemyState
    {
        private ILevel level;
        private Aquamentus aquamentus;
        private ISprite aquamentusSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public RightMovingAquamentusState(Aquamentus aquamentus, ILevel level)
        {
            this.aquamentus = aquamentus;
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusWalkRightSprite();
            this.Width = aquamentusSprite.Width;
            this.Height = aquamentusSprite.Height;
            this.level = level;
        }
        public void Attack()
        {
            FireBall fireball = new FireBall((int)aquamentus.Position.X+40, ((int)aquamentus.Position.Y+20), aquamentus.Enemyphysics.Direction);
            fireball.UseProjectile();
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
            aquamentus.State = new LeftMovingAquamentusState(aquamentus,level);
        }

        public void MoveRight()
        {

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
