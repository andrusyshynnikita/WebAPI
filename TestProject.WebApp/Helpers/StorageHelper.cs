using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestProject.WebApp.Helpers
{
    public static class StorageHelper
    {
        private static readonly string _filePath;

        static StorageHelper()
        {
            _filePath = HttpContext.Current.Server.MapPath("~/Uploads/");
        }
        public static async Task<bool> WriteByteToFileAsync(string audioFileName, byte[] audioFileContent)
        {
            string file = GetFullPathFile(audioFileName);

            try
            {
                using (FileStream sourceStream = new FileStream(file, FileMode.OpenOrCreate))
                {
                    await sourceStream.WriteAsync(audioFileContent, 0, audioFileContent.Length);
                };

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<byte[]> ReadFileAsync(string audioFileName)
        {
            byte[] result;

            string file = GetFullPathFile(audioFileName);

            try
            {
                using (FileStream SourceStream = File.Open(file, FileMode.Open))
                {
                    result = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> DeleteFile(string audioFileName)
        {
            string file = GetFullPathFile(audioFileName);

            try
            {
                using (FileStream stream = new FileStream(file, FileMode.Truncate, FileAccess.Write, FileShare.Delete, 4096, true))
                {
                    await stream.FlushAsync();
                    File.Delete(file);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetFullPathFile(string audioFileName)
        {
            string file = _filePath + audioFileName;

            return file;
        }
    }
}