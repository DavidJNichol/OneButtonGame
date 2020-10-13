using Microsoft.Xna.Framework;

namespace MonoGameOneButtonGame
{
    public class Flag
    {
        //Collision Box
        public Rectangle flagBoundryBox;
        public Vector2 flagLocation;

        public Flag()
        {
            flagLocation = new Vector2(1150, 555);
            flagBoundryBox = new Rectangle((int)flagLocation.X, (int)flagLocation.Y, 60, 120);
        }
    }
}
