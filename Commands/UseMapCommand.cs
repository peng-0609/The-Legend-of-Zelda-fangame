using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2
{
    public class UseMapCommand : ICommand
    {
        private GameStateManager stateManager;
        public UseMapCommand(GameStateManager gameStateManager)
        {
            this.stateManager = gameStateManager;
        }
        public void Execute()
        {
            stateManager.UseMap();
        }
    }
}
