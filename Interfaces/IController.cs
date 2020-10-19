using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public interface IController
    {
        void Update(Game1 game);
        void RegisterCommand();
        
    }
}
