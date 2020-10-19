using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class MoveDownCommand : ICommand
    {
        private GameStateManager stateManager;
        public MoveDownCommand(GameStateManager stateManagerClass)
        {
            this.stateManager = stateManagerClass;
        }
        public void Execute()
        {
            stateManager.Down();
        }

    }
}