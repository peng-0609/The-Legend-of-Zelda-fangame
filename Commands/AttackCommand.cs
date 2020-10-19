using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    class AttackCommand : ICommand
    {
        private GameStateManager stateManager;
        public AttackCommand(GameStateManager gameStateManager)
        {
            this.stateManager = gameStateManager;
        }
        public void Execute()
        {
            stateManager.Attack();
        }

    }
}
