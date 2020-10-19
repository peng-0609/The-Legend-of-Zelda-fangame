using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class DeadAquamentusState : IEnemyState
    {
        private Aquamentus aquamentus;
        private ISprite aquamentusSprite;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;
        public DeadAquamentusState(Aquamentus aquamentus)
        {
            this.aquamentus = aquamentus;
            aquamentusSprite = EnemySpriteFactory.Instance.CreateEnemyCloudSprite();
            this.Width = aquamentusSprite.Width;
            this.Height = aquamentusSprite.Height;
            this.aquamentus.IsDead = true;
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
                this.aquamentus.IsDisappeared = true;
            aquamentusSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aquamentusSprite.Draw(spriteBatch, aquamentus.Position);
        }
    }
}
