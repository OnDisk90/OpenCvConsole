// See https://aka.ms/new-console-template for more information
using System;
using OpenCvSharp;

class Program
{
    static void Main(string[] args)
    {
        string windowsTitle = "OpenCv Console ";
        if (args.Length > 0)
        {
            string cameraSource = args[0];
            Console.WriteLine(windowsTitle);
            Console.WriteLine("Open CV version " + Cv2.GetVersionString());
            Console.WriteLine("Please wait to the camera window");
            Console.WriteLine("Camera source: " + cameraSource);
            InitCamera(windowsTitle, cameraSource);
        }
        else
        {
            Console.WriteLine("Usage OpenCvConsole <cameraStrem> ");
            Console.WriteLine("Example: ");
            Console.WriteLine("OpenCvConsole  rtsp://807e9439d5ca.entrypoint.cloud.wowza.com:1935/app-rC94792j/068b9c9a_stream2 ");
        }
    }


    private static void InitCamera(string windowTitle, string source)
    {
        try
        {
            using VideoCapture videoCapture = new VideoCapture(source);
            using Mat frameCopy = new();
            Console.WriteLine("camera started");
            while (videoCapture.IsOpened())
            {
                using Mat frame = videoCapture.RetrieveMat();
                if (!frame.Empty())
                {

                    Cv2.ImShow(windowTitle, frame);
                }

                if (Cv2.WaitKey(40) == 'q')
                {
                    break;
                }
            }
            Cv2.DestroyWindow(windowTitle);
        }
        catch(Exception e)
        { 
            Console.WriteLine(e.Message);
        }
        

       
    }
}
