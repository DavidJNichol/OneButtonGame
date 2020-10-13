using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameOneButtonGame
{
    //: Component
    //UNCOMMENT THING IN BOULDER.DESIGN
    public partial class BoulderController
    {
        public Vector2 boulderStartPosition;
        public Vector2 boulderCurrentPosition;
        public float boulderSpeed;
        public float boulderAcceleration;
        public Vector2 boulderDirection;
        public float boulderVelocity;
        public Rectangle boulderBoundingBox;

        public BoulderController()
        {

        }

        public BoulderController(Vector2 startPosition)
        {
            InitializeComponent();
            boulderCurrentPosition = startPosition;
            boulderSpeed = 680;
            boulderDirection = new Vector2(0, 1);
            boulderBoundingBox = new Rectangle((int)boulderCurrentPosition.X, (int)boulderCurrentPosition.Y, 80, 800);
        }

        public void MoveBoulder(float time)
        {
            boulderAcceleration += .5f;

            boulderVelocity += boulderAcceleration * boulderVelocity * (time / 1000);
            boulderCurrentPosition += boulderDirection * boulderSpeed * (time / 1000);

            if (boulderCurrentPosition.Y > -147)
            {
                boulderDirection = new Vector2(0, -1);
            }
            if (boulderCurrentPosition.Y < -550)
            {
                boulderDirection = new Vector2(0, 1);
            }
        }

        public void UpdateRectangleBoulder()
        {
            boulderBoundingBox.X = (int)boulderCurrentPosition.X;
            boulderBoundingBox.Y = (int)boulderCurrentPosition.Y;
        }

        public void DrawBoulders(SpriteBatch spriteBatch, Texture2D boulderTexture, SpriteEffects spriteEffects, BoulderController[] boulderArray)
        {
            for(int i = 0; i < boulderArray.Length; i++)
            {
                spriteBatch.Draw(boulderTexture, boulderArray[i].boulderCurrentPosition, null, Color.White, 0, new Vector2(0, 0), 1, spriteEffects, 0);
            }            
        }

        public void UpdateBoulders(BoulderController[] boulderArray, float time)
        {
            for (int i = 0; i < boulderArray.Length; i++)
            {
                boulderArray[i].MoveBoulder(time);
                boulderArray[i].UpdateRectangleBoulder();
            }
        }
    }
}

