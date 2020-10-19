using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
    public class LinkProjectileCollision
    {
        public static void HandleCollision(IPlayer link, IProjectile projectile)
        {

            projectile.CollidedWithLink(link);

        }
    }
}
