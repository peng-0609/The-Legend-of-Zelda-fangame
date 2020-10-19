using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2
{
    public class UpMovingKeeseState : IEnemyState
    {
        private Keese keese;
        private ISprite keeseSprite;
        public int Width { get; set; }
        public int Height { get; set; }

        public UpMovingKeeseState(Keese keese)
        {
            this.keese = keese;
            keeseSprite = EnemySpriteFactory.Instance.CreateKeeseWalkSprite();
            this.Width = keeseSprite.Width;
            this.Height = keeseSprite.Height;
        }
        public void Attack()
        {

        }
        public void MoveUp()
        {

        }

        public void MoveDown()
        {
            keese.State = new DownMovingKeeseState(keese);
        }

        public void MoveLeft()
        {
            keese.State = new LeftMovingKeeseState(keese);
        }

        public void MoveRight()
        {
            keese.State = new RightMovingKeeseState(keese);
        }

        public void Bekilled()
        {
            keese.State = new DeadKeeseState(keese);
        }

        public void Update()
        {
            keeseSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            keeseSprite.Draw(spriteBatch, keese.Position);
        }
    }
}
