namespace MyGame.engine.structs {
    public struct Bullet {
        public Coordenadas Position;
        public int Speed;
        
        public void UpdatePosition(float deltaTime) {
            Position.Y += Speed * deltaTime;
        }
    }
}