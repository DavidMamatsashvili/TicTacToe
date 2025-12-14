using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameStateFolder
{
    public class GameManager
    {
        public GameState CurrentState { get; set; } = GameState.Menu;

        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
        }
    }
}
