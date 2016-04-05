using Microsoft.Xna.Framework.Graphics;

namespace Mogine.Graphics
{
    public class Graphics
    {
        public static Graphics Instance;

        public SpriteBatch SpriteBatch;

        public Graphics(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }
    }
}