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
    public class BombIdleState : IProjectileState
    {
        private ISprite bombSprite;
        private Bomb bomb;
        public int Width { get; set; }
        public int Height { get; set; }


        public BombIdleState(Bomb bomb)
        {
            this.bomb = bomb;
            bombSprite = ProjectileSpriteFactory.Instance.CreateBombSprite();
            this.Width = bombSprite.Width;
            this.Height = bombSprite.Height;
        }

        public void UseProjectile()
        {
            
            bomb.State = new BombExplodedState(bomb);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bombSprite.Draw(spriteBatch, bomb.Position);
        }

        public void Update()
        {
            
            bombSprite.Update();
        }

    }
}
