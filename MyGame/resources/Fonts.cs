namespace MyGame.resources {
    public static class Fonts {
        public static Font DefaultFont { get; private set; }
        public static Font BigFont { get; private set; }
        public static Font SmallFont { get; private set; }

        static Fonts() {
            DefaultFont = new Font("../../../assets/fonts/default_font.ttf", 30);
            BigFont = new Font("../../../assets/fonts/default_font.ttf", 50);
            SmallFont = new Font("../../../assets/fonts/default_font.ttf", 15);
        } 
    }
}