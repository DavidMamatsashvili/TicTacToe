using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.MenuFolder;
using TicTacToe.GameStateFolder;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using TicTacToe.Configuration;

namespace TicTacToe.SinglePlayerFolder
{
    public class SinglePlayer
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

        public int offsetX => (screenWidth - gridWidth) / 2;
        public int offsetY => (screenHeight - gridHeight) / 2 - 70;

        public string Player { get; set; } = "X";
        public bool IsRunning = true;

        public string[,] Cells = new string[3, 3]
        {
            { "", "", "" },
            { "", "", "" },
            { "", "", "" }
        };

        public SinglePlayer(BackToMainMenuButton button, GameManager manager)
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

        public void DrawGrid()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    int x = offsetX + col * cellSize;
                    int y = offsetY + row * cellSize;

                    Raylib.DrawRectangleLinesEx(new Rectangle(x, y, cellSize, cellSize), 3, GridColor);

                    if (Cells[row, col] == "X")
                    {
                        DrawX(row, col);
                    }   
                    else if (Cells[row, col] == "O")
                    {
                        DrawO(row, col);
                    }
                }
            }

            DisplayGameStatus(Player);
        }

        public void ProccessInput()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    int x = offsetX + col * cellSize;
                    int y = offsetY + row * cellSize;

                    Rectangle cell = new Rectangle(x, y, cellSize, cellSize);
                    UpdateCells(cell, row, col);
                }
            }
        }

        public void DisplayGameStatus(string player)
        {
            int emptyCells = 0;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (Cells[i, j] == "")
                    {
                        emptyCells++;
                    }
                }
            }
                

            string winner = CheckWinner(Cells);
            int textX = offsetX + 162;
            int textY = offsetY + gridHeight + 40;

            if (winner == null && emptyCells == 0)
            {
                Raylib.DrawTextEx(UIConfig.GameFont, "Draw!", new Vector2(textX, textY), UIConfig.GameFontSize, 1, UIConfig.TitleColor);
                DisplayRestartButton();
                IsRunning = false;
            }
            else if (winner == null)
            {
                Raylib.DrawTextEx(UIConfig.GameFont, $"{Player}'s Turn", new Vector2(textX, textY), UIConfig.GameFontSize, 1, UIConfig.TitleColor);
            }
            else
            {
                Raylib.DrawTextEx(UIConfig.GameFont, $"{winner} Wins!", new Vector2(textX, textY), UIConfig.GameFontSize, 1, UIConfig.TitleColor);
                DisplayRestartButton();
                IsRunning = false;
            }
        }

       
        public void DisplayRestartButton()
        {
            Rectangle button = new Rectangle(offsetX+100, offsetY+gridHeight+100, UIConfig.ButtonWidth-90, UIConfig.ButtonHeight-10);
            Raylib.DrawRectangleRounded(button, 0.3f, 10, UIConfig.ButtonColor);
      
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button))
            {
                Raylib.DrawRectangleRounded(button, 0.3f, 10, UIConfig.ButtonHoverColor);
            }

            Raylib.DrawTextEx(UIConfig.GameFont, "Restart", new Vector2(button.X + 60, button.Y + 15), UIConfig.ButtonFontSize, 1, UIConfig.ButtonTextColor);

            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                IsRunning = true;
                Player = "X";
                Cells = new string[3, 3] 
                { 
                    { "", "", "" }, 
                    { "", "", "" }, 
                    { "", "", "" } 
                };
            }
        }


        public void UpdateCells(Rectangle cell, int row, int col)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), cell) && Cells[row, col] == "")
            {
                if (Raylib.IsMouseButtonPressed(MouseButton.Left))
                {
                    Cells[row, col] = Player;
                    Player = Player == "X" ? "O" : "X";
                }
            }
        }

        public string CheckWinner(string[,] board)
        {
            string? res = null;

            for (int i = 0; i < 3; i++)
            {
                string first = board[i, 0];
                string second = board[i, 1];
                string third = board[i, 2];
                if (first == second && second == third && first != "")
                {
                    return first;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                string first = board[0, i];
                string second = board[1, i];
                string third = board[2, i];
                if (first == second && second == third && first != "")
                {
                    return first;
                }
            }

            bool diag1 = true;
            bool diag2 = true;
            string element = board[1, 1];

            for (int i = 0, j = 0; i < 3 && j < 3; i++, j++)
            {
                if (board[i, j] == "" || board[i, j] != element)
                {
                    diag1 = false;
                }
            }
                
            for (int i = 2, j = 0; i >= 0 && j < 3; i--, j++)
            {
                if (board[i, j] == "" || board[i, j] != element) diag2 = false;
            }

            if (diag1 || diag2)
            {
                return element;
            }

            return res;
        }

        public void UpdateGame(GameManager manager, BackToMainMenuButton btn)
        {
            Raylib.ClearBackground(UIConfig.BackgroundColor);

            if (manager.CurrentState == btn.state && IsRunning)
            {
                ProccessInput();
                DrawGrid();
                btn.DrawButton();
            }
            else if (manager.CurrentState == btn.state && !IsRunning)
            {
                DrawGrid();
                DisplayRestartButton();
                btn.DrawButton();
            }
        }

        public void DrawX(int row, int col)
        {
            int padding = cellSize / 6; 
            int x = offsetX + col * cellSize;
            int y = offsetY + row * cellSize;

            Raylib.DrawLineEx(new Vector2(x + padding, y + padding), new Vector2(x + cellSize - padding, y + cellSize - padding), 6, UIConfig.XColor);
            Raylib.DrawLineEx(new Vector2(x + padding, y + cellSize - padding), new Vector2(x + cellSize - padding, y + padding), 6, UIConfig.XColor);
        }

        public void DrawO(int row, int col)
        {
            int x = offsetX + col * cellSize;
            int y = offsetY + row * cellSize;
            int centerX = x + cellSize / 2;
            int centerY = y + cellSize / 2;
            int radius = cellSize / 2 - (cellSize / 6);

            Raylib.DrawCircleLines(centerX, centerY, radius, UIConfig.OColor);
        }
    }
}
