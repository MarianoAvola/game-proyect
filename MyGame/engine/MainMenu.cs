using MyGame.resources;

namespace MyGame.engine {
    public static class MainMenu {
        public static void Render() {
            Engine.Clear();
            Engine.Draw(Images.Background, 0, 0);
            int screenWidth = Engine.GetScreenWidth();
            int screenHeight = Engine.GetScreenHeight();
            int buttonWidth = 300;
            int buttonHeight = 50;
            int startX = (screenWidth - buttonWidth) / 2;
            int startY = (screenHeight - (2 * buttonHeight + 50)) / 2;
            Engine.DrawText("INICIAR PARTIDA", startX, startY, 255, 255, 255, Fonts.DefaultFont);
            Engine.DrawText("SALIR DEL JUEGO", startX, startY + buttonHeight + 50, 255, 255, 255, Fonts.DefaultFont);
            Engine.Show();
        }

        public static void HandleInput() {
            int mouseX, mouseY;
            int screenWidth = Engine.GetScreenWidth();
            int screenHeight = Engine.GetScreenHeight();
            int buttonWidth = 300;
            int buttonHeight = 50;
            int startX = (screenWidth - buttonWidth) / 2;
            int startY = (screenHeight - (2 * buttonHeight + 50)) / 2;
            if (Engine.MouseClick(Engine.MOUSE_LEFT, out mouseX, out mouseY)) {
                if (mouseX >= startX && mouseX <= startX + buttonWidth) {
                    if (mouseY >= startY && mouseY <= startY + buttonHeight) {
                        Program.StartGame();
                    } else if (mouseY >= startY + buttonHeight + 50 && mouseY <= startY + 2 * buttonHeight + 50) {
                        Program.ExitGame();
                    }
                }
            }
        }
    }
}