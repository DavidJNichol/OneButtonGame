using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameOneButtonGame
{
    class Character : Sprite
    {
        public float speed;
        public float acceleration;
        public float velocity;
        public Vector2 direction;
        public Vector2 startPosition;
        public Vector2 position;
        public Rectangle characterBoundingBox;

        public Rectangle flagBoundryBox;
        public Vector2 flagLocation;

        public Character(Game game) : base(game)
        {
            direction = new Vector2(1, 0);
            startPosition = new Vector2(20, 567);
            position = startPosition;
            speed = 210;

            flagLocation = new Vector2(1150, 555);
            flagBoundryBox = new Rectangle((int)flagLocation.X, (int)flagLocation.Y, 60, 120);

            characterBoundingBox = new Rectangle((int)position.X, (int)position.Y, 53, 85);
        }

        public Vector2 GetStartPosition()
        {
            return startPosition;
        }

        public Vector2 GetFlagLocation()
        {
            return flagLocation;
        }

        public Rectangle GetFlagBoundryBox()
        {
            return flagBoundryBox;
        }

        public Texture2D GetPlatformTexture()
        {
            return platform;
        }

        public Texture2D GetCharacterTexture()
        {
            return character;
        }

        public Texture2D GetFlagTexture()
        {
            return flag;
        }

        public Texture2D GetBoulderTexture()
        {
            return boulder;
        }

        public void SetSpriteTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            platform = content.Load<Texture2D>("Platform");
            character = content.Load<Texture2D>("Character");
            flag = content.Load<Texture2D>("Flag");
            boulder = content.Load<Texture2D>("Boulder");
        }

        public SpriteEffects GetSpriteEffects()
        {
            return spriteEffects;
        }

    }
}
