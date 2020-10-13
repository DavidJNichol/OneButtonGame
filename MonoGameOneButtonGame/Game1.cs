using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameOneButtonGame
{
    public class Game1 : Game
    {
        //MUSIC CREDIT: https://www.youtube.com/watch?v=FPj8_9NjIHQ&ab_channel=StrangerSynths

        //BOULDER TEXTURE CREDIT: https://www.textures.com/system/gallery/photos/3D%20Scans/ps132397/132397_header.jpg
        //All other textures were made by me in MSPaint

        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        
        Gamemanager gameManager;

        BoulderController[] boulderArray;

        BoulderController boulderController;

        BoulderController boulderOne;
        BoulderController boulderTwo;
        BoulderController boulderThree;
        BoulderController boulderFour;
        BoulderController boulderFive;      

        PlayerController playerController;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);           
            
            gameManager = new Gamemanager();
            boulderController = new BoulderController();

            //Stores each individual boulder
            boulderArray = new BoulderController[5];

            // 1200x800 Window
            gameManager.SetContentRootDirectory(Content);
            gameManager.SetGraphicsWindow(graphics);
        }

        protected override void Initialize()
        {
            //PlayerController is a game component, so we put in in Initialize
            playerController = new PlayerController(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Sets boulders and their location
            boulderOne = new BoulderController(new Vector2(190, -550));
            boulderTwo = new BoulderController(new Vector2(390, -550));
            boulderThree = new BoulderController(new Vector2(590, -550));
            boulderFour = new BoulderController(new Vector2(790, -550));
            boulderFive = new BoulderController(new Vector2(990, -550));

            //Store boulders in array
            boulderArray[0] = boulderOne;
            boulderArray[1] = boulderTwo;
            boulderArray[2] = boulderThree;
            boulderArray[3] = boulderFour;
            boulderArray[4] = boulderFive;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameManager.SetFont(Content);
            // Loads Music
            gameManager.InitializeSong(Content);

            gameManager.PlaySong();
            // Sets platform, character, platform and flag textures

            playerController.SetSpriteTextures(Content);
        }

        
        protected override void Update(GameTime gameTime)
        {
            //GameTime
            gameManager.UpdateTime(gameTime);
            //Escape
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Player Movement
            playerController.HandleKeyboardInput(gameManager.GetTime());

            //Boulder Movement
            boulderController.UpdateBoulders(boulderArray, gameManager.GetTime());
            //Player hitbox for collision
            playerController.UpdateRectangleCharacter();

            //Player has collided with boulder, points go to 0
            if(playerController.CheckBoulderCollision(boulderArray))
            {
                gameManager.SetPoints(0);
            }
            //Player has collided with flag, points++
            if(playerController.CheckFlagCollision(gameManager.GetFlag()))
            {
                gameManager.IncrementPoints();
            }
            //Check if points are 10 or more
            gameManager.CheckWin();
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(gameManager.GetColor());

            spriteBatch.Begin();

            // | GAME ENTITIES |

            //Platform Draw
            spriteBatch.Draw(playerController.GetPlatformTexture(), new Rectangle(0, 650, 1500, 10), Color.White);
            //Character Draw
            spriteBatch.Draw(playerController.GetCharacterTexture(), playerController.GetPosition(), null, Color.White, 0,
                new Vector2(0,0), 1, playerController.GetSpriteEffects(),0);
            //Flag Draw
            spriteBatch.Draw(playerController.GetFlagTexture(), new Rectangle(1150, 555, 60, 120), Color.White);

            //Boulders Draw
            boulderController.DrawBoulders(spriteBatch, playerController.GetBoulderTexture(), playerController.GetSpriteEffects(), boulderArray);
              
            //  | TEXT |
            
            //Display Text Draw
            spriteBatch.DrawString(gameManager.GetFont(), gameManager.GetDisplayText(), gameManager.GetDisplayTextLocation(), Color.Black);
            //Directions Draw
            spriteBatch.DrawString(gameManager.GetFont(), "Collect 10 points in a row to win!", new Vector2(460, 709), Color.Black);
            //Directions continued
            spriteBatch.DrawString(gameManager.GetFont(), "Use D or the right arrow key to move. Reach the flag to score a point, " +
                "but don't touch the crushing boulders!", new Vector2(230, 735), Color.Black);           
            //Points Draw
            spriteBatch.DrawString(gameManager.GetFont(), "points: "+ gameManager.points, new Vector2(550, 760), Color.Black);            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }        
    }
}
