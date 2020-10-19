using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2
{
    public class RightMovingStalfosState : IEnemyState
    {
        private Stalfos stalfos;
        private ISprite stalfosSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public RightMovingStalfosState(Stalfos stalfos)
        {
            this.stalfos = stalfos;
            stalfosSprite = EnemySpriteFactory.Instance.CreateStalfosWalkSprite();
            this.Width = stalfosSprite.Width;
            this.Height = stalfosSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {
            stalfos.State = new UpMovingStalfosState(stalfos);
        }

        public void MoveDown()
        {
            stalfos.State = new DownMovingStalfosState(stalfos);
        }

        public void MoveLeft()
        {
            stalfos.State = new LeftMovingStalfosState(stalfos);
        }

        public void MoveRight()
        {

        }

        public void Bekilled()
        {
            stalfos.State = new DeadStalfosState(stalfos);
        }

        public void Update()
        {
            stalfosSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stalfosSprite.Draw(spriteBatch, stalfos.Position);
        }
    }
}