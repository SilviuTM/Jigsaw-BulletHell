using jigsawprototype.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace jigsawprototype.TechnicalLibraries
{
    static class FirstLoad
    {
        public static bool isLoaded = false;
        public static byte phase = 0;
        public static byte frame = 0;
        public static byte frameoffset = 0;
        public static byte framefade = 0;


        public static void Update(GraphicsDevice gDevice)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                phase = 4; frame = 0;
            }

            if (Game1.loadingTask == null)
                Game1.loadingTask = Task.Run(() => JigsawManager.LoadData(gDevice));
        }

        public static void Draw(SpriteBatch sBatch)
        {
            sBatch.Begin();

            switch (phase)
            {
                case 0:
                    if (++frame == 40)
                    { phase++; frame = 0; }
                    break;
                case 1:
                    sBatch.Draw(GameContent.shapey, new Vector2(Game1.ScreenWidth / 2 - GameContent.shapey.Width / 2, (Game1.ScreenHeight / 2 - GameContent.shapey.Height) > 0 ?
                                                                                                        (Game1.ScreenHeight / 2 - GameContent.shapey.Height) : 0), Color.White);
                    if (++frame == 10)
                    { phase++; frame = 0; }
                    break;

                case 2:
                    sBatch.Draw(GameContent.shapey, new Vector2(Game1.ScreenWidth / 2 - GameContent.shapey.Width / 2, (Game1.ScreenHeight / 2 - GameContent.shapey.Height) > 0 ?
                                                                                                        (Game1.ScreenHeight / 2 - GameContent.shapey.Height) : 0), Color.White * (1f - frame / 120f));
                    sBatch.Draw(GameContent.shapeintro, new Rectangle(Game1.ScreenWidth / 2 - GameContent.shapey.Width / 2, (Game1.ScreenHeight / 2 - GameContent.shapey.Height) > 0 ?
                                                                     (Game1.ScreenHeight / 2 - GameContent.shapey.Height) : 0, GameContent.shapey.Width, GameContent.shapey.Height),
                                                        new Rectangle(0, 0, GameContent.shapey.Width, GameContent.shapey.Height), Color.White * (frame / 120f));
                    if (++frame == 120)
                    { phase++; frame = 0; }
                    break;

                default: // phases 3 and 4
                    sBatch.Draw(GameContent.shapeintro, new Rectangle(Game1.ScreenWidth / 2 - GameContent.shapey.Width / 2, (Game1.ScreenHeight / 2 - GameContent.shapey.Height) > 0 ?
                                                                  (Game1.ScreenHeight / 2 - GameContent.shapey.Height) : 0, GameContent.shapey.Width, GameContent.shapey.Height),
                                                     new Rectangle(GameContent.shapey.Width * (frame % 7), GameContent.shapey.Height * (frame / 7), GameContent.shapey.Width, GameContent.shapey.Height), Color.White);
                    if (++frameoffset == 3)
                    { frame++; frameoffset = 0; }
                    if (frame == 6*7)
                    { phase = 4; frame = 0; }
                    break;
            }

            if (phase != 0)
            {
                sBatch.DrawString(GameContent.systemFont, "Powered by ", new Vector2(Game1.ScreenWidth / 2 - GameContent.systemFont.MeasureString("Powered by SHAPEY.Engine").X / 2,
                                                                                     Game1.ScreenHeight / 2 + 10), Color.White);
                sBatch.DrawString(GameContent.systemFont, "SHAPEY.Engine", new Vector2(Game1.ScreenWidth / 2 - GameContent.systemFont.MeasureString("Powered by SHAPEY.Engine").X / 2
                                                                                       + GameContent.systemFont.MeasureString("Powered by ").X, Game1.ScreenHeight / 2 + 10), new Color(197, 190, 130));
            }

            if (phase == 4 && Game1.loadingTask.Status.Equals(TaskStatus.RanToCompletion) && frame > 6*7 - 2)
            {
                isLoaded = true;
            }

            if (phase == 4)
            {
                string aux = "Loading";
                if (frame < 7 * 6 * 1/4) aux += "";
                else if (frame < 7 * 6 * 2/4) aux += ".";
                else if (frame < 7 * 6 * 3 / 4) aux += "..";
                else aux += "...";

                sBatch.DrawString(GameContent.systemFont, aux, new Vector2(Game1.ScreenWidth / 2f - GameContent.systemFont.MeasureString("Loading...").X / 2, 
                                                                           Game1.ScreenHeight / 1.05f - GameContent.systemFont.MeasureString("Loading...").Y), Color.Magenta);
            }

            sBatch.End();
        }
    }
}
