using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint2
{
    public class RightMovingTrapState : IEnemyState
    {
        private Trap trap;
        private ISprite trapSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public RightMovingTrapState(Trap trap)
        {
            this.trap = trap;
            trapSprite = EnemySpriteFactory.Instance.CreateTrapSprite();
            this.Width = trapSprite.Width;
            this.Height = trapSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {
            trap.State = new UpMovingTrapState(trap);
        }

        public void MoveDown()
        {
            trap.State = new DownMovingTrapState(trap);
        }

        public void MoveLeft()
        {
            trap.State = new LeftMovingTrapState(trap);
        }

        public void MoveRight()
        {

        }

        public void Bekilled()
        {
            trap.State = new DeadTrapState(trap);
        }

        public void Update()
        {
            trapSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trapSprite.Draw(spriteBatch, trap.Position);
        }
    }
}
