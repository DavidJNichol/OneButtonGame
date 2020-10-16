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
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);           
            
            gameManager = new Gamemanager(this);

            // 1200x800 Window
            gameManager.SetContentRootDirectory(Content);
            gameManager.SetGraphicsWindow(graphics);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameManager.SetFont(Content);
            // Loads Music
            gameManager.InitializeSong(Content);

            gameManager.PlaySong();
            // Sets platform, character, platform and flag textures

            gameManager.playerController.SetSpriteTextures(Content);
        }

        
        protected override void Update(GameTime gameTime)
        {
            //GameTime
            gameManager.UpdateTime(gameTime);
            //Escape
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Player Movement
            gameManager.playerController.HandleKeyboardInput(gameManager.GetTime());

            //Boulder Movement and hitbox update
            gameManager.boulderController.Update(gameTime);

            //Player hitbox for collision
            gameManager.playerController.UpdateRectangleCharacter();

            //Player has collided with boulder, points go to 0
            if (gameManager.playerController.CheckBoulderCollision(gameManager.boulderController.GetBoulderArray()))
            {
                gameManager.SetPoints(0);
            }
            //Player has collided with flag, points++
            if (gameManager.playerController.CheckFlagCollision())
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
            spriteBatch.Draw(gameManager.playerController.GetPlatformTexture(), new Rectangle(0, 650, 1500, 10), Color.White);
            //Character Draw
            spriteBatch.Draw(gameManager.playerController.GetCharacterTexture(), gameManager.playerController.GetPosition(), null, Color.White, 0,
                new Vector2(0,0), 1, gameManager.playerController.GetSpriteEffects(),0);
            //Flag Draw
            spriteBatch.Draw(gameManager.playerController.GetFlagTexture(), new Rectangle(1150, 555, 60, 120), Color.White);

            //Boulders Draw
            gameManager.boulderController.DrawBoulders(spriteBatch, gameManager.playerController.GetBoulderTexture(), gameManager.playerController.GetSpriteEffects(), gameManager.boulderController.GetBoulderArray());
              
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
