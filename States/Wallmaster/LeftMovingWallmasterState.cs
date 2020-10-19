using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint2
{
    public class LeftMovingWallmasterState : IEnemyState
    {
        private Wallmaster wallmaster;
        private ISprite wallmasterSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public LeftMovingWallmasterState(Wallmaster wallmaster)
        {
            this.wallmaster = wallmaster;
            wallmasterSprite = EnemySpriteFactory.Instance.CreateWallmasterWalkUpLeftSprite();
            this.Width = wallmasterSprite.Width;
            this.Height = wallmasterSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {
            wallmaster.State = new UpMovingWallmasterState(wallmaster);
        }

        public void MoveDown()
        {
            wallmaster.State = new DownMovingWallmasterState(wallmaster);
        }

        public void MoveLeft()
        {

        }

        public void MoveRight()
        {
            wallmaster.State = new RightMovingWallmasterState(wallmaster);
        }

        public void Bekilled()
        {
            wallmaster.State = new DeadWallmasterState(wallmaster);
        }

        public void Update()
        {
            wallmasterSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            wallmasterSprite.Draw(spriteBatch, wallmaster.Position);
        }
    }
}