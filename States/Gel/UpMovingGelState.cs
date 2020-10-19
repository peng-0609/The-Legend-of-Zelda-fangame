using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2
{
    public class UpMovingGelState : IEnemyState
    {
        private Gel gel;
        private ISprite gelSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public UpMovingGelState(Gel gel)
        {
            this.gel = gel;
            gelSprite = EnemySpriteFactory.Instance.CreateGelWalkSprite();
            this.Width = gelSprite.Width;
            this.Height = gelSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            gel.State = new DownMovingGelState(gel);
        }

        public void MoveLeft()
        {
            gel.State = new LeftMovingGelState(gel);
        }

        public void MoveRight()
        {
            gel.State = new RightMovingGelState(gel);
        }

        public void Bekilled()
        {
            gel.State = new DeadGelState(gel);
        }

        public void Update()
        {
            gelSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gelSprite.Draw(spriteBatch, gel.Position);
        }
    }
}
