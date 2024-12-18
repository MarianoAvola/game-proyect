using MyGame.resources;

namespace MyGame.Logic {
    public static class Renderer {
        public static void Render() {
            Engine.Clear();
            Engine.Draw(Images.Background, 0, 0);
            Engine.Draw(Images.Player, InputHandler.Player.Position.X, InputHandler.Player.Position.Y);
            
            // Dibujo los enemigos y sus balas
            foreach (var enemy in InputHandler.Enemies) {
                Engine.Draw(Images.Enemy, enemy.Position.X, enemy.Position.Y);

                foreach (var bullet in enemy.Bullets) {
                    Engine.Draw(Images.BulletEnemy, bullet.Position.X, bullet.Position.Y);
                }
            }
            
            // Dibujo las balas del jugador
            if (InputHandler.Player.Bullets != null && InputHandler.Player.Bullets.Count > 0) {
                foreach (var bullet in InputHandler.Player.Bullets) {
                    Engine.Draw(Images.BulletPlayer, bullet.Position.X, bullet.Position.Y);
                }
            }
            
            // Vida del jugador y el puntaje
            int screenWidth = Engine.GetScreenWidth();
            Engine.DrawText($"Vida: {Program.PlayerHealth}", screenWidth - 1000, 10, 255, 255, 255, Fonts.SmallFont);
            Engine.DrawText($"Puntaje: {Program.PlayerScore}", screenWidth - 1000, 40, 255, 255, 255, Fonts.SmallFont);

            
            Engine.Show();
        }
    }
}