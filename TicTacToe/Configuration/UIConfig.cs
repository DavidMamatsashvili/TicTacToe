using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace TicTacToe.Configuration
{
    public static class UIConfig
    {
        // --- Window ---
        public static int WindowWidth { get; } = 1024;
        public static int WindowHeight { get; } = 768;
        public static string WindowTitle { get; } = "Tic Tac Toe";

        // --- Background ---
        public static Color BackgroundColor { get; } = new Color(28, 28, 38, 255); 

        // --- Title ---
        public static int TitleFontSize { get; } = 60;
        public static Color TitleColor { get; } = new Color(255, 140, 0, 255); 
        public static int TitleX { get; } = WindowWidth / 2 - 180;
        public static int TitleY { get; } = 80;

        // --- Buttons ---
        public static int ButtonWidth { get; } = 300;
        public static int ButtonHeight { get; } = 70;
        public static int ButtonX { get; } = WindowWidth / 2 - ButtonWidth / 2;
        public static int ButtonY { get; } = 250;
        public static int ButtonRadius { get; } = 20; 
        public static Color ButtonColor { get; } = new Color(70, 130, 180, 255); 
        public static Color ButtonHoverColor { get; } = new Color(100, 149, 237, 255); 
        public static Color ButtonTextColor { get; } = Color.White;
        public static int ButtonFontSize { get; } = 26;
        public static float HoverLerpSpeed { get; } = 0.15f; 

        // --- Grid & Single Player ---
        public static int CellSize { get; } = 140; 
        public static Color GridColor { get; } = new Color(200, 200, 200, 255); 
        public static Color XColor { get; } = new Color(220, 50, 50, 255); 
        public static Color OColor { get; } = new Color(50, 150, 220, 255); 
        public static int GameFontSize { get; } = 24;

        // --- Font ---
        public static Font GameFont { get; } = Raylib.GetFontDefault();
    }

}
