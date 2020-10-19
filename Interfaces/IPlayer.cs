using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IPlayer
    {
        ILinkState State { get; set; }
        LinkPhysicalProperty linkphysicalProperty { get; set; }
        LinkInventoryProperty Inventory { get; set; }
        Vector2 Position { get; set; }
        bool IsAttacking { get; set; }
        bool OneHpMode { get; set; }
        void SetPos(Vector2 pos);
        void TakeDamage();
        void Die();
        void FaceUp();
        void FaceDown();
        void FaceLeft();
        void FaceRight();
        void Run();
        void Attack();
        void PickUpItem(String itemName);
        void UseBomb();
        void UseBoomerang();
        void Shoot();
        Rectangle GetRectangle();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
