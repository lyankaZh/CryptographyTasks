using System.IO;

namespace HammaCipherTask
{
    public class FileManager
    {
        public string Read(string file)
        {
            using (var reader = new StreamReader(file))
            {
                var text = reader.ReadToEnd();
                return text;
            }
        }

        public void Write(string text, string file)
        {
            using (var writer = new StreamWriter(file))
            {
                writer.Write(text);
            }
        }
    }
}
