using Microsoft.Xna.Framework.Graphics;

namespace jigsawprototype.TechnicalLibraries
{
    static class JigsawManager
    {
        static public void ChooseImage(GraphicsDevice gDevice)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Users\\";
                openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.jpeg;*.png" + "|" +
                                        "Bitmap Files (*.bmp)|*.bmp" + "|" +
                                        "GIF Files (Unstable) (*.gif)|*.gif";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    // Create Texture2D from stream
                    Texture2D image = Texture2D.FromStream(gDevice, fileStream);
                }
            }
        }
    }

    class Jigsaw
    {
        Texture2D texture;
        string filepath;
        bool[] diff_cleared;
    }
}
