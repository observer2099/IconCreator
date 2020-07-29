namespace IconCreator
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnSaveIco = new System.Windows.Forms.Button();
            this.picPvw = new System.Windows.Forms.PictureBox();
            this.btnOpenImg = new System.Windows.Forms.Button();
            this.rdoCenter = new System.Windows.Forms.RadioButton();
            this.rdoScale = new System.Windows.Forms.RadioButton();
            this.grpScale = new System.Windows.Forms.GroupBox();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.chk512 = new System.Windows.Forms.CheckBox();
            this.chk256 = new System.Windows.Forms.CheckBox();
            this.chk128 = new System.Windows.Forms.CheckBox();
            this.chk64 = new System.Windows.Forms.CheckBox();
            this.chk48 = new System.Windows.Forms.CheckBox();
            this.chk32 = new System.Windows.Forms.CheckBox();
            this.chk24 = new System.Windows.Forms.CheckBox();
            this.chk16 = new System.Windows.Forms.CheckBox();
            this.btnOpenIcon = new System.Windows.Forms.Button();
            this.grpPixel = new System.Windows.Forms.GroupBox();
            this.rdo64 = new System.Windows.Forms.RadioButton();
            this.rdo16 = new System.Windows.Forms.RadioButton();
            this.rdo32 = new System.Windows.Forms.RadioButton();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo4 = new System.Windows.Forms.RadioButton();
            this.rdo8 = new System.Windows.Forms.RadioButton();
            this.picZoom = new System.Windows.Forms.PictureBox();
            this.trbZoom = new System.Windows.Forms.TrackBar();
            this.chkPixel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPvw)).BeginInit();
            this.grpScale.SuspendLayout();
            this.grpSize.SuspendLayout();
            this.grpPixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveIco
            // 
            this.btnSaveIco.Enabled = false;
            this.btnSaveIco.Location = new System.Drawing.Point(530, 469);
            this.btnSaveIco.Name = "btnSaveIco";
            this.btnSaveIco.Size = new System.Drawing.Size(75, 23);
            this.btnSaveIco.TabIndex = 0;
            this.btnSaveIco.Text = "Save Icon";
            this.btnSaveIco.Click += new System.EventHandler(this.BtnSaveIco_Click);
            // 
            // picPvw
            // 
            this.picPvw.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPvw.Location = new System.Drawing.Point(12, 12);
            this.picPvw.Name = "picPvw";
            this.picPvw.Size = new System.Drawing.Size(512, 512);
            this.picPvw.TabIndex = 2;
            this.picPvw.TabStop = false;
            this.picPvw.DragDrop += new System.Windows.Forms.DragEventHandler(this.PicPvw_DragDrop);
            this.picPvw.DragEnter += new System.Windows.Forms.DragEventHandler(this.PicPvw_DragEnter);
            this.picPvw.DragOver += new System.Windows.Forms.DragEventHandler(this.PicPvw_DragOver);
            this.picPvw.DragLeave += new System.EventHandler(this.PicPvw_DragLeave);
            this.picPvw.Paint += new System.Windows.Forms.PaintEventHandler(this.PicPvw_Paint);
            this.picPvw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPvw_MouseMove);
            // 
            // btnOpenImg
            // 
            this.btnOpenImg.Location = new System.Drawing.Point(530, 325);
            this.btnOpenImg.Name = "btnOpenImg";
            this.btnOpenImg.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImg.TabIndex = 3;
            this.btnOpenImg.Text = "Open Image";
            this.btnOpenImg.UseVisualStyleBackColor = true;
            this.btnOpenImg.Click += new System.EventHandler(this.BtnOpenImg_Click);
            // 
            // rdoCenter
            // 
            this.rdoCenter.AutoSize = true;
            this.rdoCenter.Location = new System.Drawing.Point(64, 19);
            this.rdoCenter.Name = "rdoCenter";
            this.rdoCenter.Size = new System.Drawing.Size(56, 17);
            this.rdoCenter.TabIndex = 4;
            this.rdoCenter.Text = "Center";
            this.rdoCenter.UseVisualStyleBackColor = true;
            // 
            // rdoScale
            // 
            this.rdoScale.AutoSize = true;
            this.rdoScale.Checked = true;
            this.rdoScale.Location = new System.Drawing.Point(6, 19);
            this.rdoScale.Name = "rdoScale";
            this.rdoScale.Size = new System.Drawing.Size(52, 17);
            this.rdoScale.TabIndex = 5;
            this.rdoScale.TabStop = true;
            this.rdoScale.Text = "Scale";
            this.rdoScale.UseVisualStyleBackColor = true;
            // 
            // grpScale
            // 
            this.grpScale.Controls.Add(this.rdoScale);
            this.grpScale.Controls.Add(this.rdoCenter);
            this.grpScale.Location = new System.Drawing.Point(611, 325);
            this.grpScale.Name = "grpScale";
            this.grpScale.Size = new System.Drawing.Size(130, 52);
            this.grpScale.TabIndex = 6;
            this.grpScale.TabStop = false;
            this.grpScale.Text = "Scale";
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.chk512);
            this.grpSize.Controls.Add(this.chk256);
            this.grpSize.Controls.Add(this.chk128);
            this.grpSize.Controls.Add(this.chk64);
            this.grpSize.Controls.Add(this.chk48);
            this.grpSize.Controls.Add(this.chk32);
            this.grpSize.Controls.Add(this.chk24);
            this.grpSize.Controls.Add(this.chk16);
            this.grpSize.Location = new System.Drawing.Point(611, 454);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(175, 70);
            this.grpSize.TabIndex = 7;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Size";
            // 
            // chk512
            // 
            this.chk512.AutoSize = true;
            this.chk512.Location = new System.Drawing.Point(126, 42);
            this.chk512.Name = "chk512";
            this.chk512.Size = new System.Drawing.Size(44, 17);
            this.chk512.TabIndex = 0;
            this.chk512.Text = "512";
            this.chk512.UseVisualStyleBackColor = true;
            // 
            // chk256
            // 
            this.chk256.AutoSize = true;
            this.chk256.Checked = true;
            this.chk256.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk256.Location = new System.Drawing.Point(86, 42);
            this.chk256.Name = "chk256";
            this.chk256.Size = new System.Drawing.Size(44, 17);
            this.chk256.TabIndex = 1;
            this.chk256.Text = "256";
            this.chk256.UseVisualStyleBackColor = true;
            // 
            // chk128
            // 
            this.chk128.AutoSize = true;
            this.chk128.Location = new System.Drawing.Point(46, 42);
            this.chk128.Name = "chk128";
            this.chk128.Size = new System.Drawing.Size(44, 17);
            this.chk128.TabIndex = 2;
            this.chk128.Text = "128";
            this.chk128.UseVisualStyleBackColor = true;
            // 
            // chk64
            // 
            this.chk64.AutoSize = true;
            this.chk64.Location = new System.Drawing.Point(6, 42);
            this.chk64.Name = "chk64";
            this.chk64.Size = new System.Drawing.Size(38, 17);
            this.chk64.TabIndex = 3;
            this.chk64.Text = "64";
            this.chk64.UseVisualStyleBackColor = true;
            // 
            // chk48
            // 
            this.chk48.AutoSize = true;
            this.chk48.Checked = true;
            this.chk48.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk48.Location = new System.Drawing.Point(126, 19);
            this.chk48.Name = "chk48";
            this.chk48.Size = new System.Drawing.Size(38, 17);
            this.chk48.TabIndex = 4;
            this.chk48.Text = "48";
            this.chk48.UseVisualStyleBackColor = true;
            // 
            // chk32
            // 
            this.chk32.AutoSize = true;
            this.chk32.Checked = true;
            this.chk32.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk32.Location = new System.Drawing.Point(86, 19);
            this.chk32.Name = "chk32";
            this.chk32.Size = new System.Drawing.Size(38, 17);
            this.chk32.TabIndex = 5;
            this.chk32.Text = "32";
            this.chk32.UseVisualStyleBackColor = true;
            // 
            // chk24
            // 
            this.chk24.AutoSize = true;
            this.chk24.Location = new System.Drawing.Point(46, 19);
            this.chk24.Name = "chk24";
            this.chk24.Size = new System.Drawing.Size(38, 17);
            this.chk24.TabIndex = 6;
            this.chk24.Text = "24";
            this.chk24.UseVisualStyleBackColor = true;
            // 
            // chk16
            // 
            this.chk16.AutoSize = true;
            this.chk16.Checked = true;
            this.chk16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk16.Location = new System.Drawing.Point(6, 19);
            this.chk16.Name = "chk16";
            this.chk16.Size = new System.Drawing.Size(38, 17);
            this.chk16.TabIndex = 7;
            this.chk16.Text = "16";
            this.chk16.UseVisualStyleBackColor = true;
            // 
            // btnOpenIcon
            // 
            this.btnOpenIcon.Location = new System.Drawing.Point(530, 354);
            this.btnOpenIcon.Name = "btnOpenIcon";
            this.btnOpenIcon.Size = new System.Drawing.Size(75, 23);
            this.btnOpenIcon.TabIndex = 8;
            this.btnOpenIcon.Text = "Open Icon";
            this.btnOpenIcon.UseVisualStyleBackColor = true;
            this.btnOpenIcon.Click += new System.EventHandler(this.BtnOpenIcon_Click);
            // 
            // grpPixel
            // 
            this.grpPixel.Controls.Add(this.rdo64);
            this.grpPixel.Controls.Add(this.rdo16);
            this.grpPixel.Controls.Add(this.rdo32);
            this.grpPixel.Controls.Add(this.rdo2);
            this.grpPixel.Controls.Add(this.rdo4);
            this.grpPixel.Controls.Add(this.rdo8);
            this.grpPixel.Enabled = false;
            this.grpPixel.Location = new System.Drawing.Point(530, 406);
            this.grpPixel.Name = "grpPixel";
            this.grpPixel.Size = new System.Drawing.Size(256, 42);
            this.grpPixel.TabIndex = 10;
            this.grpPixel.TabStop = false;
            this.grpPixel.Text = "Pixel";
            // 
            // rdo64
            // 
            this.rdo64.AutoSize = true;
            this.rdo64.Location = new System.Drawing.Point(215, 19);
            this.rdo64.Name = "rdo64";
            this.rdo64.Size = new System.Drawing.Size(37, 17);
            this.rdo64.TabIndex = 5;
            this.rdo64.Text = "64";
            this.rdo64.UseVisualStyleBackColor = true;
            this.rdo64.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // rdo16
            // 
            this.rdo16.AutoSize = true;
            this.rdo16.Location = new System.Drawing.Point(129, 19);
            this.rdo16.Name = "rdo16";
            this.rdo16.Size = new System.Drawing.Size(37, 17);
            this.rdo16.TabIndex = 5;
            this.rdo16.Text = "16";
            this.rdo16.UseVisualStyleBackColor = true;
            this.rdo16.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // rdo32
            // 
            this.rdo32.AutoSize = true;
            this.rdo32.Location = new System.Drawing.Point(170, 19);
            this.rdo32.Name = "rdo32";
            this.rdo32.Size = new System.Drawing.Size(37, 17);
            this.rdo32.TabIndex = 8;
            this.rdo32.Text = "32";
            this.rdo32.UseVisualStyleBackColor = true;
            this.rdo32.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Location = new System.Drawing.Point(6, 19);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(31, 17);
            this.rdo2.TabIndex = 5;
            this.rdo2.Text = "2";
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // rdo4
            // 
            this.rdo4.AutoSize = true;
            this.rdo4.Location = new System.Drawing.Point(47, 19);
            this.rdo4.Name = "rdo4";
            this.rdo4.Size = new System.Drawing.Size(31, 17);
            this.rdo4.TabIndex = 5;
            this.rdo4.Text = "4";
            this.rdo4.UseVisualStyleBackColor = true;
            this.rdo4.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // rdo8
            // 
            this.rdo8.AutoSize = true;
            this.rdo8.Checked = true;
            this.rdo8.Location = new System.Drawing.Point(88, 19);
            this.rdo8.Name = "rdo8";
            this.rdo8.Size = new System.Drawing.Size(31, 17);
            this.rdo8.TabIndex = 8;
            this.rdo8.TabStop = true;
            this.rdo8.Text = "8";
            this.rdo8.UseVisualStyleBackColor = true;
            this.rdo8.Click += new System.EventHandler(this.RdoPixel_Click);
            // 
            // picZoom
            // 
            this.picZoom.Location = new System.Drawing.Point(530, 12);
            this.picZoom.Name = "picZoom";
            this.picZoom.Size = new System.Drawing.Size(256, 256);
            this.picZoom.TabIndex = 12;
            this.picZoom.TabStop = false;
            this.picZoom.Paint += new System.Windows.Forms.PaintEventHandler(this.PicZoom_Paint);
            // 
            // trbZoom
            // 
            this.trbZoom.LargeChange = 1;
            this.trbZoom.Location = new System.Drawing.Point(530, 274);
            this.trbZoom.Maximum = 8;
            this.trbZoom.Minimum = 1;
            this.trbZoom.Name = "trbZoom";
            this.trbZoom.Size = new System.Drawing.Size(256, 45);
            this.trbZoom.TabIndex = 13;
            this.trbZoom.Value = 2;
            this.trbZoom.ValueChanged += new System.EventHandler(this.trbZoom_ValueChanged);
            // 
            // chkPixel
            // 
            this.chkPixel.AutoSize = true;
            this.chkPixel.Enabled = false;
            this.chkPixel.Location = new System.Drawing.Point(535, 383);
            this.chkPixel.Name = "chkPixel";
            this.chkPixel.Size = new System.Drawing.Size(70, 17);
            this.chkPixel.TabIndex = 14;
            this.chkPixel.Text = "Use Pixel";
            this.chkPixel.UseVisualStyleBackColor = true;
            this.chkPixel.Click += new System.EventHandler(this.ChkPixel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 535);
            this.Controls.Add(this.chkPixel);
            this.Controls.Add(this.grpSize);
            this.Controls.Add(this.grpScale);
            this.Controls.Add(this.trbZoom);
            this.Controls.Add(this.picZoom);
            this.Controls.Add(this.grpPixel);
            this.Controls.Add(this.btnOpenIcon);
            this.Controls.Add(this.btnOpenImg);
            this.Controls.Add(this.picPvw);
            this.Controls.Add(this.btnSaveIco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Icon Creator";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPvw)).EndInit();
            this.grpScale.ResumeLayout(false);
            this.grpScale.PerformLayout();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            this.grpPixel.ResumeLayout(false);
            this.grpPixel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIco;
        private System.Windows.Forms.PictureBox picPvw;
        private System.Windows.Forms.Button btnOpenImg;
        private System.Windows.Forms.RadioButton rdoCenter;
        private System.Windows.Forms.RadioButton rdoScale;
        private System.Windows.Forms.GroupBox grpScale;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.CheckBox chk512;
        private System.Windows.Forms.CheckBox chk256;
        private System.Windows.Forms.CheckBox chk128;        
        private System.Windows.Forms.CheckBox chk64;
        private System.Windows.Forms.CheckBox chk48;
        private System.Windows.Forms.CheckBox chk32;
        private System.Windows.Forms.CheckBox chk24;
        private System.Windows.Forms.CheckBox chk16;
        private System.Windows.Forms.Button btnOpenIcon;
        private System.Windows.Forms.GroupBox grpPixel;
        private System.Windows.Forms.RadioButton rdo4;
        private System.Windows.Forms.RadioButton rdo8;
        private System.Windows.Forms.RadioButton rdo64;
        private System.Windows.Forms.RadioButton rdo16;
        private System.Windows.Forms.RadioButton rdo32;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.PictureBox picZoom;
        private System.Windows.Forms.TrackBar trbZoom;
        private System.Windows.Forms.CheckBox chkPixel;
    }
}