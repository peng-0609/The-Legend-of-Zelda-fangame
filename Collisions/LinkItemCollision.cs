using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkItemCollision
    {
        public static void HandleCollision(IPlayer link, IItem item)
        {

            item.CollidedWithLink(link);

        }
    }
}
