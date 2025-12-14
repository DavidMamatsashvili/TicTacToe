using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.Configuration;
using TicTacToe.GameStateFolder;

namespace TicTacToe.SinglePlayerFolder
{
    public class Server
    {
        public int cellSize = UIConfig.CellSize;
        public const int gridSize = 3;

        public BackToMainMenuButton BackToMainMenuButton;
        public GameManager GameManager;

        public int screenWidth = UIConfig.WindowWidth;
        public int screenHeight = UIConfig.WindowHeight;

        public int gridWidth => gridSize * cellSize;
        public int gridHeight => gridSize * cellSize;

        public string Text = "Host Game";
        public string IPAddress = "127.0.0.1";
        public string Port = "5000";


        public Server(BackToMainMenuButton button, GameManager manager)
        {
            BackToMainMenuButton = button;
            GameManager = manager;
        }

        public void DrawGame()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(UIConfig.BackgroundColor);
            UpdateGame(GameManager, BackToMainMenuButton);
            Raylib.EndDrawing();
        }

        public void DrawGameBeforeJoining()
        {
            Rectangle Rec = new Rectangle(UIConfig.ButtonX, UIConfig.ButtonY, UIConfig.ButtonWidth, UIConfig.ButtonHeight);

            int textWidth = Raylib.MeasureText(Text, UIConfig.ButtonFontSize);
            int textX = (int)(Rec.X + Rec.Width / 2 - textWidth / 2);
            int textY = (int)(Rec.Y + Rec.Height / 2 - UIConfig.ButtonFontSize / 2);
            Raylib.DrawText(Text, textX, textY - 100, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);

            Raylib.DrawText("Host: ", textX - 150, textY - 25, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);
            Raylib.DrawRectangleLines(textX - 60, textY - 30, 350, UIConfig.ButtonHeight - 33, UIConfig.ButtonTextColor);
            Raylib.DrawText(IPAddress, textX - 50, textY - 25, UIConfig.GameFontSize, UIConfig.ButtonTextColor);

            Raylib.DrawText("Port: ", textX - 150, textY + 50, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);
            Raylib.DrawRectangleLines(textX - 60, textY + 45, 350, UIConfig.ButtonHeight - 33, UIConfig.ButtonTextColor);
            Raylib.DrawText(Port, textX - 50, textY + 50, UIConfig.GameFontSize, UIConfig.ButtonTextColor);

            Raylib.DrawText("Waiting for player...", textX - 150, textY + 150, UIConfig.ButtonFontSize + 20, Color.Green);
        }

        public void UpdateGame(GameManager manager, BackToMainMenuButton btn)
        {
            if (manager.CurrentState == GameState.ServerListening)
            {
                DrawGameBeforeJoining();
                btn.DrawButton();
            }
        }
    }
}

