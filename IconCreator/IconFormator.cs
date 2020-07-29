using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

namespace System
{
    public static class IconFormator
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        public delegate bool ENUMRESNAMEPROC(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hFile, uint dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceNames(IntPtr hModule, IntPtr lpszType, ENUMRESNAMEPROC lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LockResource(IntPtr hResData);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);


        public static List<Icon> LoadIcon(string fileName)
        {
            IntPtr hModule = IntPtr.Zero;
            var iconDatas = new List<byte[]>();

            byte[] GetDataFromResource(IntPtr hmodule, IntPtr type, IntPtr name)
            {
                IntPtr hResInfo = FindResource(hmodule, name, type);
                IntPtr hResData = LoadResource(hmodule, hResInfo);
                IntPtr pResData = LockResource(hResData);
                uint size = SizeofResource(hmodule, hResInfo);
                var bytes = new byte[size];
                Marshal.Copy(pResData, bytes, 0, bytes.Length);
                return bytes;
            }

            try
            {
                hModule = LoadLibraryEx(fileName, IntPtr.Zero, 0x00000002);
                ENUMRESNAMEPROC callback = (h, t, name, l) => {
                    var dir = GetDataFromResource(hModule, (IntPtr)14, name);
                    int count = BitConverter.ToUInt16(dir, 4);
                    int len = 6 + 16 * count;
                    for (int i = 0; i < count; ++i)
                        len += BitConverter.ToInt32(dir, 6 + 14 * i + 8);

                    using (var dst = new BinaryWriter(new MemoryStream(len)))
                    {
                        dst.Write(dir, 0, 6);
                        int picOffset = 6 + 16 * count;
                        for (int i = 0; i < count; ++i)
                        {
                            ushort id = BitConverter.ToUInt16(dir, 6 + 14 * i + 12);
                            var pic = GetDataFromResource(hModule, (IntPtr)3, (IntPtr)id);
                            dst.Seek(6 + 16 * i, SeekOrigin.Begin);
                            dst.Write(dir, 6 + 14 * i, 8);
                            dst.Write(pic.Length);
                            dst.Write(picOffset);
                            dst.Seek(picOffset, SeekOrigin.Begin);
                            dst.Write(pic, 0, pic.Length);
                            picOffset += pic.Length;
                        }
                        iconDatas.Add(((MemoryStream)dst.BaseStream).ToArray());
                    }
                    return true;
                };
                EnumResourceNames(hModule, (IntPtr)14, callback, IntPtr.Zero);
            }
            finally
            {
                if (hModule != IntPtr.Zero)
                    FreeLibrary(hModule);
            }
            
            var icons = new List<Icon>();
            for (int i = 0; i < iconDatas.Count; i++)
            {
                using (var ms = new MemoryStream(iconDatas[i]))
                {
                    icons.Add(new Icon(ms));
                }
            }
            return icons;
        }

        public static void SaveIcon(List<Bitmap> imgs, string file)
        {
            Icon icon;
            var msImgs = new List<MemoryStream>();
            foreach (var img in imgs)
            {
                var msImg = new MemoryStream();
                img.Save(msImg, ImageFormat.Png);
                msImgs.Add(msImg);
            }

            using (var msIco = new MemoryStream())
            {
                using (var bw = new BinaryWriter(msIco))
                {
                    int offset = 0;
                    bw.Write((short)0);                   // 0-1 reserved, 0
                    bw.Write((short)1);                   // 2-3 image type, 1 = icon, 2 = cursor
                    bw.Write((short)imgs.Count);          // 4-5 number of images
                    offset += 6 + (16 * imgs.Count);      // offset,6 + 16 * n
                    for (int i = 0; i < imgs.Count; i++)
                    {
                        bw.Write((byte)imgs[i].Width);    // 0 image width
                        bw.Write((byte)imgs[i].Width);    // 1 image height
                        bw.Write((byte)0);                // 2 number of colors
                        bw.Write((byte)0);                // 3 reserved, 0
                        bw.Write((short)0);               // 4-5 color planes
                        bw.Write((short)32);              // 6-7 bits per pixel
                        bw.Write((int)msImgs[i].Length);  // 8-11 size of image data
                        bw.Write(offset);                 // 12-15 offset of image data, 6 + 16
                        offset += (int)msImgs[i].Length;
                    }

                    for (int i = 0; i < imgs.Count; i++)  // write image data, png data must contain the whole png data file
                    {
                        bw.Write(msImgs[i].ToArray());
                        msImgs[i].Close();
                    }
                    bw.Flush();
                    bw.Seek(0, SeekOrigin.Begin);
                    icon = new Icon(msIco);
                }
            }

            using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                icon.Save(fs);
            }
        }

        public static Icon[] SplitIcon(Icon icon)
        {
            byte[] iconData;
            var icons = new List<Icon>();
            using (var ms = new MemoryStream())
            {
                icon.Save(ms);
                iconData = ms.ToArray();
            }

            int count = BitConverter.ToUInt16(iconData, 4);
            for (int i = 0; i < count; i++)
            {
                int length = BitConverter.ToInt32(iconData, 6 + 16 * i + 8);
                int offset = BitConverter.ToInt32(iconData, 6 + 16 * i + 12);
                using (var bw = new BinaryWriter(new MemoryStream(6 + 16 + length)))
                {
                    bw.Write(iconData, 0, 4);
                    bw.Write((short)1);
                    bw.Write(iconData, 6 + 16 * i, 12);
                    bw.Write(22);
                    bw.Write(iconData, offset, length);
                    bw.BaseStream.Seek(0, SeekOrigin.Begin);
                    icons.Add(new Icon(bw.BaseStream));
                }
            }
            return icons.OrderBy(x => GetIconBits(x)).ThenBy(x => x.Height).ToArray();
        }

        public static int GetIconBits(Icon icon)
        {
            byte[] iconData;
            using (var ms = new MemoryStream())
            {
                icon.Save(ms);
                iconData = ms.ToArray();
            }

            if (iconData.Length >= 51
                && iconData[22] == 0x89 && iconData[23] == 0x50 && iconData[24] == 0x4e && iconData[25] == 0x47
                && iconData[26] == 0x0d && iconData[27] == 0x0a && iconData[28] == 0x1a && iconData[29] == 0x0a
                && iconData[30] == 0x00 && iconData[31] == 0x00 && iconData[32] == 0x00 && iconData[33] == 0x0d
                && iconData[34] == 0x49 && iconData[35] == 0x48 && iconData[36] == 0x44 && iconData[37] == 0x52)
            {
                switch (iconData[47])
                {
                    case 0:
                    case 3:
                        return iconData[46];
                    case 4:
                        return iconData[46] * 2;
                    case 2:
                        return iconData[46] * 3;
                    case 6:
                        return iconData[46] * 4;
                    default:
                        break;
                }
            }
            else if (iconData.Length >= 22)
                return BitConverter.ToUInt16(iconData, 12);
            throw new ArgumentException("Corrupted Icon!");
        }
    } 
}