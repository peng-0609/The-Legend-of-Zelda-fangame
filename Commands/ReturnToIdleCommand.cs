using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class ReturnToIdleCommand : ICommand
    {
        private IPlayer link;
        public ReturnToIdleCommand(IPlayer linkClass)
        {
            this.link = linkClass;
        }
        public void Execute()
        {
            if (link.linkphysicalProperty.direction == Direction.DOWN)
            {
                link.FaceDown();
            }
            else if (link.linkphysicalProperty.direction == Direction.UP)
            {
                link.FaceUp();
            }
            else if (link.linkphysicalProperty.direction == Direction.LEFT)
            {
                link.FaceLeft();
            }
            else
            {
                link.FaceRight();
            }
        }

    }
}
