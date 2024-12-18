namespace MyGame.engine.structs {
    public struct CollisionArea {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public CollisionArea(float x, float y, float width, float height) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}