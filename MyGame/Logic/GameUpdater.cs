using System;
using MyGame.engine.structs;
using MyGame.resources;

namespace MyGame.Logic {
    public static class GameUpdater {
        private static Random random = new Random();

        public static void Update(float deltaTime) {
            int screenWidth = Engine.GetScreenWidth();
            int screenHeight = Engine.GetScreenHeight();

            // Actualizo la posicion del jugador basada en deltaTime y velocidad
            InputHandler.Player.Position.X += InputHandler.Player.Movement.X * InputHandler.Player.Speed * deltaTime;
            InputHandler.Player.Position.Y += InputHandler.Player.Movement.Y * InputHandler.Player.Speed * deltaTime;

            // Limito la posicion del jugador dentro de los limites de la pantalla
            if (InputHandler.Player.Position.X < 0) {
                InputHandler.Player.Position.X = 0;
            } else if (InputHandler.Player.Position.X > screenWidth - InputHandler.Player.Width) {
                InputHandler.Player.Position.X = screenWidth - InputHandler.Player.Width;
            }

            if (InputHandler.Player.Position.Y < 0) {
                InputHandler.Player.Position.Y = 0;
            } else if (InputHandler.Player.Position.Y > screenHeight - InputHandler.Player.Height) {
                InputHandler.Player.Position.Y = screenHeight - InputHandler.Player.Height;
            }
            
            if (InputHandler.Player.Bullets != null) {
                // Actualizo la posicion de las balas del jugador
                for (int i = InputHandler.Player.Bullets.Count - 1; i >= 0; i--) {
                    var bullet = InputHandler.Player.Bullets[i];
                    bullet.UpdatePosition(deltaTime);

                    // Elimino la bala si sale de la pantalla
                    if (bullet.Position.Y < 0) {
                        InputHandler.Player.Bullets.RemoveAt(i);
                    } else {
                        // Actualizo la bala en la lista
                        InputHandler.Player.Bullets[i] = bullet;
                    }
                }
            }

            // Actualizo la posicion de los enemigos y sus disparos
            for (int i = 0; i < InputHandler.Enemies.Count; i++) {
                var enemy = InputHandler.Enemies[i];

                // Primero se mueven hacia abajo hasta StopPosition, luego disparan
                if (!enemy.HasStopped) {
                    enemy.Position.Y += enemy.Speed * deltaTime;
                    
                    // Limito la posicion del enemigo dentro de los limites de la pantalla
                    enemy.Position.X = Math.Clamp(enemy.Position.X, 0, screenWidth - enemy.Width);
                    enemy.Position.Y = Math.Clamp(enemy.Position.Y, 0, screenHeight - enemy.Height);

                    // Limito la posicion del enemigo a su StopPosition
                    if (enemy.Position.Y >= enemy.StopPosition) {
                        enemy.Position.Y = enemy.StopPosition;
                        enemy.HasStopped = true;
                    }
                } else {
                    // Disparo de los enemigos
                    if (random.NextDouble() < 0.01) {
                        enemy.Bullets.Add(new Bullet {
                            Position = new Coordenadas { X = enemy.Position.X + (enemy.Width + 27), Y = enemy.Position.Y + (enemy.Height + 50) },
                            Speed = 300
                        });
                    }

                    // Actualizo la posicion de las balas
                    for (int j = enemy.Bullets.Count - 1; j >= 0; j--) {
                        var bullet = enemy.Bullets[j];
                        bullet.UpdatePosition(deltaTime);

                        // Elimino la bala si sale de la pantalla
                        if (bullet.Position.Y > screenHeight) {
                            enemy.Bullets.RemoveAt(j);
                        } else {
                            // Actualizo la bala en la lista
                            enemy.Bullets[j] = bullet;
                        }
                    }
                }

                // Actualizo el enemigo en la lista
                InputHandler.Enemies[i] = enemy;
            }
            
            // Colisiones entre las balas del enemigo y el jugador
            foreach (var enemy in InputHandler.Enemies) {
                for (var i = enemy.Bullets.Count - 1; i >= 0; i--) {
                    var bullet = enemy.Bullets[i];
                    var playerRect = new CollisionArea(InputHandler.Player.Position.X, InputHandler.Player.Position.Y, InputHandler.Player.Width, InputHandler.Player.Height);
                    var bulletRect = new CollisionArea(bullet.Position.X, bullet.Position.Y, 10, 10);

                    if (IsCollision(bulletRect, playerRect)) {
                        enemy.Bullets.RemoveAt(i);
                        Program.PlayerHealth -= 5;
                        Sounds.EffectExplosion.Play();
                    }
                }
            }

            if (InputHandler.Player.Bullets != null) {
                // Colisiones entre las balas del jugador y los enemigos
                for (var i = InputHandler.Player.Bullets.Count - 1; i >= 0; i--) {
                    var bullet = InputHandler.Player.Bullets[i];
                    var bulletRect = new CollisionArea(bullet.Position.X, bullet.Position.Y, 10, 13);
                    bool bulletHit = false;

                    for (var j = InputHandler.Enemies.Count - 1; j >= 0; j--) {
                        var enemy = InputHandler.Enemies[j];
                        if (enemy.Width == 0) enemy.Width = 64;
                        if (enemy.Height == 0) enemy.Height = 64;

                        var enemyRect = new CollisionArea(enemy.Position.X, enemy.Position.Y, enemy.Width, enemy.Height);

                        if (IsCollision(bulletRect, enemyRect)) {
                            Sounds.EffectExplosion.Play();
                            InputHandler.Player.Bullets.RemoveAt(i);
                            InputHandler.Enemies.RemoveAt(j);
                            InputHandler.InitializeEnemies(1);
                            Program.PlayerScore += 10;

                            bulletHit = true;
                            break;
                        }
                    }

                    // Si impacta no sigo verificando
                    if (bulletHit) {
                        break;
                    }
                }
            }

        }
        
        // Detecta colisiones
        private static bool IsCollision(CollisionArea rect1, CollisionArea rect2) {
            return rect1.X < rect2.X + rect2.Width &&
                   rect1.X + rect1.Width > rect2.X &&
                   rect1.Y < rect2.Y + rect2.Height &&
                   rect1.Y + rect1.Height > rect2.Y;
        }
    }
}