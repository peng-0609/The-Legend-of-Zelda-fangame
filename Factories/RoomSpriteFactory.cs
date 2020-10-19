using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class RoomSpriteFactory
    {
        private Texture2D roomSpritesheet;
        private Texture2D unlimitedSpritesheet;

        private static RoomSpriteFactory instance;

        public static RoomSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomSpriteFactory();
                }
                return instance;
            }
        }

        private RoomSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            roomSpritesheet = content.Load<Texture2D>("RoomSprites/Room");
            unlimitedSpritesheet = content.Load<Texture2D>("RoomSprites/Unlimited");
        }

        public ISprite CreateRoomSprite(int roomNum)
        {
            return new BackgroundSprite(roomSpritesheet, roomNum, 6, 6);
        }

        public ISprite CreateUnlimitedSprite(int roomNum)
        {
            return new BackgroundSprite(unlimitedSpritesheet, roomNum, 1, 1);
        }
    }
}
