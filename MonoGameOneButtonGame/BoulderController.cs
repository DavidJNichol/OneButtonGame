using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameOneButtonGame
{
    //: Component
    //UNCOMMENT THING IN BOULDER.DESIGN
    public partial class BoulderController : Microsoft.Xna.Framework.GameComponent
    {
        private Boulder boulderOne;
        private Boulder boulderTwo;
        private Boulder boulderThree;
        private Boulder boulderFour;
        private Boulder boulderFive;

        private Boulder[] boulderArray;

        public BoulderController(Game game) : base(game)
        {
            boulderArray = new Boulder[5];

            //Sets boulders and their location
            boulderOne = new Boulder(game, new Vector2(190, -550));
            boulderTwo = new Boulder(game, new Vector2(390, -550));
            boulderThree = new Boulder(game, new Vector2(590, -550));
            boulderFour = new Boulder(game, new Vector2(790, -550));
            boulderFive = new Boulder(game, new Vector2(990, -550));



            //Store boulders in array
            boulderArray[0] = boulderOne;
            boulderArray[1] = boulderTwo;
            boulderArray[2] = boulderThree;
            boulderArray[3] = boulderFour;
            boulderArray[4] = boulderFive;
        }

        public void MoveBoulders(float time)
        {
            for(int i = 0; i < boulderArray.Length; i++)
            {
                boulderArray[i].boulderAcceleration += .5f;

                boulderArray[i].boulderVelocity += boulderArray[i].boulderAcceleration * boulderArray[i].boulderVelocity * (time / 1000);
                boulderArray[i].boulderCurrentPosition += boulderArray[i].boulderDirection * boulderArray[i].boulderSpeed * (time / 1000);

                if (boulderArray[i].boulderCurrentPosition.Y > -147)
                {
                    boulderArray[i].boulderDirection = new Vector2(0, -1);
                }
                if (boulderArray[i].boulderCurrentPosition.Y < -550)
                {
                    boulderArray[i].boulderDirection = new Vector2(0, 1);
                }
            }         
        }

        public Boulder[] GetBoulderArray()
        {
            return boulderArray;
        }

        public void UpdateRectangleBoulder()
        {
            for(int i = 0; i < boulderArray.Length; i++)
            {
                boulderArray[i].boulderBoundingBox.X = (int)boulderArray[i].boulderCurrentPosition.X;
                boulderArray[i].boulderBoundingBox.Y = (int)boulderArray[i].boulderCurrentPosition.Y;
            }
        }

        public void DrawBoulders(SpriteBatch spriteBatch, Texture2D boulderTexture, SpriteEffects spriteEffects, Boulder[] boulderArray)
        {
            for(int i = 0; i < boulderArray.Length; i++)
            {
                spriteBatch.Draw(boulderTexture, boulderArray[i].boulderCurrentPosition, null, Color.White, 0, new Vector2(0, 0), 1, spriteEffects, 0);
            }            
        }

        public void UpdateBoulders(float time)
        {
            for (int i = 0; i < boulderArray.Length; i++)
            {
                MoveBoulders(time);
                UpdateRectangleBoulder();
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateBoulders((float)gameTime.ElapsedGameTime.TotalMilliseconds);


        }
    }
}

