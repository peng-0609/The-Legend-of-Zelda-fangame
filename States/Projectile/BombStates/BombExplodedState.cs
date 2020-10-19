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
    public class BombExplodedState : IProjectileState
    {
        private ISprite bombSprite;
        private Bomb bomb;
        public int Width { get; set; }
        public int Height { get; set; }
        private int timer = 0;

        public BombExplodedState(Bomb bomb)
        {
            this.bomb = bomb;
            bombSprite = ProjectileSpriteFactory.Instance.CreateBombSprite();
            
            this.Width = bombSprite.Width;
            this.Height = bombSprite.Height;
        }

        public void UseProjectile()
        {
            //Do nothing: bomb is already in this state.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bombSprite.Draw(spriteBatch, bomb.Position);
        }

        public void Update()
        {
            timer++;
            if (timer == 50)
            {
                bombSprite = ProjectileSpriteFactory.Instance.CreateUseBombSprite();
                SoundEffectFactory.Instance.PlayBombBlowSoundEffect();
                bomb.IsUsed = true;
            }
            if(timer == 100)
            {
                bomb.IsDisappeared = true;
            }
            bombSprite.Update();
        }

    }
}
