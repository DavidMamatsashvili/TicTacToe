using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.SinglePlayerFolder;
using TicTacToe.GameStateFolder;
using System.Security.Cryptography.X509Certificates;
using TicTacToe.Configuration;

namespace TicTacToe.MenuFolder
{
    public class SinglePlayerButton
    {
        public readonly string? Text = "Single Player";
        public Rectangle SignlePlayerButtonForm;
        public GameState state = GameState.Menu;

        private GameManager gameManager;

        public SinglePlayerButton(GameManager manager)
        {
            gameManager = manager;
            SignlePlayerButtonForm = new Rectangle(UIConfig.ButtonX,UIConfig.ButtonY,UIConfig.ButtonWidth,UIConfig.ButtonHeight);
        }

        public void DrawButton()
        {
            bool isHover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), SignlePlayerButtonForm);
            Color currentColor = isHover ? UIConfig.ButtonHoverColor : UIConfig.ButtonColor;
            Raylib.DrawRectangleRounded(SignlePlayerButtonForm, 0.2f, 10, currentColor);

            int textWidth = Raylib.MeasureText(Text, UIConfig.ButtonFontSize);
            int textX = (int)(SignlePlayerButtonForm.X + SignlePlayerButtonForm.Width / 2 - textWidth / 2);
            int textY = (int)(SignlePlayerButtonForm.Y + SignlePlayerButtonForm.Height / 2 - UIConfig.ButtonFontSize / 2);
            Raylib.DrawText(Text, textX, textY, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);

            CheckIfButtonIsClicked();
        }

        public void CheckIfButtonIsClicked()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), SignlePlayerButtonForm) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                gameManager.CurrentState = GameState.Playing;
                Console.WriteLine(gameManager.CurrentState);
            }
        }
    }
}
