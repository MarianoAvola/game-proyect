namespace MyGame.resources {
    public static class Sounds {
        public static Sound BackgroundMusic { get; private set; }
        public static Sound EffectDamage { get; private set; }
        public static Sound EffectExplosion { get; private set; }
        public static Sound EffectShot { get; private set; }

        static Sounds() {
            BackgroundMusic = new Sound("../../../assets/snd/background.mp3");
            EffectDamage = new Sound("../../../assets/snd/damage-recived.wav");
            EffectExplosion = new Sound("../../../assets/snd/explosion.wav");
            EffectShot = new Sound("../../../assets/snd/shot.wav");
        }
    }
}