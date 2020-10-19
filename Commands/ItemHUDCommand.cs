using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class ItemHUDCommand : ICommand
    {
        private GameStateManager stateManager;
        public ItemHUDCommand(GameStateManager stateManagerClass)
        {
            this.stateManager = stateManagerClass;
        }
        public void Execute()
        {
            stateManager.Item();
        }

    }
}
