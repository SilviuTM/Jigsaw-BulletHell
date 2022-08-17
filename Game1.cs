using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace jigsawprototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sBatch;

        public int ScreenWidth = 1600;
        public int ScreenHeight = 900;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Users\\";
                openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.jpeg;*.png" + "|" +
                                        "Bitmap Files (*.bmp)|*.bmp" + "|" +
                                        "GIF Files (Unstable) (*.gif)|*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Get the path of specified file
                    filePath = openFileDialog.FileName;

                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    // Create Texture2D from stream file
                    Texture2D image = Texture2D.FromStream(GraphicsDevice, fileStream);
                }


            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
