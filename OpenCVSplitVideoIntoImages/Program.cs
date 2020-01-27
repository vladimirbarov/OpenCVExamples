using OpenCvSharp;
using System;
using System.IO;

namespace OpenCVSplitVideoIntoImages
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "big_buck_bunny_720p_5mb.mp4";
            var path = "E:\\Downloads\\";

            using (var videoCapture = new VideoCapture(Path.Combine(path, fileName)))
            {
                using (var mat = new Mat())
                {
                    videoCapture.Read(mat);
                    do
                    {
                        var resultFileName = @$"Frame{videoCapture.PosFrames}-TimeStamp{TimeSpan.FromMilliseconds(videoCapture.PosMsec).ToString(@"hh\-mm\-ss\-ffff")}.png";
                        var saveResult = mat.SaveImage(resultFileName);
                        if(!saveResult)
                            Console.WriteLine($"Can not save file. File - {resultFileName}");
                        else
                            Console.WriteLine($"File - {resultFileName}");

                    } while (videoCapture.Read(mat));
                }
            }


            //var videoCapture = new VideoCapture(@"E:\Downloads\big_buck_bunny_720p_5mb.mp4");
            //using (var matrix = new Mat())
            //{
            //    var i = 0;
            //    do
            //    {
            //        i++;

            //        if(videoCapture.Retrieve(matrix, 0))
            //            matrix.SaveImage($"kek-retrieve{i}.png");

            //    } while (videoCapture.Retrieve(matrix, 0));
            //}

            //var videoCapture = new VideoCapture(@"E:\Downloads\big_buck_bunny_720p_5mb.mp4");
            //var matrix = new Mat();
            //{
            //    var i = 0;
            //    matrix = videoCapture.RetrieveMat();
            //    while (matrix != null)
            //    {
            //        i++;
            //        var pos = videoCapture.PosFrames;
            //        var msec = TimeSpan.FromMilliseconds(videoCapture.PosMsec);
            //        var r = matrix.SaveImage($"kek-retrievemat{i}-{pos}-{msec}.png");
            //        matrix = videoCapture.RetrieveMat();
            //    };
            //}

            Console.Read();
        }
    }
}
