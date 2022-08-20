using jigsawprototype.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace jigsawprototype.TechnicalLibraries
{
    static class MainMenu
    {
        public static bool isMenu, isMode, isDiff;

        public static void Update()
        {
            if (isDiff) // difficulty choice
            {

            }

            else if (isMode) // game mode choice
            {

            }

            else // main menu
            {

            }
        }

        public static void Draw(SpriteBatch sb)
        {
            sb.Begin();

            int i = 0;
            /*
            foreach(Jigsaw puzzle in JigsawManager.importedPuzzles)
            {
                sb.Draw(puzzle.mm_texture, 
                   new Vector2(Game1.ScreenWidth * 0.025f + Game1.ScreenWidth * 0.05f * (i % 4) + Game1.ScreenWidth * 0.2f * (i % 4) + Game1.ScreenWidth * 0.1f, // 2.5% margin +5% gaps +20% textures themselves +offset
                            Game1.ScreenHeight * 0.014f + Game1.ScreenHeight * 0.088f * (i / 4) + Game1.ScreenHeight * 0.355f * (i / 4) + Game1.ScreenHeight * 0.177f), // 1.4% margin +8.8% gaps +35.5% textures +offset
                                           null, Color.White, 0f, puzzle.mm_texture.Bounds.Center.ToVector2(), 1f, SpriteEffects.None, 1f);
            }
            */

            sb.DrawString(GameContent.systemFont, Mouse.GetState().X.ToString() + ", " + Mouse.GetState().Y.ToString(), new Vector2(0, 800), Color.Wheat);

            while (i < 8)
            {
                float auxX = Game1.ScreenWidth * 0.025f + Game1.ScreenWidth * 0.05f * (i % 4) + Game1.ScreenWidth * 0.2f * (i % 4);
                float auxY = Game1.ScreenHeight * 0.04f + Game1.ScreenHeight * 0.088f * (i / 4) + Game1.ScreenHeight * 0.355f * (i / 4);
                float scaleX = Game1.ScreenWidth / 1600f;
                float scaleY = Game1.ScreenHeight / 900f;
                float scale = scaleX < scaleY ? scaleX : scaleY;
                //float postScaleX = (Game1.ScreenWidth * 0.025f + Game1.ScreenWidth * 0.05f * (i % 4)) + Game1.ScreenWidth * 0.2f * (i % 4) * scale;
                //float postScaleY = (Game1.ScreenHeight * 0.04f + Game1.ScreenHeight * 0.088f * (i / 4)) + Game1.ScreenHeight * 0.355f * (i / 4) * scale;

                if (new Rectangle((int)(auxX), (int)(auxY), (int)(320f * scale), (int)(320f * scale)).Contains(Mouse.GetState().Position))
                {
                    sb.Draw(GameContent.import,
                            new Vector2(auxX + Game1.ScreenWidth * 0.1f, // 2.5% margin +5% gaps +20% textures themselves +offset
                                        auxY + Game1.ScreenHeight * 0.177f), // 1.4% margin +8.8% gaps +35.5% textures +offset
                                                null, Color.White, 0f, GameContent.import.Bounds.Center.ToVector2(),
                            320f / GameContent.import.Width * scale * 1.05f,  // rescale to 320, then does the scale based on smallest 
                            SpriteEffects.None, 1f);
                }

                else
                {
                    sb.Draw(GameContent.import,
                            new Vector2(auxX + Game1.ScreenWidth * 0.1f, // 2.5% margin +5% gaps +20% textures themselves +offset
                                        auxY + Game1.ScreenHeight * 0.177f), // 1.4% margin +8.8% gaps +35.5% textures +offset
                                                null, Color.White, 0f, GameContent.import.Bounds.Center.ToVector2(),
                            320f / GameContent.import.Width * scale,  // rescale to 320, then does the scale based on smallest 
                            SpriteEffects.None, 1f);
                }

                i++;
            }

            sb.End();
        }
    }
}
