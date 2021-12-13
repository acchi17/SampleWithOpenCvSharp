using System;
using System.Drawing;
using OpenCvSharp;

namespace SampleWithOpenCvSharp
{
    class MeshInClosed
    {
        private Mat src;
        public MeshInClosed()
        {
            
        }

        public bool loadImage(string imgFilePath)
        {
            bool result = false;

            try
            {
                using (src = Cv2.ImRead(imgFilePath, ImreadModes.Color)) { }
                result = true;
            }
            catch
            {

            }

            return result;
        }

        private Mat toGrayScale()
        {
            Mat dst = null;
            if (src != null)
            {
                dst = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            }
            return dst;
        }
    }
}
