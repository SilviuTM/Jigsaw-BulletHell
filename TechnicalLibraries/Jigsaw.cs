using jigsawprototype.Content;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace jigsawprototype.TechnicalLibraries
{
    static class JigsawManager
    {
        public static List<Jigsaw> importedPuzzles = new List<Jigsaw>();
        public static Texture2D fileImage;
        public static RenderTarget2D editorImage;

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
                    fileImage = Texture2D.FromStream(gDevice, fileStream);
                }
            }


            // open and init editor
            // editor creates a new image (the render target) and stores for the new puzzle the filepath of the new image and the texture using the rtarget
        }

        static public void SaveData()
        {
            File.Create("SaveData\\SaveFile.txt");
            File.AppendAllText("SaveData\\SaveFile.txt", importedPuzzles.Count.ToString() + "\n");

            foreach (Jigsaw puzzle in importedPuzzles)
            {
                File.AppendAllText("SaveData\\SaveFile.txt", puzzle.filepath + "\n");
                foreach (bool value in puzzle.diff_cleared)
                {
                    File.AppendAllText("SaveData\\SaveFile.txt", value == true ? "1" : "0");
                }
                File.AppendAllText("SaveData\\SaveFile.txt", "\n");
            }
        }

        static public void LoadData(GraphicsDevice gDevice)
        {
            if (!File.Exists("SaveData\\SaveFile.txt")) // doesn't exist don't read
                return;

            string[] lines = File.ReadAllLines("SaveData\\SaveFile.txt");
            int count = int.Parse(lines[0]);

            for (int i = 1; i <= count; i++)
            {
                Jigsaw aux = new Jigsaw();
                aux.filepath = lines[i * 2 - 1];
                aux.texture = Texture2D.FromFile(gDevice, aux.filepath);

                for (int j = 0; j < aux.diff_cleared.Length; j++)
                    if (lines[i * 2][j] == '0')
                        aux.diff_cleared[j] = false;
                    else aux.diff_cleared[j] = true;
            }
        }
    }

    class Jigsaw
    {
        public Texture2D texture;
        public string filepath;
        public bool[] diff_cleared;

        public Jigsaw()
        {
            filepath = string.Empty;
            diff_cleared = new bool[3];
        }
    }
}
