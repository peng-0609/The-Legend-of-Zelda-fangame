using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class UseItemCommand : ICommand
    {
        private GameStateManager stateManager;
        public UseItemCommand(GameStateManager gameStateManager)
        {
            this.stateManager = gameStateManager;
        }
        public void Execute()
        {
            stateManager.UseItem();
        }
    }
}