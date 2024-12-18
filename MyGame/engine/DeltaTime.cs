using System;

namespace MyGame.entity {
    public static class DeltaTime {
        private static DateTime startTime = DateTime.Now;
        private static float lastTimeFrame = 0;

        public static float GetDeltaTime() {
            float currentTime = (float)(DateTime.Now - startTime).TotalSeconds;
            float deltaTime = currentTime - lastTimeFrame;
            lastTimeFrame = currentTime;
            return deltaTime;
        }
    }
}