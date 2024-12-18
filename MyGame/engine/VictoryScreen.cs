using MyGame.resources;

namespace MyGame.engine {
    public static class VictoryScreen {
        public static void Render() {
            Engine.Clear();
            Engine.Draw(Images.BackgroundVictory, 0, 0);
            int screenWidth = Engine.GetScreenWidth();
            int screenHeight = Engine.GetScreenHeight();
            int textWidth = 300;

            Engine.DrawText("¡GANASTE!", (screenWidth - textWidth) / 2, screenHeight / 2 - 50, 255, 255, 255, Fonts.BigFont);
            Engine.DrawText("Volver al menu principal", 10, screenHeight - 50, 255, 255, 255, Fonts.DefaultFont);
            Engine.Show();
        }

        public static void HandleInput() {
            int mouseX, mouseY;
            bool click = Engine.MouseClick(Engine.MOUSE_LEFT, out mouseX, out mouseY);
            if (click && mouseX >= 10 && mouseX <= 310 &&
                mouseY >= Engine.GetScreenHeight() - 70 && mouseY <= Engine.GetScreenHeight() - 10) {
                Program.ShowMainMenu();
            }
        }
    }
}