using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    public class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyCommand;
        private Keys[] previousKeys;
        private Game1 game;
        private GameStateManager stateManager;
        private Queue<char> buffer;
        public KeyboardController(Game1 gameClass)
        {
            game = gameClass;
            stateManager = game.gameStateManager;
            previousKeys = new Keys[0];

            keyCommand = new Dictionary<Keys, ICommand>();

            buffer = new Queue<char>();

        }
        public void RegisterCommand()
        {
            keyCommand.Add(Keys.W, new MoveUpCommand(stateManager));
            keyCommand.Add(Keys.Up, new MoveUpCommand(stateManager));
            keyCommand.Add(Keys.A, new MoveLeftCommand(stateManager));
            keyCommand.Add(Keys.Left, new MoveLeftCommand(stateManager));
            keyCommand.Add(Keys.S, new MoveDownCommand(stateManager));
            keyCommand.Add(Keys.Down, new MoveDownCommand(stateManager));
            keyCommand.Add(Keys.D, new MoveRightCommand(stateManager));
            keyCommand.Add(Keys.Right, new MoveRightCommand(stateManager));
            keyCommand.Add(Keys.D1, new UseItemCommand(stateManager));
            keyCommand.Add(Keys.Q, new ResumeCommand(stateManager));
            keyCommand.Add(Keys.D2, new AttackCommand(stateManager));
            keyCommand.Add(Keys.M, new UseMapCommand(stateManager));
            keyCommand.Add(Keys.I, new ItemHUDCommand(stateManager));
            keyCommand.Add(Keys.Enter, new ActionCommand(stateManager));
        }

        public void Update(Game1 game)
        {
            Keys[] currentKeys = Keyboard.GetState().GetPressedKeys();
            KeyboardState currentKeyState = Keyboard.GetState();

            /* Handle cheat codes */
            if (currentKeys.Length > 0)
            {
                buffer.Enqueue(currentKeys[0].ToString().ElementAt(0));
                if (buffer.Count() > 2)
                {
                    buffer.Dequeue();
                }
                /* cheat code to maximize bomb count */
                if (buffer.ElementAt(0).Equals('M') && buffer.ElementAt(1).Equals('B'))
                {
                    game.Link.Inventory.BombCount = 99;
                }
                /* cheat code to maximize rupee count */
                if (buffer.ElementAt(0).Equals('M') && buffer.ElementAt(1).Equals('R'))
                {
                    game.Link.Inventory.RupeeCount = 99;
                }
                /* cheat code to maximize key count */
                if (buffer.ElementAt(0).Equals('M') && buffer.ElementAt(1).Equals('K'))
                {
                    game.Link.Inventory.KeyCount = 99;
                }
                /* cheat code to maximize link's health */
                if (buffer.ElementAt(0).Equals('M') && buffer.ElementAt(1).Equals('H'))
                {
                    game.Link.Inventory.Health = game.Link.Inventory.MaxHealth;
                }
            }

            foreach (Keys key in currentKeys)
            {
                if (keyCommand.ContainsKey(key) && !previousKeys.Contains(key))
                {
                    keyCommand[key].Execute();
                }
            }
            previousKeys = currentKeys;

            if (!game.Link.IsAttacking)
            {
                ReturnToIdle(game, currentKeyState);
            }

        }



        public void ReturnToIdle(Game1 game, KeyboardState currentKeyState)
        {
            if (currentKeyState.IsKeyUp(Keys.W) && currentKeyState.IsKeyUp(Keys.A) && currentKeyState.IsKeyUp(Keys.S) && currentKeyState.IsKeyUp(Keys.D) &&
                currentKeyState.IsKeyUp(Keys.Down) && currentKeyState.IsKeyUp(Keys.Left) && currentKeyState.IsKeyUp(Keys.Up) && currentKeyState.IsKeyUp(Keys.Right) &&
                currentKeyState.IsKeyUp(Keys.D1) && currentKeyState.IsKeyUp(Keys.D2))
            {
                new ReturnToIdleCommand(game.Link).Execute();
            }
        }
    }
}
