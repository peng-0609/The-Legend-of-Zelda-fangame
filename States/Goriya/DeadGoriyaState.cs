using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class DeadGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private ISprite goriyaSprite;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;

        public DeadGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            goriyaSprite = EnemySpriteFactory.Instance.CreateEnemyCloudSprite();
            this.Width = goriyaSprite.Width;
            this.Height = goriyaSprite.Height;
            this.goriya.IsDead = true;
            SoundEffectFactory.Instance.PlayEnemyDieSoundEffect();
        }
        public void Attack()
        {

        }
        public void MoveLeft()
        {
           
        }

        public void MoveRight()
        {
            
        }

        public void MoveUp()
        {
            
        }

        public void MoveDown()
        {
            
        }

        public void Bekilled()
        {
            
        }

        public void Update()
        {
            timer++;
            if (timer == 46)
                this.goriya.IsDisappeared = true;
            goriyaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goriyaSprite.Draw(spriteBatch, goriya.Position);
        }
    }
}
