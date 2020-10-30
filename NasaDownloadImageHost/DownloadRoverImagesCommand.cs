using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ManyConsole;
using NasaAPIProject.NasaDownloadImageHost.Services;
namespace NasaAPIProject.NasaDownloadImageHost
{
    public class DownloadImagesCommand : ConsoleCommand
    {
        public string FileLocation { get; set; }
        public DownloadImagesCommand()
        {
            IsCommand("Run", "Downloads Nasa Rover Images and archives them to local folder");
        }
        public override int Run(string[] remainingArguments)
        {
            try
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                var imageArchieve = UnitySetup.Resolve<IDownloadImageservice>();
                var task = Task.Run(() =>
                    imageArchieve.ArchiveImages(FileLocation));
                task.Wait();
                stopWatch.Stop();
                //return (int)task.Result;
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}