using System.Collections.Generic;

namespace MyGame.engine.structs {
    public struct Enemy {
        public Coordenadas Position;
        public int Speed;
        public List<Bullet> Bullets;
        public bool HasStopped;
        public float StopPosition;
        public int Height;
        public int Width;
    }
}