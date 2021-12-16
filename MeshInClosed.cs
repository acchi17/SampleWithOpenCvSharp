using System;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace SampleWithOpenCvSharp
{
    class MeshInClosed
    {
        private Mat _imgSrc;
        private Mat _imgSrcGray;
        private System.Windows.Forms.Control _ownerCtrl;

        public Image ImageGray
        {
            get { return BitmapConverter.ToBitmap(_imgSrcGray); }
        }

        public Image ImageContours
        {
            get { return BitmapConverter.ToBitmap(_imgSrc); }
        }

        public delegate void DebugEvent(string msg);
        public event DebugEvent PutLog; 

        public MeshInClosed(System.Windows.Forms.Control ownerCtrl)
        {
            _ownerCtrl = ownerCtrl;
        }

        public bool LoadImage(string imgFilePath)
        {
            bool result = false;

            try
            {
                using (_imgSrc = Cv2.ImRead(imgFilePath, ImreadModes.Color))
                {
                    _imgSrcGray = ToGrayScale(_imgSrc);
                    //Getcontours(_imgSrcGray);
                    OpenCvSharp.Point[][] contours;
                    OpenCvSharp.HierarchyIndex[] hindex;

                    // Get contours
                    //   contours: List of detected contours
                    //   hindex: Info about hierarchy of detected contours
                    Cv2.FindContours(_imgSrcGray, out contours, out hindex,
                        RetrievalModes.External, ContourApproximationModes.ApproxNone);
                    // Draw contours
                    Cv2.DrawContours(_imgSrc, contours, -1, new Scalar(0, 0, 255), 2);
                }
                result = true;
            }
            catch (Exception ex)
            {
                DebugOutput(ex.Message);
            }

            return result;
        }

        private Mat ToGrayScale(Mat src)
        {
            Mat dst = null;
            if (src != null)
            {
                try
                {
                    dst = src.CvtColor(ColorConversionCodes.BGR2GRAY);
                }
                catch (Exception ex)
                {
                    DebugOutput(ex.Message);
                }
            }
            return dst;
        }

        private void Getcontours(Mat srcGray)
        {

        }

        private void DebugOutput(string msg)
        {
            if (!(_ownerCtrl.InvokeRequired))
            {
                PutLog?.Invoke(msg);
            }
        }
    }
}
