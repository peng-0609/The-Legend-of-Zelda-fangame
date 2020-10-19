using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MoveRightCommand : ICommand
    {
        private GameStateManager stateManager;
        public MoveRightCommand(GameStateManager stateManagerClass)
        {
            this.stateManager = stateManagerClass;
        }
        public void Execute()
        {
            stateManager.Right();
        }
    }
}