using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class ORM
    {
        public static async Task<string[]> ReadDataAsync()
        {
            using var reader = File.OpenText("data.txt");
            var fileText = await reader.ReadToEndAsync();
            return fileText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}
