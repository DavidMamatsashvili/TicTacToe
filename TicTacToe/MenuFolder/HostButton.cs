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
    public class HostButton
    {
        public readonly string? Text = "Host";
        public Rectangle HostButtonForm;
        public GameState state = GameState.Menu;

        private GameManager gameManager;

        public HostButton(GameManager manager)
        {
            gameManager = manager;
            HostButtonForm = new Rectangle(UIConfig.ButtonX, UIConfig.ButtonY+90, UIConfig.ButtonWidth, UIConfig.ButtonHeight);
        }

        public void DrawButton()
        {
            bool isHover = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), HostButtonForm);
            Color currentColor = isHover ? UIConfig.ButtonHoverColor : UIConfig.ButtonColor;
            Raylib.DrawRectangleRounded(HostButtonForm, 0.2f, 10, currentColor);

            int textWidth = Raylib.MeasureText(Text, UIConfig.ButtonFontSize);
            int textX = (int)(HostButtonForm.X + HostButtonForm.Width / 2 - textWidth / 2);
            int textY = (int)(HostButtonForm.Y + HostButtonForm.Height / 2 - UIConfig.ButtonFontSize / 2);
            Raylib.DrawText(Text, textX, textY, UIConfig.ButtonFontSize, UIConfig.ButtonTextColor);

            CheckIfButtonIsClicked();
        }

        public void CheckIfButtonIsClicked()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), HostButtonForm) && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                gameManager.CurrentState = GameState.ServerListening;
            }
        }
    }
}
