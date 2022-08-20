using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using jigsawprototype.TechnicalLibraries;
using jigsawprototype.Content;
using System.IO;
using System.Threading.Tasks;

namespace jigsawprototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sBatch;

        public static int ScreenWidth = 1600;
        public static int ScreenHeight = 900;

        public static Task loadingTask;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sBatch = new SpriteBatch(GraphicsDevice);

            GameContent.LoadContent(Content);

            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight; // change resolution
            // graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            ScreenHeight = Window.ClientBounds.Height;
            ScreenWidth = Window.ClientBounds.Width;

            if (!FirstLoad.isLoaded)
                FirstLoad.Update(GraphicsDevice);

            if (MainMenu.isMenu)
                MainMenu.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!FirstLoad.isLoaded)
            {
                GraphicsDevice.Clear(Color.Black);
                FirstLoad.Draw(sBatch);
            }

            else if (MainMenu.isMenu)
            {
                GraphicsDevice.Clear(new Color(127, 54, 73));
                MainMenu.Draw(sBatch);
            }

            base.Draw(gameTime);
        }
    }
}
