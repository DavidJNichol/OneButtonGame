using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameOneButtonGame
{
    abstract class Sprite : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D platform;
        protected Texture2D character;
        protected Texture2D flag;
        protected Texture2D boulder;
        protected SpriteEffects spriteEffects;


        protected Sprite(Game game)
            : base(game)
        {
            spriteEffects = new SpriteEffects();
        }

        protected void SetTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            platform = content.Load<Texture2D>("Platform");
            character = content.Load<Texture2D>("Character");
            flag = content.Load<Texture2D>("Flag");
            boulder = content.Load<Texture2D>("Boulder");
        }
    }
}
