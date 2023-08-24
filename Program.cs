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
                client.DownloadProgressChanged += (sender, e) =>
                {
                    Console.WriteLine($"Downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage}% complete");
                };

                client.DownloadFileCompleted += (sender, e) =>
                {
                    Console.WriteLine("Download complete.");
                };

                Console.WriteLine($"Downloading {fileName}...");
                client.DownloadFileAsync(new Uri(url), fileName);
                Console.Clear();

                // Keep the application running until download is complete
                while (client.IsBusy)
                {
                    // You can also add a delay here to reduce CPU usage
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
    }
}
