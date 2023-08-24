using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DirectLinkDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: DirectLinkDownloader.exe <URL>");
                return;
            }

            string url = args[0];
            string fileName = url.Substring(url.LastIndexOf("/") + 1);

            using (WebClient client = new WebClient())
            {
                Console.WriteLine($"Downloading {fileName}...");
                client.DownloadFile(url, fileName);
                Console.WriteLine("Download complete.");
            }
        }
    }
}
