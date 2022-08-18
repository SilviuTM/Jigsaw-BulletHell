using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace jigsawprototype.Content
{
    static class GameContent
    {
        ///... content
        public static Texture2D shapeintro;
        public static Texture2D shapeintro2;
        public static Texture2D shapey;
        public static Texture2D blank;
        public static SpriteFont systemFont;
        ///

        static public void LoadContent(ContentManager Content)
        {
            ///... load
            shapeintro = Content.Load<Texture2D>("shapey-nimate");
            shapeintro2 = Content.Load<Texture2D>("shapey-nimate2");
            shapey = Content.Load<Texture2D>("shapey");
            blank = Content.Load<Texture2D>("blank");
            systemFont = Content.Load<SpriteFont>("SystemFont");
            ///
        }
    }
}
