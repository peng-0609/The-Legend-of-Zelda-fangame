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
    public class BoomerangUsedState : IProjectileState
    {
        private ISprite boomerangSprite;
        private Boomerang boomerang;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;

        public BoomerangUsedState(Boomerang boomerang)
        {
            this.boomerang = boomerang;
            boomerangSprite = ProjectileSpriteFactory.Instance.CreateUseBoomerangSprite();
            this.boomerang.IsUsed = true;
            this.Width = boomerangSprite.Width;
            this.Height = boomerangSprite.Height;
        }

        public void UseProjectile()
        {
            //Do nothing: boomerang is already in this state.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            boomerangSprite.Draw(spriteBatch, boomerang.Position);
        }

        // UNFINISHED: MOVEMET
        // CHECK BY INITIAL POSITION (IN CASE COLLIDED WITH WALL/ENEMY)
        public void Update()
        {
            timer++;
            if (timer == 500)
            {
                boomerang.IsDisappeared = true;
            }
            boomerangSprite.Update();
        }

    }
}
