using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class SwordAttackState : IProjectileState
    {
        private ISprite swordSprite;
        private AttackSword sword;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;

        public SwordAttackState(AttackSword sword, Direction direction)
        {
            this.sword = sword;
            swordSprite = ProjectileSpriteFactory.Instance.CreateAttackSwordSprite(direction);
            sword.IsUsed = true;
            this.Width = swordSprite.Width;
            this.Height = swordSprite.Height;
        }

        public void UseProjectile()
        {
            //Do nothing: sword is already in this state.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(timer>=15&&timer<45)
                swordSprite.Draw(spriteBatch, sword.Position);
        }

        public void Update()
        {
            timer++;
            if (timer == 50)
            {
                sword.IsDisappeared = true;
            }
            swordSprite.Update();
        }

    }
}
