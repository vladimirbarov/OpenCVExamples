using System;
using System.Diagnostics;

namespace ffmpegExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            startInfo.FileName = @"C:\Windows\System32\cmd.exe";
            startInfo.Arguments = $@"/c E:\Downloads\ffmpeg-4.2.2-win64-static\ffmpeg-4.2.2-win64-static\bin\ffmpeg.exe -i E:\Downloads\big_buck_bunny_720p_5mb.mp4 img%03d.bmp";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            Console.Read();
        }
    }
}
