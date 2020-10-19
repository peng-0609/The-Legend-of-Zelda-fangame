using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class Water : IWater
    {
        public Vector2 Position { get; set; }
        private ISprite waterSprite;
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width, Sprite.Height);
        private static ISprite Sprite = ArtifactSpriteFactory.Instance.CreateWaterSprite();
        public Water(int x, int y)
        {
            Position = new Vector2(x, y);
            waterSprite = ArtifactSpriteFactory.Instance.CreateWaterSprite();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            waterSprite.Draw(spriteBatch, Position);
        }

        public void CollidedWithLink(IPlayer link, Direction direction)
        {
            LinkWaterCollision.UpateLocation(link, this, direction);
        }
        public void CollidedWithEnemy(IEnemy enemy, Direction direction)
        {
            EnemyWaterCollision.UpateLocation(enemy, this, direction);
        }

        public Rectangle GetRectangle()
        {
            return Rectangle;
        }

        public void Update()
        {
            waterSprite.Update();
        }

    }
}
