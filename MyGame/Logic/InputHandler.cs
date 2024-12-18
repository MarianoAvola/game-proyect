using System;
using System.Collections.Generic;
using MyGame.engine.structs;
using MyGame.resources;

namespace MyGame.Logic {
    public static class InputHandler {
        public static Player Player = new Player {
            Position = new Coordenadas { X = 300, Y = 500 },
            Movement = new Coordenadas { X = 0, Y = 0 },
            Speed = 350,
            Width = 80,
            Height = 80
        };
        public static List<Enemy> Enemies = new List<Enemy>();
        
        private static bool espPressed = false;

        public static void CheckInputs() {
            // Reinicio la direccion de movimiento del jugador
            Player.Movement = new Coordenadas { X = 0, Y = 0 };

            // Me muevo hacia arriba
            if (Engine.KeyPress(Engine.KEY_W)) {
                Player.Movement.Y = -1;
            }

            // Me muevo hacia la izquierda
            if (Engine.KeyPress(Engine.KEY_A)) {
                Player.Movement.X = -1;
            }

            // Me muevo hacia abajo
            if (Engine.KeyPress(Engine.KEY_S)) {
                Player.Movement.Y = 1;
            }

            // Me muevo hacia la derecha
            if (Engine.KeyPress(Engine.KEY_D)) {
                Player.Movement.X = 1;
            }

            // Disparo con ESP
            if (Engine.KeyPress(Engine.KEY_ESP)) {
                if (!espPressed) {
                    PlayerShoot();
                    espPressed = true;
                }
            } else {
                espPressed = false;
            }

            // Pauso el juego con ESC
            if (Engine.KeyPress(Engine.KEY_ESC)) {
                Program.TogglePause();
            }
        }
        
        private static void PlayerShoot() {
            if (Player.Bullets == null) {
                Player.Bullets = new List<Bullet>();
            }
    
            Player.Bullets.Add(new Bullet {
                Position = new Coordenadas { X = Player.Position.X + (Player.Width - 52), Y = Player.Position.Y },
                Speed = -300
            });
            Sounds.EffectShot.Play();
        }
        
        public static void InitializeEnemies(int count) {
            int screenWidth = Engine.GetScreenWidth();
            int screenHeight = Engine.GetScreenHeight();
            Random random = new Random();

            for (int i = 0; i < count; i++) {
                Enemies.Add(new Enemy {
                    Position = new Coordenadas { X = random.Next(0, screenWidth), Y = 0 },
                    Speed = random.Next(50, 150),
                    Bullets = new List<Bullet>(),
                    HasStopped = false,
                    StopPosition = (float)random.NextDouble() * (screenHeight / 2),
                    Width = 64,
                    Height = 64
                });
            }
        }
    }
}