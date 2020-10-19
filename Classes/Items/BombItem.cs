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
    class BombItem : IItem
    {
        private Vector2 position;
        private ISprite bombItemSprite;
        public bool Picked { get; set; }
        public String Name { get; set; }

        public BombItem(int x, int y)
        {
            position.X = x;
            position.Y = y;
            bombItemSprite = ProjectileSpriteFactory.Instance.CreateBombSprite();
            this.Picked = false;
            this.Name = "bomb";
        }

        public void IsPicked()
        {
            this.Picked = true;
            SoundEffectFactory.Instance.PlayGetItemSoundEffect();
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)position.X, (int)position.Y, bombItemSprite.Width, bombItemSprite.Height);
        }

        public void CollidedWithLink(IPlayer link)
        {
            // or change state?
            this.IsPicked();
            link.PickUpItem(this.Name);
        }

        public void Update()
        {
            bombItemSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            bombItemSprite.Draw(spriteBatch, position);
        }
    }
}
