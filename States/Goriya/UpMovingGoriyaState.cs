using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class UpMovingGoriyaState : IEnemyState
    {
        private Goriya goriya;
        private ISprite goriyaSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public UpMovingGoriyaState(Goriya goriya)
        {
            this.goriya = goriya;
            goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaWalkUpSprite();
            this.Width = goriyaSprite.Width;
            this.Height = goriyaSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            goriya.State = new DownMovingGoriyaState(goriya);
        }

        public void MoveLeft()
        {
            goriya.State = new LeftMovingGoriyaState(goriya);
        }

        public void MoveRight()
        {
            goriya.State = new RightMovingGoriyaState(goriya);
        }

        public void Bekilled()
        {
            goriya.State = new DeadGoriyaState(goriya);
        }

        public void Update()
        {
            goriyaSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            goriyaSprite.Draw(spriteBatch, goriya.Position);
        }
    }
}
