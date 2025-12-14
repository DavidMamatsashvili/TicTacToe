using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.Configuration;
using TicTacToe.GameStateFolder;

namespace TicTacToe.MenuFolder
{
    public class JoinButton
    {
        public readonly string? Text = "Join";
        public Rectangle JoinButtonForm;
        public GameState state = GameState.Menu;

        private GameManager gameManager;

        public JoinButton(GameManager manager)
        {
            gameManager = manager;
            JoinButtonForm = new Rectangle(UIConfig.ButtonX, UIConfig.ButtonY+180, UIConfig.ButtonWidth, UIConfig.ButtonHeight);
        }

        public void DrawButton()
        {
            bool isHover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), JoinButtonForm);
            Color currentColor = isHover ? UIConfig.ButtonHoverColor : UIConfig.ButtonColor;
            Raylib.DrawRectangleRounded(JoinButtonForm, 0.2f, 10, currentColor);

            int textWidth = Raylib.MeasureText(Text, UIConfig.ButtonFontSize);
            int textX = (int)(JoinButtonForm.X + JoinButtonForm.Width / 2 - textWidth / 2);
            int textY = (int)(JoinButtonForm.Y + JoinButtonForm.Height / 2 - UIConfig.ButtonFontSize / 2);
            Raylib.DrawText(Text, textX, textY, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);

            CheckIfButtonIsClicked();
        }

        public void CheckIfButtonIsClicked()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), JoinButtonForm) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                gameManager.CurrentState = GameState.HostBeforeJoining;
                Console.WriteLine(gameManager.CurrentState);
            }
        }
    }
}
