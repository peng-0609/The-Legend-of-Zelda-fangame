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
    public class Room : IRoom
    {
        public int RoomNum { get; set; }
        private Vector2 position;
        private ISprite roomSprite;
        private Dictionary<int, Vector2> coordHUD;
        private Dictionary<int, Vector2> coordMenu;

        public Room(int num)
        {
            this.RoomNum = num;
            position = new Vector2(0, 0);
            if (num > 18)
            {
                roomSprite = RoomSpriteFactory.Instance.CreateUnlimitedSprite(num);
            }
            else
            {
                roomSprite = RoomSpriteFactory.Instance.CreateRoomSprite(num);
            }

            coordHUD = new Dictionary<int, Vector2>
            {
                {1, new Vector2(115, 535)},
                {2, new Vector2(132, 535)},
                {3, new Vector2(148, 535)},
                {4, new Vector2(132, 526)},
                {5, new Vector2(113, 518)},
                {6, new Vector2(132, 518)},
                {7, new Vector2(150, 518)},
                {8, new Vector2(98, 509)},
                {9, new Vector2(115, 509)},
                {10, new Vector2(132, 509)},
                {11, new Vector2(150, 509)},
                {12, new Vector2(168, 509)},
                {13, new Vector2(115, 500)},
                {14, new Vector2(132, 500)},
                {15, new Vector2(166, 500)},
                {16, new Vector2(191, 497)},
                {17, new Vector2(115, 491)},
                {18, new Vector2(132, 491)},
                {21, new Vector2(115, 535)}
            };

            coordMenu = new Dictionary<int, Vector2>
            {
                {1, new Vector2(394, 393)},
                {2, new Vector2(418, 393)},
                {3, new Vector2(442, 393)},
                {4, new Vector2(418, 377)},
                {5, new Vector2(394, 360)},
                {6, new Vector2(418, 360)},
                {8, new Vector2(370, 342)},
                {9, new Vector2(394, 344)},
                {10, new Vector2(418, 342)},
                {11, new Vector2(442, 342)},
                {12, new Vector2(466, 342)},
                {14, new Vector2(418, 326)},
                {16, new Vector2(466, 326)},
                {18, new Vector2(418, 308)}
            };
        }

        public void Update()
        {
            roomSprite.Update();
        }

        public void DrawCoordHUD(SpriteBatch spriteBatch)
        {
            HUDSpriteFactory.Instance.CreateGreenPointSprite().Draw(spriteBatch, coordHUD[RoomNum]);
        }

        public void DrawCoordMenu(SpriteBatch spriteBatch)
        {
            if(coordMenu.ContainsKey(RoomNum))
                HUDSpriteFactory.Instance.CreateGreenPointSprite().Draw(spriteBatch, coordMenu[RoomNum]);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //roomSprite.Draw(spriteBatch, position);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 120, 640, 440);
        }
    }
}
