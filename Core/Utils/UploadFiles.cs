using System;
using System.IO;

namespace Core.Utlis
{
    public class UploadFiles
    {
        public string Upload(string name, string format, string base64)
        {
            try
            {
                byte[] imgByte = Convert.FromBase64String(base64);
                string path = "wwwroot/Files/";

                if (!Directory.Exists(path))
                {
                    var dir = Directory.CreateDirectory(path);
                }

                path = path + $"{name}.{format}";
                using(FileStream fs = File.Create(path))
                {
                    fs.Write(imgByte, 0, imgByte.Length);
                }

                path = $"Files/{name}.{format}";
                return path;

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public void Delete(string url)
        {
            string path = $"wwwroot/{url}";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                
            }catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
