using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class BlockMoveState : IBlockState
    {
        private ISprite blockSprite;
        private IBlock block;
        private float posY;
        public int Width { get; set; }
        public int Height { get; set; }
        private int moveLength;


        public BlockMoveState(IBlock block)
        {
            this.block = block;
            blockSprite = ArtifactSpriteFactory.Instance.CreateMovableBlockSprite();
            this.Width = blockSprite.Width;
            this.Height = blockSprite.Height;
            moveLength = this.Height;
        }
        public void Move()
        {
            //Do nothing: is already in this state.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, block.Position);
        }

        public void Update()
        {
            posY = block.Position.Y + 1;
            moveLength--;
            if (moveLength >= 0)
            {
                block.Position = new Vector2(block.Position.X, posY);
            }
            else
            {
                block.IsMovable = false;
                block.State = new BlockIdleState(block);
            }
            
            blockSprite.Update();
        }
    }
}
