using System;
using System.IO;
using System.Media;
using MyGame.engine;
using MyGame.entity;
using MyGame.Logic;
using MyGame.resources;
using Tao.Sdl;

namespace MyGame {
    class Program {
        private static bool isPaused = false;
        private static bool isInMainMenu = true;
        private static bool isGameOver = false;
        private static bool isVictory = false;
        
        public static int PlayerHealth { get; set; } = 100;
        public static int PlayerScore { get; set; } = 0;
        
        static void Main(string[] args) {
            try {
                Log("Iniciando juego...");
                Engine.Initialize();
                InputHandler.InitializeEnemies(8);

                ShowMainMenu();

                while (true) {
                    if (isInMainMenu) {
                        MainMenu.Render();
                        MainMenu.HandleInput();
                    } else if (isPaused) {
                        PauseMenu.Render();
                        PauseMenu.HandleInput();
                    } else if (isGameOver) {
                        DefeatScreen.Render();
                        DefeatScreen.HandleInput();
                    } else if (isVictory) {
                        VictoryScreen.Render();
                        VictoryScreen.HandleInput();
                    } else {
                        float deltaTime = DeltaTime.GetDeltaTime();
                        InputHandler.CheckInputs();
                        GameUpdater.Update(deltaTime);
                        Renderer.Render();
                        CheckVictoryCondition();
                        CheckDefeatCondition();
                        Sdl.SDL_Delay(20);
                    }
                }
            } catch (Exception e) {
                Log($"Ocurrio un error inesperado: {e.Message}\n{e.StackTrace}");
                throw;
            }
        }
        
        public static void StartGame() {
            isInMainMenu = false;
            isPaused = false;
            isGameOver = false;
            isVictory = false;
            PlayerHealth = 100;
            PlayerScore = 0;
            Sounds.BackgroundMusic.Stop();
        }

        public static void ShowMainMenu() {
            isInMainMenu = true;
            isPaused = false;
            isGameOver = false;
            isVictory = false;
            Sounds.BackgroundMusic.Play();
        }

        public static void ResumeGame() {
            isPaused = false;
        }

        public static void TogglePause() {
            isPaused = !isPaused;
        }
        
        public static void ExitGame() {
            Log("Cerrando juego...");
            Environment.Exit(0);
        }
        
        
        // Condicion de victoria
        private static void CheckVictoryCondition() {
            if (PlayerScore >= 200) {
                isVictory = true;
            }
        }

        // Condicion de derrota
        private static void CheckDefeatCondition() {
            if (PlayerHealth <= 0) {
                isGameOver = true;
            }
        }
        
        private static void Log(string message) {
            // La ruta donde deja el log.txt es --> MyGame\MyGame\bin\Debug\net6.0
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_log.txt");
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
        }
    }
}