using System.Collections.Generic;

namespace MyGame.engine.structs {
    public struct Player {
        public Coordenadas Position;
        public Coordenadas Movement;
        public int Speed;
        public int Width;
        public int Height;
        public List<Bullet> Bullets;
    }
}