using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameStateFolder
{
    public enum GameState
    {
        Menu,
        Playing,
        GameOver,
        HostBeforeJoining,
        HostAfterJoining,
        ServerListening
    }
}
