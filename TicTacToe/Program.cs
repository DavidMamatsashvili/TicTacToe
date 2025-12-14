using Raylib_cs;
using TicTacToe.Configuration;
using TicTacToe.GameStateFolder;
using TicTacToe.MenuFolder;
using TicTacToe.SinglePlayerFolder;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(UIConfig.WindowWidth, UIConfig.WindowHeight, UIConfig.WindowTitle);
        Raylib.SetTargetFPS(60);

        GameManager manager = new GameManager();

        SinglePlayerButton singlePlayerButton = new SinglePlayerButton(manager);
        HostButton hostButton = new HostButton(manager);
        JoinButton joinButton = new JoinButton(manager);
        Menu menu = new Menu(singlePlayerButton, hostButton, joinButton, manager);

        BackToMainMenuButton back = new BackToMainMenuButton(manager);
        SinglePlayer single = new SinglePlayer(back, manager);

        Client client = new Client(back, manager);
        Server server = new Server(back, manager);

        while (!Raylib.WindowShouldClose())
        {
            switch (manager.CurrentState)
            {
                case GameState.Menu:
                    menu.DrawMenu();
                    break;

                case GameState.Playing:
                    single.DrawGame();
                    break;

                case GameState.HostBeforeJoining:
                    client.DrawGame();
                    break;

                case GameState.ServerListening:
                    server.DrawGame();
                    break;
            }
        }

        Raylib.CloseWindow();
    }
}

