using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;


namespace IconCreator
{
    public partial class FrmMain : Form
    {
        Bitmap imgIco;
        Bitmap imgPvw = new Bitmap(512, 512);
        Bitmap imgThn = new Bitmap(128, 128);
        Bitmap imgZoom = new Bitmap(256, 256);
        Bitmap imgBkgPvw = new Bitmap(512, 512);
        Bitmap imgBkgZoom = new Bitmap(256, 256);
        int thbX = 0, thbY = 0;
        int zoomW, zoomH;
        List<Bitmap> imgIcos;
        int pSize = 8;

        public FrmMain()
        {
            InitializeComponent();          
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            imgBkgPvw = new Bitmap(ImageFormator.BackgroundImage(512, 32));
            imgBkgZoom = new Bitmap(ImageFormator.BackgroundImage(256, 32));
            picPvw.AllowDrop = true;
            zoomW = 256 / 2;
            zoomH = 256 / 2;
        }

        private void PicPvw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.DrawImage(imgBkgPvw, 0, 0);
            e.Graphics.DrawImage(imgPvw, 0, 0);
            e.Graphics.DrawImage(imgThn, thbX, thbY);
        }

        private void PicZoom_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.DrawImage(imgBkgZoom, 0, 0);
            e.Graphics.DrawImage(imgZoom, 0, 0);
        }

        private void BtnOpenImg_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog() { Filter = "Image Files (*.bmp;*.jpg;*.png;*.svg;*.webp)|*.bmp;*.jpg;*.png;*.svg;*.webp" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgIco = ImageFormator.PreviewImage(ImageFormator.GetPictureImage(dlg.FileName), 512, 512, rdoScale.Checked);
                imgPvw = new Bitmap(imgIco);
                picPvw.Refresh();
                chkPixel.Enabled = true;
                btnSaveIco.Enabled = true;
            }
        }

        private void BtnOpenIcon_Click(object sender, EventArgs e)
        {
            var dlg = new IconDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgIco = ImageFormator.GetIconImage(dlg.FileName, dlg.IconIndex);
                imgPvw = PixelFormator.PixelIcon(imgIco, 1, 512);
                picPvw.Refresh();
                chkPixel.Enabled = true;
                btnSaveIco.Enabled = true;
            }
        }

        private void RdoPixel_Click(object sender, EventArgs e)
        {
            pSize = Convert.ToInt32(((RadioButton)sender).Text);
            imgPvw = PixelFormator.PixelIcon(imgIco, pSize, 512);
            picPvw.Refresh();
        }

        private void ChkPixel_Click(object sender, EventArgs e)
        {
            if (chkPixel.Checked == true)
            {
                imgPvw = PixelFormator.PixelIcon(imgIco, pSize, 512);
                grpPixel.Enabled = true;
                picPvw.Refresh();
            }
            else
            {
                imgPvw = PixelFormator.PixelIcon(imgIco, 1, 512);
                grpPixel.Enabled = false;
                picPvw.Refresh();
            }
        }

        private void BtnSaveIco_Click(object sender, EventArgs e)
        {
            if (!PrepareIcons(imgIco))
            {
                MessageBox.Show("No size of Icon is selected");
                return;
            }
            var dlg = new SaveFileDialog() { Filter = "Icon Files (*.ico)|*.ico|Portable Network Graphic (*.png)|*.png|WebP Format (*.webp)|*.webp" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string file = Path.GetFileNameWithoutExtension(dlg.FileName);
                string dir = Path.GetDirectoryName(dlg.FileName);
                switch (dlg.FilterIndex)
                {
                    case 1:
                        IconFormator.SaveIcon(imgIcos, dlg.FileName);
                        break;
                    case 2:
                        foreach (var img in imgIcos)
                            img.Save($"{Path.Combine(dir, file)}@{img.Width}_{img.Height}.png", ImageFormat.Png);
                        break;
                    case 3:
                        foreach (var img in imgIcos)
                            WebpFormator.ImageToWebp(img, $"{Path.Combine(dir, file)}@{img.Width}_{img.Height}.webp");
                        break;
                }
            }
        }

        private void trbZoom_ValueChanged(object sender, EventArgs e)
        {
            zoomW = 256 / trbZoom.Value;
            zoomH = 256 / trbZoom.Value;
        }

        private void PicPvw_MouseMove(object sender, MouseEventArgs e)
        {
            imgZoom = new Bitmap(256, 256);
            using (var g = Graphics.FromImage(imgZoom))
            {
                g.DrawImage(imgPvw, new Rectangle(0, 0, 256, 256), new Rectangle(e.X - zoomW / 2, e.Y - zoomH / 2, zoomW, zoomH), GraphicsUnit.Pixel);
                g.DrawLine(Pens.Black, 128, 128 - 10, 128, 128 + 10);
                g.DrawLine(Pens.Black, 128 - 10, 128, 128 + 10, 128);
            }
            picZoom.Refresh();
        }

        private void PicPvw_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && CheckDropFile(e))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void PicPvw_DragOver(object sender, DragEventArgs e)
        {
            thbX = picPvw.PointToClient(MousePosition).X - 64;
            thbY = picPvw.PointToClient(MousePosition).Y - 64;
            picPvw.Refresh();
        }

        private void PicPvw_DragDrop(object sender, DragEventArgs e)
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            string ext = Path.GetExtension(file).ToLower();
            if (ext == ".ico" || ext == ".exe" || ext == ".dll")
                imgIco = ImageFormator.GetIconImage(file, 0);
            else
                imgIco = ImageFormator.PreviewImage(ImageFormator.GetPictureImage(file), 512, 512, rdoScale.Checked);
            imgThn = new Bitmap(128, 128);
            imgPvw = new Bitmap(512, 512);
            using (var g = Graphics.FromImage(imgPvw))
            {
                g.DrawImage(imgIco, new Point((512 - imgIco.Width) / 2, (512 - imgIco.Height) / 2));
            }
            picPvw.Refresh();
            chkPixel.Enabled = true;
            btnSaveIco.Enabled = true;
        }

        private void PicPvw_DragLeave(object sender, EventArgs e)
        {
            imgThn = new Bitmap(128, 128);
            picPvw.Refresh();
        }

        private bool CheckDropFile(DragEventArgs e)
        {
            bool isImage;
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            string ext = Path.GetExtension(file).ToLower();
            try
            {
                if (ext == ".ico" || ext == ".exe" || ext == ".dll")
                    imgThn = ImageFormator.ThumbnailImage(ImageFormator.GetIconImage(file, 0), 128, 128);
                else
                    imgThn = ImageFormator.ThumbnailImage(ImageFormator.GetPictureImage(file), 128, 128);
                isImage = true;
            }
            catch { isImage = false; }
            return isImage;
        }

        private bool PrepareIcons(Bitmap bmp)
        {
            imgIcos = new List<Bitmap>();
            bool isReady = false;
            foreach (CheckBox chk in grpSize.Controls)
            {
                if (chk.Checked)
                {
                    int size = Convert.ToInt32(chk.Text);
                    imgIcos.Add(new Bitmap(bmp, size, size));
                    isReady = true;
                }
            }
            return isReady;
        }
    }
}