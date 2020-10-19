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
    public class ShootedArrowUpState : IProjectileState
    {
        public int Width { get ; set; }
        public int Height { get ; set ; }
        private ISprite arrowSprite;
        private ShootedArrow arrow;

        public ShootedArrowUpState(ShootedArrow arrow)
        {
            this.arrow = arrow;
            arrowSprite = ProjectileSpriteFactory.Instance.CreateShootedArrowSprite(Direction.UP);
            //direction
            this.Width = arrowSprite.Width;
            this.Height = arrowSprite.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            arrowSprite.Draw(spriteBatch, arrow.Position);
        }

        public void Update()
        {
            arrowSprite.Update();
        }

        public void UseProjectile()
        {
            //Do nothing: Arrow is already in this state.
        }
    }
}
