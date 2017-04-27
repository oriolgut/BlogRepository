using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApril2017
{
    public class FileHandlerAsync
    {
        private const int DEFAULT_BUFFER_SIZE = 4096;

        public static async Task<string> ReadAllLinesAsync(string @path)
        {
            if(!File.Exists(path)) throw new ArgumentException($"The File {path} doesn't exists");

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, DEFAULT_BUFFER_SIZE, FileOptions.Asynchronous | FileOptions.SequentialScan))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }         
        }
    }
}
