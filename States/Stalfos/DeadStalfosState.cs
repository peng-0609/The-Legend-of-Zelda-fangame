using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class DeadStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private ISprite stalfosSprite;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;

        public DeadStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            stalfosSprite = EnemySpriteFactory.Instance.CreateEnemyCloudSprite();
            this.Width = stalfosSprite.Width;
            this.Height = stalfosSprite.Height;
            this.stalfos.IsDead = true;
            SoundEffectFactory.Instance.PlayEnemyDieSoundEffect();
        }
        public void Attack()
        {

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
        }

        public void Bekilled()
        {   
        }

        public void Update()
        {
            timer++;
            if (timer == 46)
                this.stalfos.IsDisappeared = true;
            stalfosSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stalfosSprite.Draw(spriteBatch, stalfos.Position);
        }
    }
}
