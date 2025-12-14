using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TicTacToe.Configuration;
using TicTacToe.GameStateFolder;
using TicTacToe.MenuFolder;

namespace TicTacToe.SinglePlayerFolder
{
    public class BackToMainMenuButton
    {
        public GameState state = GameState.Playing;
        public Rectangle BackToMainMenuButtonForm;
        public readonly string Text = "Menu";
        public Color ButtonColor = UIConfig.ButtonColor;

        public GameManager Manager;

        public BackToMainMenuButton(GameManager manager)
        {
            Manager = manager;
            BackToMainMenuButtonForm = new Rectangle(
                UIConfig.ButtonX - 250,
                UIConfig.ButtonY - 200,
                UIConfig.ButtonWidth-200,
                UIConfig.ButtonHeight-20
            );
        }

        public void CheckIfButtonIsClicked(Rectangle button)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button) && Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Manager.CurrentState = GameState.Menu;
            }
        }

        public void CheckButtonStatus(Rectangle button)
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), button))
            {
                Raylib.DrawRectangleRounded(button, 0.3f, 10, ButtonColor);
                Raylib.DrawTextEx(UIConfig.GameFont,Text,new Vector2(button.X + 18, button.Y + 14),UIConfig.ButtonFontSize,1,Color.Gold);
            }
        }

        public void DrawButton()
        {
            Raylib.DrawRectangleRounded(BackToMainMenuButtonForm, 0.3f, 10, Color.Gold);

            Raylib.DrawTextEx(UIConfig.GameFont,Text,new Vector2(BackToMainMenuButtonForm.X + 18, BackToMainMenuButtonForm.Y + 14),UIConfig.ButtonFontSize,1,Color.Blue);
            CheckButtonStatus(BackToMainMenuButtonForm);
            CheckIfButtonIsClicked(BackToMainMenuButtonForm);
        }
    }
}
