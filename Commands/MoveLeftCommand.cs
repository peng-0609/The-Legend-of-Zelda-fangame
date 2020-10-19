using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MoveLeftCommand : ICommand
    {
        private GameStateManager stateManager;
        public MoveLeftCommand(GameStateManager stateManagerClass)
        {
            this.stateManager = stateManagerClass;
        }
        public void Execute()
        {
            stateManager.Left();
        }
    }
}