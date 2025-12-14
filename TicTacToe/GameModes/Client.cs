using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.Configuration;
using TicTacToe.GameStateFolder;
using static System.Net.Mime.MediaTypeNames;

namespace TicTacToe.SinglePlayerFolder
{
    public class Client
    {
        public int cellSize = UIConfig.CellSize;
        public const int gridSize = 3;

        public readonly Color GridColor = UIConfig.GridColor;
        public BackToMainMenuButton BackToMainMenuButton;
        public GameManager GameManager;

        public int screenWidth = UIConfig.WindowWidth;
        public int screenHeight = UIConfig.WindowHeight;

        public int gridWidth => gridSize * cellSize;
        public int gridHeight => gridSize * cellSize;

        public string Text = "Join Game";
        public string IPAddress = "127.0.0.1";
        public string Port = "5000";

        public Rectangle ConnectButton;


        public Client(BackToMainMenuButton button, GameManager manager)
        {
            BackToMainMenuButton = button;
            GameManager = manager;

            Rectangle Rec = new Rectangle(UIConfig.ButtonX, UIConfig.ButtonY, UIConfig.ButtonWidth, UIConfig.ButtonHeight);
            int textWidth = Raylib.MeasureText(Text, UIConfig.ButtonFontSize);
            int textX = (int)(Rec.X + Rec.Width / 2 - textWidth / 2);
            int textY = (int)(Rec.Y + Rec.Height / 2 - UIConfig.ButtonFontSize / 2);

            Rectangle connectBtn = new Rectangle(textX - 50, textY + 120, UIConfig.ButtonWidth - 60, UIConfig.ButtonHeight);
            ConnectButton = connectBtn;
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
        }

        public void DrawConnectButton()
        {
            Raylib.DrawRectangleRounded(ConnectButton, 0.3f, 10, Color.Blue);
            Raylib.DrawTextEx(UIConfig.GameFont, "Connect", new Vector2(ConnectButton.X + 70, ConnectButton.Y + 20), UIConfig.ButtonFontSize, 1, Color.Gold);
            CheckButtonStatus(ConnectButton);
        }

        public void CheckIfButtonIsClicked(Rectangle button)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button) && Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                GameManager.CurrentState = GameState.HostAfterJoining;
                Console.WriteLine(GameState.HostAfterJoining);
            }
        }

        public void CheckButtonStatus(Rectangle button)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button))
            {
                Raylib.DrawRectangleRounded(button, 0.3f, 10, Color.Gold);
                Raylib.DrawTextEx(UIConfig.GameFont, "Connect", new Vector2(button.X + 70, button.Y + 20), UIConfig.ButtonFontSize, 1, Color.Blue);
            }
        }

        public void UpdateGame(GameManager manager, BackToMainMenuButton btn)
        {
            if (manager.CurrentState == GameState.HostBeforeJoining)
            {
                DrawGameBeforeJoining();
                btn.DrawButton();
                DrawConnectButton();
                CheckIfButtonIsClicked(ConnectButton);
            }
        }
    }
}


