using Microsoft.Xna.Framework;

namespace MonoGameOneButtonGame
{
    public class Boulder 
    {
        public Vector2 boulderStartPosition;
        public Vector2 boulderCurrentPosition;
        public float boulderSpeed;
        public float boulderAcceleration;
        public Vector2 boulderDirection;
        public float boulderVelocity;
        public Rectangle boulderBoundingBox;

        public Boulder(Game game, Vector2 startPosition) 
        {
            boulderCurrentPosition = startPosition;
            boulderSpeed = 130;
            boulderDirection = new Vector2(0, 1);
            boulderBoundingBox = new Rectangle((int)boulderCurrentPosition.X, (int)boulderCurrentPosition.Y, 80, 800);
        }
    }
}
