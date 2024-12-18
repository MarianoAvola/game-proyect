namespace MyGame.resources {
    public static class Images {
        public static Image Background { get; private set; }
        public static Image BackgroundVictory { get; private set; }
        public static Image BackgroundDefeat { get; private set; }
        public static Image Player { get; private set; }
        public static Image Enemy { get; private set; }
        public static Image BulletEnemy { get; private set; }
        public static Image BulletPlayer { get; private set; }


        static Images() {
            Background = Engine.LoadImage("../../../assets/img/bg.png");
            BackgroundVictory = Engine.LoadImage("../../../assets/img/bg-victory.png");
            BackgroundDefeat = Engine.LoadImage("../../../assets/img/bg-defeat.png");
            
            Player = Engine.LoadImage("../../../assets/img/player.png");
            BulletPlayer = Engine.LoadImage("../../../assets/img/bullet-player.png");
            
            Enemy = Engine.LoadImage("../../../assets/img/enemy.png");
            BulletEnemy = Engine.LoadImage("../../../assets/img/bullet-enemy.png");
        }
    }
}