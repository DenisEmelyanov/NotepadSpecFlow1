using Accord.Imaging;
using Accord.Imaging.Filters;
using Accord.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Accord;

namespace ComputerVision
{
    class Program
    {
        static IntPoint GetBasePoint(List<IntPoint> points)
        {
            IntPoint resPoint = new IntPoint(0,0);
            double dist = double.MaxValue;
            foreach (IntPoint p in points)
            {
                double pDist = Math.Sqrt(p.X * p.X + p.Y * p.Y);
                if (pDist < dist)
                {
                    dist = pDist;
                    resPoint.X = p.X;
                    resPoint.Y = p.Y;
                }                   
            }
            return resPoint;
        }

        static List<IntPoint> SubtractBase(List<IntPoint> points)
        {
            IntPoint bp = GetBasePoint(points);
            List<IntPoint> resPoints = new List<IntPoint>();
            foreach(IntPoint p in points)
            {
                resPoints.Add(new IntPoint(p.X - bp.X, p.Y - bp.Y));
            }
            return resPoints;
        }

        static void Main(string[] args)
        {
            Bitmap source = new Bitmap(@"D:\column_lock.png");
            //Bitmap newImage = new Bitmap(source.Width + 4, source.Height + 4);
            //Graphics g = Graphics.FromImage(newImage);
            //g.DrawImage(source, 2, 2);
            // Create a new Harris Corners Detector using the given parameters
            HarrisCornersDetector harris = new HarrisCornersDetector()
            {
                Threshold = 10000,
                Sigma = 1.2
            };

            List<IntPoint> points = harris.ProcessImage(source);
            Console.WriteLine("Total points: {0}", points.Count);
            Console.WriteLine("X:");

            IntPoint basePoint = GetBasePoint(points);
            Console.WriteLine("Base point: {0}x{1}", basePoint.X, basePoint.Y);

            List<IntPoint> resPoints = SubtractBase(points);

            foreach (IntPoint p in resPoints)
            {
                Console.WriteLine("{0}", p.X);
            }
            Console.WriteLine("Y:");
            foreach (IntPoint p in resPoints)
            {
                Console.WriteLine("{0}", p.Y);
            }





            // Create a new AForge's Corner Marker Filter
            CornersMarker corners = new CornersMarker(harris, Color.Red);

            var result = corners.Apply(source);
            result.Save(@"D:\result.png", ImageFormat.Png);
            Console.Read();

            //Bitmap source = new Bitmap(@"D:\flowsheet_lock.png");            

            //// Create a new FAST Corners Detector
            //FastCornersDetector fast = new FastCornersDetector()
            //{
            //    Suppress = true, // suppress non-maximum points
            //    Threshold = 40   // less leads to more corners
            //};

            //// Process the image looking for corners
            //List<IntPoint> points = fast.ProcessImage(source);
            //Console.WriteLine("Total points: {0}", points.Count);
            //Console.WriteLine("X:");
            //foreach (IntPoint p in points)
            //{
            //    Console.WriteLine("{0}", p.X);
            //}
            //Console.WriteLine("Y:");
            //foreach (IntPoint p in points)
            //{
            //    Console.WriteLine("{0}", p.Y);
            //}
            //// Create a filter to mark the corners
            //PointsMarker marker = new PointsMarker(points, Color.Red);
            ////FeaturesMarker marker = new FeaturesMarker(points, scale: 20);

            //// And showing it on screen with
            //marker.Apply(source).Save(@"D:\result.png", ImageFormat.Png);
            //Console.Read();

            //// The freak detector can be used with any other corners detection
            //// algorithm. The default corners detection method used is the FAST
            //// corners detection. So, let's start creating this detector first:
            //// 
            //var detector = new FastCornersDetector(1);

            //// Now that we have a corners detector, we can pass it to the FREAK
            //// feature extraction algorithm. Please note that if we leave this
            //// parameter empty, FAST will be used by default.
            //// 
            //var freak = new FastRetinaKeypointDetector(detector);

            //// Now, all we have to do is to process our image:
            //List<FastRetinaKeypoint> points = freak.ProcessImage(source);

            //// Afterwards, we should obtain 83 feature points. We can inspect
            //// the feature points visually using the FeaturesMarker class as
            //// 
            //FeaturesMarker marker = new FeaturesMarker(points, scale: 20);



            //// We can also inspect the feature vectors (descriptors) associated
            //// with each feature point. In order to get a descriptor vector for
            //// any given point, we can use
            //// 
            //byte[] feature = points[42].Descriptor;

            //// By default, feature vectors will have 64 bytes in length. We can also
            //// display those vectors in more readable formats such as HEX or base64
            //// 
            //string hex = points[42].ToHex();
            //string b64 = points[42].ToBase64();
            //Console.WriteLine("Hash: {0}", b64);
            //Console.Read();
            // The above base64 result should be:
            // 
            //  "3W8M/ev///ffbr/+v3f34vz//7X+f0609v//+++/1+jfq/e83/X5/+6ft3//b4uaPZf7ePb3n/P93/rIbZlf+g=="

            //Hash: +T+smp8Z9s+76lv01y0rfpfv/8LbbPenauG3o+/ZyMqb9hWdb+deMse1E0bqr0pSFIVlDRXWHaP7ZnNNCalRzg==
        }
    }
}
