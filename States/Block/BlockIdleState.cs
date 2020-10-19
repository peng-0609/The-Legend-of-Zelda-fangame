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
    public class BlockIdleState : IBlockState
    {
        private ISprite blockSprite;
        private IBlock block;
        public int Width { get; set; }
        public int Height { get; set; }


        public BlockIdleState(IBlock block)
        {
            this.block = block;
            blockSprite = ArtifactSpriteFactory.Instance.CreateMovableBlockSprite();
            this.Width = blockSprite.Width;
            this.Height = blockSprite.Height;
        }
        public void Move()
        {
            if (block.IsMovable)
            {
                block.State = new BlockMoveState(block);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, block.Position);
        }

        public void Update()
        {
            blockSprite.Update();
        }
    }
}
