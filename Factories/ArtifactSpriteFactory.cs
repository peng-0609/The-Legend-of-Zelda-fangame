using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class ArtifactSpriteFactory
    {
        private Texture2D movableBlockSpritesheet;
        private Texture2D waterSpritesheet;
        private Texture2D upOpenDoorSpritesheet;
        private Texture2D downOpenDoorSpritesheet;
        private Texture2D leftOpenDoorSpritesheet;
        private Texture2D rightOpenDoorSpritesheet;
        private Texture2D upClosedDoorSpritesheet;
        private Texture2D downClosedDoorSpritesheet;
        private Texture2D leftClosedDoorSpritesheet;
        private Texture2D rightClosedDoorSpritesheet;
        private Texture2D upLockedDoorSpritesheet;
        private Texture2D downLockedDoorSpritesheet;
        private Texture2D leftLockedDoorSpritesheet;
        private Texture2D rightLockedDoorSpritesheet;


        private static ArtifactSpriteFactory instance;

        public static ArtifactSpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtifactSpriteFactory();
                }
                return instance;
            }
        }

        private ArtifactSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            movableBlockSpritesheet = content.Load<Texture2D>("ArtifactSprites/MovableBlock");
            waterSpritesheet = content.Load<Texture2D>("ArtifactSprites/Water");
            upOpenDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/UpOpenDoor");
            downOpenDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/DownOpenDoor");
            leftOpenDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/LeftOpenDoor");
            rightOpenDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/RightOpenDoor");
            upClosedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/UpClosedDoor");
            downClosedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/DownClosedDoor");
            leftClosedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/LeftClosedDoor");
            rightClosedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/RightClosedDoor");
            upLockedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/UpLockedDoor");
            downLockedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/DownLockedDoor");
            leftLockedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/LeftLockedDoor");
            rightLockedDoorSpritesheet = content.Load<Texture2D>("ArtifactSprites/RightClosedDoor");
        }

        public ISprite CreateMovableBlockSprite()
        {
            return new NonAnimatedSprite(movableBlockSpritesheet);
        }

        public ISprite CreateWaterSprite()
        {
            return new NonAnimatedSprite(waterSpritesheet);
        }

        public ISprite CreateUpOpenDoorSprite()
        {
            return new NonAnimatedSprite(upOpenDoorSpritesheet);
        }

        public ISprite CreateDownOpenDoorSprite()
        {
            return new NonAnimatedSprite(downOpenDoorSpritesheet);
        }
        public ISprite CreateLeftOpenDoorSprite()
        {
            return new NonAnimatedSprite(leftOpenDoorSpritesheet);
        }

        public ISprite CreateRightOpenDoorSprite()
        {
            return new NonAnimatedSprite(rightOpenDoorSpritesheet);
        }
        public ISprite CreateUpClosedDoorSprite()
        {
            return new NonAnimatedSprite(upClosedDoorSpritesheet);
        }

        public ISprite CreateDownClosedDoorSprite()
        {
            return new NonAnimatedSprite(downClosedDoorSpritesheet);
        }

        public ISprite CreateLeftClosedDoorSprite()
        {
            return new NonAnimatedSprite(leftClosedDoorSpritesheet);
        }

        public ISprite CreateRightClosedDoorSprite()
        {
            return new NonAnimatedSprite(rightClosedDoorSpritesheet);
        }

        public ISprite CreateUpLockedDoorSprite()
        {
            return new NonAnimatedSprite(upLockedDoorSpritesheet);
        }
        public ISprite CreateDownLockedDoorSprite()
        {
            return new NonAnimatedSprite(downLockedDoorSpritesheet);
        }

        public ISprite CreateLeftLockedDoorSprite()
        {
            return new NonAnimatedSprite(leftLockedDoorSpritesheet);
        }

        public ISprite CreateRightLockedDoorSprite()
        {
            return new NonAnimatedSprite(rightLockedDoorSpritesheet);
        }


    }
}
