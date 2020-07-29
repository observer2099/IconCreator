using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace System.Windows.Forms
{
    public class IconDialog : CommonDialog
    {
        [DllImport("shell32.dll", EntryPoint = "#62", CharSet = CharSet.Unicode, SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool SHPickIconDialog(IntPtr hWnd, StringBuilder pszFilename, int cchFilenameMax, out int pnIconIndex);

        private const int MAX_PATH = 260;

        [DefaultValue(default(string))]
        public string FileName { get; set; }

        [DefaultValue(0)]
        public int IconIndex { get; set; }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            var sb = new StringBuilder(FileName, MAX_PATH);
            int index;
            bool ok = SHPickIconDialog(hwndOwner, sb, MAX_PATH, out index);
            if (ok)
            {
                FileName = Environment.ExpandEnvironmentVariables(sb.ToString());
                IconIndex = index;
            }
            return ok;
        }

        public override void Reset()
        {
            FileName = null;
            IconIndex = 0;
        }
    }
}