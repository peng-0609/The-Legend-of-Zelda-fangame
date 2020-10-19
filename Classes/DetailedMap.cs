using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class DetailedMap
    {
        private Vector2 position;
        private ISprite detailedMapSprite;

        public DetailedMap(int x, int y)
        {
            position.X = x;
            position.Y = y;
            detailedMapSprite = ItemSpriteFactory.Instance.CreateDetailedMapSprite();
        }

        public void Update()
        {
            detailedMapSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            detailedMapSprite.Draw(spriteBatch, position);
        }
    }
}
