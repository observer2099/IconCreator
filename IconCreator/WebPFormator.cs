using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;


namespace System
{
    public static class WebpFormator
    {
        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int WebPGetInfo(IntPtr data, UIntPtr data_size, out int width, out int height);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int WebPDecodeBGRAInto(IntPtr data, UIntPtr data_size, IntPtr output_buffer, int output_buffer_size, int output_stride);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int WebPEncodeBGRA(IntPtr rgba, int width, int height, int stride, float quality_factor, out IntPtr output);

        [DllImport("libwebp.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int WebPFree(IntPtr p);


        public static void ImageToWebp(Bitmap img, string file)
        {
            Bitmap bmp = new Bitmap(img);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            IntPtr webpData;
            int size = WebPEncodeBGRA(bmpData.Scan0, bmp.Width, bmp.Height, bmpData.Stride, 80, out webpData);
            byte[] buffers = new byte[size];
            Marshal.Copy(webpData, buffers, 0, size);
            File.WriteAllBytes(file, buffers);
            WebPFree(webpData);
        }

        public static Bitmap WebpToImage(string file)
        {
            int width;
            int height;
            int outputSize;
            Bitmap bmp = null;
            BitmapData bmpData = null;
            byte[] rawWebP = File.ReadAllBytes(file);
            GCHandle pinnedWebP = GCHandle.Alloc(rawWebP, GCHandleType.Pinned);
            try
            {
                IntPtr ptrData = pinnedWebP.AddrOfPinnedObject();
                WebPGetInfo(ptrData, (UIntPtr)rawWebP.Length, out width, out height);
                bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                bmpData = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                outputSize = bmpData.Stride * height;
                WebPDecodeBGRAInto(ptrData, (UIntPtr)rawWebP.Length, bmpData.Scan0, outputSize, bmpData.Stride);
                return bmp;
            }
            finally
            {
                if (bmpData != null)
                    bmp.UnlockBits(bmpData);

                if (pinnedWebP.IsAllocated)
                    pinnedWebP.Free();
            }
        }
    }
}