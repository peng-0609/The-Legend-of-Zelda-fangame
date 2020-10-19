using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MoveUpCommand : ICommand
    {
        private GameStateManager stateManager;
        public MoveUpCommand(GameStateManager stateManagerClass)
        {
            this.stateManager = stateManagerClass;
        }
        public void Execute()
        {
            stateManager.Up();
        }
    }
}