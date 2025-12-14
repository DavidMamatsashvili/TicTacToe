using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.GameStateFolder;
using TicTacToe.SinglePlayerFolder;
using Raylib_cs;
using TicTacToe.Configuration;

namespace TicTacToe.MenuFolder
{
    public class Menu
    {
        public readonly string? Title = "TicTacToe";
        public readonly GameState state = GameState.Menu;
        private SinglePlayerButton singlePlayerButton;
        private HostButton hostButton;
        private JoinButton joinButton;
        private GameManager gameManager;

        public Menu(SinglePlayerButton btn, HostButton hostbtn, JoinButton joinbtn, GameManager manager)
        {
            singlePlayerButton = btn;
            hostButton = hostbtn;
            joinButton = joinbtn;
            gameManager = manager;
        }

        public void DrawMenu()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(UIConfig.BackgroundColor);

            Raylib.DrawText(Title, UIConfig.TitleX, UIConfig.TitleY, UIConfig.TitleFontSize, UIConfig.TitleColor);

            singlePlayerButton.DrawButton();

            hostButton.DrawButton();

            joinButton.DrawButton();

            Raylib.EndDrawing();
        }
    }
}
