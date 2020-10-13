using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace MonoGameOneButtonGame
{
    class Gamemanager
    {
        public int points;

        private Flag flag;

        private Song song;        

        private string displayText;

        private Vector2 displayTextLocation;

        private SpriteFont spriteFont;

        private float time;

        private Color backgroundColor;

        public Gamemanager()
        {
            flag = new Flag();
            displayText = "Welcome to Monogame One Button Game!";
            backgroundColor = Color.LightGoldenrodYellow;
            displayTextLocation = new Vector2(430, 680);

            // To test the win condition, uncomment this and score a point.
            //points = 9;
        }

        public void UpdateTime(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public float GetTime()
        {
            return time;
        }

        public void SetFont(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Arial");
        }

        public SpriteFont GetFont()
        {
            return spriteFont;
        }
        // Reset points after collision with boulder
        public void SetPoints(int amount)
        {
            points = amount;
        }

        public void IncrementPoints()
        {
            points++;
        }

        public Color GetColor()
        {
            return backgroundColor;
        }

        public string GetDisplayText()
        {
            return displayText;
        }

        public Vector2 GetDisplayTextLocation()
        {
            return displayTextLocation;
        }

        public Flag GetFlag()
        {
            return flag;
        }

        public void InitializeSong(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            song = content.Load<Song>("Stranger Things Theme Cover");
        }
        public void PlaySong()
        {
            MediaPlayer.Play(song);
            MediaPlayer.Volume = .5f;
        }

        public void SetGraphicsWindow(GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
        }

        public void SetContentRootDirectory(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            content.RootDirectory = "Content";
        }

        public bool CheckWin()
        {
            if(points >= 10)
            {
                SetWin();
                return true;
            }
            else
            {
                SetLose();
                return false;
            }
        }

        private void SetWin()
        {
            displayText = "WIN";
            displayTextLocation.X = 565;
            backgroundColor = Color.Green;
        }

        private void SetLose()
        {
            displayText = "Welcome to Monogame One Button Game!";
            displayTextLocation.X = 430;
            backgroundColor = Color.LightGoldenrodYellow;
        }
    }
}
