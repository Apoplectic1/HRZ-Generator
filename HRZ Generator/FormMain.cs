using HRZ_Generator.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HRZ_Generator
{
    public partial class FormMain : Form
    {
        private OpenFileDialog mOpenPanoramaFileDialog = new System.Windows.Forms.OpenFileDialog();
        private string mOpenFilePath = string.Empty;
        private SaveFileDialog mSaveHorizonFile = new SaveFileDialog();
        private string mSaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Software Bisque\TheSkyX Professional Edition";
        private string mPanoramaFileName;
        private Bitmap mPhotoBitmap = null;
        private Bitmap mTansparencyBitmap = null;
        private Bitmap mSkyLineBitmap = null;
        private int mTransparencyTolerance = 20;
        private PictureBox mPanoramaPictureBox;
        private int[] mHorizonData = null;
        private bool mBoolShowSkyHorizonLine;
        private double mTheSkyXTopAltitude = 60.0;
        private double mTheSkyXBottomAltitude = -60.0;
        private double mTheSkyXLeftRightAzimuth = 0.0;
        private Timer mScrollTimer = null;
        private byte[] mPanoramaImagePixels = null;

        public FormMain()
        {
            InitializeComponent();

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                Version version = ad.CurrentVersion;
                Text = "The SkyX Horizon Tool - Version: " + version.ToString();
            }
            else
            {
                Text = "The SkyX Horizon Tool - Version: " + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString("yyyy.MM.dd - HHMM");
            }
        }
        void MainForm_Load(object sender, EventArgs e)
        {
            RecallUiPersistanceStates();

            ToolTip ToolTips = new ToolTip();
            ToolTips.IsBalloon = false;
            ToolTips.AutoPopDelay = 20000;
            ToolTips.InitialDelay = 1500;

            ToolTips.SetToolTip(ButtonBrowse, "Select an image to be used as the The SkyX Horizon Photograph.\n\n" +
                "Browse to the directory which contains any four channel 360 degree panoramic image (ARGB) that uses alpha channel transparency.\n\n" +
                "The SkyX requires horizon images to be whole multiples of 512 pixels wide. Image height is arbitrary.\n\n" +
                "The selected image is limited to the .png, .jpg and .tiff container types and must be supported by The SkyX. Monochrome images are not currently supported.");

            ToolTips.SetToolTip(TrackBarTransparencyTolerance, "" +
                "Use this TrackBar to adjust the source panoramic image transparency threshold.\n\n" +
                "This TrackBar is intended to be used to ignore low, but non-zero alpha channel transparency values.\n" +
                "Nearly transparent pixels commonly appear as blooming at the transition of transparent sky to opaque terrain.\n\n" +
                "Aplha channel values above the TrackBar value will be considered to be transparent.");
        }
        private void FormMain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            SaveUiPersistanceStates();
        }

        void SaveUiPersistanceStates()
        {
            Settings.Default.Persist_SkyXLeftRightAzimuth = mTheSkyXLeftRightAzimuth;
            Settings.Default.Persist_SkyXTopAltitude = mTheSkyXTopAltitude;
            Settings.Default.Pesist_SkyXBottomAltitude = mTheSkyXBottomAltitude;
            Settings.Default.Persist_TransparencyTolerance = mTransparencyTolerance;
            Settings.Default.Persist_OpenFilePath = mOpenFilePath;
            Settings.Default.Persist_SaveFilePath = mSaveFilePath;
            Settings.Default.Save();
        }
        void RecallUiPersistanceStates()
        {
            mTheSkyXLeftRightAzimuth = Settings.Default.Persist_SkyXLeftRightAzimuth;
            mTheSkyXTopAltitude = Settings.Default.Persist_SkyXTopAltitude;
            mTheSkyXBottomAltitude = Settings.Default.Pesist_SkyXBottomAltitude;
            mTransparencyTolerance = Settings.Default.Persist_TransparencyTolerance;
            mOpenFilePath = Settings.Default.Persist_OpenFilePath;
            mSaveFilePath = Settings.Default.Persist_SaveFilePath;

            TextBoxTheSkyXLeftRightAzimuth.Text = mTheSkyXLeftRightAzimuth.ToString("F1");
            TextBoxTheSkyXTopAltitude.Text = mTheSkyXTopAltitude.ToString("F1");
            TextBoxTheSkyXBottomAltitude.Text = mTheSkyXBottomAltitude.ToString("F1");
            TrackBarTransparencyTolerance.Value = Convert.ToInt32(mTransparencyTolerance);
        }

        private void TrackBarTolerance_Scroll(object sender, EventArgs e)
        {
            if (mScrollTimer == null)
            {
                // Will tick every 500ms (change as required)
                mScrollTimer = new Timer()
                {
                    Enabled = false,
                    Interval = 30,
                    Tag = (sender as TrackBar).Value
                };

                mScrollTimer.Tick += (s, ea) =>
                {
                    // check to see if the value has changed since we last ticked
                    if (TrackBarTransparencyTolerance.Value == (int)mScrollTimer.Tag)
                    {
                        // scrolling has stopped so we are good to go ahead and do stuff
                        mScrollTimer.Stop();

                        if (RadioButtonPanoImageTransparency.Checked)
                        {
                            mBoolShowSkyHorizonLine = false;
                            FindHorizon(mTansparencyBitmap);
                            panel1.BackgroundImage = mTansparencyBitmap;
                            panel1.Invalidate(false);
                        }

                        //if (RadioButtonPanoImageSkyHorizon.Checked)
                        //{
                        //    mBoolShowSkyHorizonLine = true;
                        //    FindHorizon(mSkyLineBitmap);
                        //    panel1.BackgroundImage = mSkyLineBitmap;
                        //    panel1.Invalidate(false);
                        //}

                        mScrollTimer.Dispose();
                        mScrollTimer = null;
                    }
                    else
                    {
                        // record the last value seen
                        mTransparencyTolerance = TrackBarTransparencyTolerance.Value;
                        mScrollTimer.Tag = TrackBarTransparencyTolerance.Value;
                    }
                };

                mScrollTimer.Start();
            }
        }

        private void ButtonWriteHRZ_Click(object sender, EventArgs e)
        {
            mSaveHorizonFile.FileName = "Custom Horizon.hrz";
            mSaveHorizonFile.Filter = "Horizon files (*.hrz)|*.hrz|All files (*.*)|*.*";
            mSaveHorizonFile.InitialDirectory = mSaveFilePath;

            if (mSaveHorizonFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            mSaveFilePath = Path.GetDirectoryName(mSaveHorizonFile.FileName);

            string path = Path.GetFullPath(mSaveHorizonFile.FileName);

            string text;

            int max;
            double maxAltitude;
            double degreeSpan;
            int columnStart;
            int columnStop;
            double degreeColumnStart;
            double degreeColumnStop;

            int[] doubleHorizon = new int[mPhotoBitmap.Width * 2];

            for (int x = 0; x < mPhotoBitmap.Width; x++)
            {
                doubleHorizon[x] = mHorizonData[x];

            }
            for (int x = mPhotoBitmap.Width; x < mPhotoBitmap.Width * 2; x++)
            {
                doubleHorizon[x] = mHorizonData[x - mPhotoBitmap.Width];
            }


            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("360");

                degreeSpan = mPhotoBitmap.Width / 360.0;

                mTheSkyXLeftRightAzimuth = ((int)Math.Round(mTheSkyXLeftRightAzimuth) == 0) ? 360 : mTheSkyXLeftRightAzimuth;

                degreeColumnStart = (360 - mTheSkyXLeftRightAzimuth) * degreeSpan;

                int panoramaDegreeStart = (int)Math.Round(360 - mTheSkyXLeftRightAzimuth);
                int panoramaDegreeStop = panoramaDegreeStart + 360;

                for (int degree = panoramaDegreeStart; degree < panoramaDegreeStop; degree++)
                {
                    degreeColumnStop = (degree * degreeSpan) + degreeSpan;

                    columnStart = (int)Math.Floor(degreeColumnStart);
                    columnStop = (int)Math.Floor(degreeColumnStop);

                    max = 1000000;
                    while (columnStart <= columnStop)
                    {
                        max = (doubleHorizon[columnStart] < max) ? doubleHorizon[columnStart] : max;
                        columnStart++;
                    }

                    degreeColumnStart = degreeColumnStop;

                    maxAltitude = Interpolate(max, 0, mPhotoBitmap.Height, mTheSkyXTopAltitude, mTheSkyXBottomAltitude);

                    text = string.Format("{0,8:##.00}", maxAltitude);
                    file.WriteLine(text);
                }
            }
        }
        public Bitmap Copy32BPPBitmapSafe(Bitmap srcBitmap)
        {
            Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, PixelFormat.Format32bppArgb);

            Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);
            BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);
            BitmapData resData = result.LockBits(bmpBounds, ImageLockMode.WriteOnly, result.PixelFormat);

            Int64 srcScan0 = srcData.Scan0.ToInt64();
            Int64 resScan0 = resData.Scan0.ToInt64();
            int srcStride = srcData.Stride;
            int resStride = resData.Stride;
            int rowLength = Math.Abs(srcData.Stride);
            try
            {
                byte[] buffer = new byte[rowLength];
                for (int y = 0; y < srcData.Height; y++)
                {
                    Marshal.Copy(new IntPtr(srcScan0 + y * srcStride), buffer, 0, rowLength);
                    Marshal.Copy(buffer, 0, new IntPtr(resScan0 + y * resStride), rowLength);
                }
            }
            finally
            {
                srcBitmap.UnlockBits(srcData);
                result.UnlockBits(resData);
            }

            return result;
        }
        
        private void FindHorizon(Bitmap destinationBitmap)
        {
            int height;
            int width;
            int size;

            height = mPhotoBitmap.Height;
            width = mPhotoBitmap.Width;

            mHorizonData = new int[width];


            int stride = width * 4;

            size = width * height * 4;

            byte[] pixels = new byte[size];

            Console.WriteLine("Tolerance: " + mTransparencyTolerance.ToString() + " Show Sky Horizon Line: " + mBoolShowSkyHorizonLine.ToString());

            for (int x = 0; x < width; x++)
            {
                bool bFound = false;
                int columnAddress;

                columnAddress = x << 2;

                for (int y = 0; y < height; y++)
                {
                    
                    if (mPanoramaImagePixels[columnAddress + 3] > mTransparencyTolerance)
                    {
                        if (mBoolShowSkyHorizonLine)
                        {
                            if (bFound == false)
                            {
                                // Find the non-transparent pixels in the x-column - Set bFound when we find the first one 
                                pixels[columnAddress + 3] = 255;
                                pixels[columnAddress + 2] = 255;
                                pixels[columnAddress + 1] = 0;
                                pixels[columnAddress] = 0;
                                pixels[columnAddress - stride + 3] = 255;
                                pixels[columnAddress - stride + 2] = 255;
                                pixels[columnAddress - stride + 1] = 0;
                                pixels[columnAddress - stride] = 0;
                                pixels[columnAddress - stride - stride + 3] = 255;
                                pixels[columnAddress - stride - stride + 2] = 255;
                                pixels[columnAddress - stride - stride + 1] = 0;
                                pixels[columnAddress - stride] = 0;

                                mHorizonData[x] = y;
                                bFound = true;
                            }
                            else
                            {
                                pixels[columnAddress + 3] = 255;
                                pixels[columnAddress + 2] = 0;
                                pixels[columnAddress + 1] = 0;
                                pixels[columnAddress] = 0;
                            }
                        }
                        else
                        {
                            // Find the non-transparent pixels in the x-column - Set bFound when we find the first one 
                            pixels[columnAddress + 3] = 255;
                            pixels[columnAddress + 2] = 255;
                            pixels[columnAddress + 1] = 0;
                            pixels[columnAddress] = 0;

                            if (bFound == false)
                            {
                                mHorizonData[x] = y;
                                bFound = true;
                            }
                        }
                    }
                    else
                    {
                        // These x-column pixels are transparent
                        pixels[columnAddress + 3] = 255;
                        pixels[columnAddress + 2] = 0;
                        pixels[columnAddress + 1] = 0;
                        pixels[columnAddress] = 0;
                    }



                    columnAddress += stride;

                }
            }

            // the formBitmap will be updated with the transparency check values
            BitmapData destinationBitmapData = destinationBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, destinationBitmap.PixelFormat);
            IntPtr destinationPointer = destinationBitmapData.Scan0;

            Marshal.Copy(pixels, 0, destinationPointer, size);

            destinationBitmap.UnlockBits(destinationBitmapData);
        }

        private void CreateBitmaps()
        {
            mPhotoBitmap = new Bitmap(mPanoramaFileName);

            // Copy the original image to the byte array
            BitmapData panoramaBitmapData = mPhotoBitmap.LockBits(new Rectangle(0, 0, mPhotoBitmap.Width, mPhotoBitmap.Height), ImageLockMode.ReadOnly, mPhotoBitmap.PixelFormat);
            IntPtr panoramaPointer = panoramaBitmapData.Scan0;
            int size = Math.Abs(panoramaBitmapData.Stride) * mPhotoBitmap.Height;
            mPanoramaImagePixels = new byte[size];
            Marshal.Copy(panoramaPointer, mPanoramaImagePixels, 0, size);
            mPhotoBitmap.UnlockBits(panoramaBitmapData);

            mSkyLineBitmap = new Bitmap(mPhotoBitmap.Width, mPhotoBitmap.Height);
            mBoolShowSkyHorizonLine = true;
            FindHorizon(mSkyLineBitmap);

            mTansparencyBitmap = new Bitmap(mPhotoBitmap.Width, mPhotoBitmap.Height);
            mBoolShowSkyHorizonLine = false;
            FindHorizon(mTansparencyBitmap);

            


            //mFormBitmap = new Bitmap(mPanoramaFileName);
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            mOpenPanoramaFileDialog.InitialDirectory = mOpenFilePath;
            DialogResult result = mOpenPanoramaFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                mPanoramaFileName = mOpenPanoramaFileDialog.FileName;
                mOpenFilePath = Path.GetDirectoryName(mOpenPanoramaFileDialog.FileName);

                panel1.BackgroundImage = Image.FromFile(mPanoramaFileName);

                CreateBitmaps();

                mPanoramaPictureBox = new PictureBox();
                mPanoramaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;


                if (mPhotoBitmap.Width % 512 != 0)
                {
                    MessageBox.Show("The horizon file must be minimum of, and a multiple of 512 pixels wide.\n\n" +
                        "This file is " + mPhotoBitmap.Width + " pixels wide by " + mPhotoBitmap.Height + " pixels high.\n\n" +
                        "Please select a different file.\n\n", "Horizon File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    GroupBoxTolerance.Enabled = false;
                    GroupBoxTheSkyX.Enabled = false;
                    ButtonWriteHRZ.Enabled = false;
                    return;
                }

                GroupBoxTolerance.Enabled = true;
                GroupBoxTheSkyX.Enabled = true;
                ButtonWriteHRZ.Enabled = true;

            }
        }


        private void TextBoxTheSkyXTopAltitude_TextChanged(object sender, EventArgs e)
        {
            string formattedString;
            double value;
            bool status;

            formattedString = TextBoxTheSkyXTopAltitude.Text;
            status = Double.TryParse(formattedString, out value);

            formattedString = value.ToString("F1");

            if (status)
            {
                //TextBoxTheSkyXTopAltitude.Text = formattedString;
                mTheSkyXTopAltitude = value;
            }
        }

        private void TextBoxTheSkyXBottomAltitude_TextChanged(object sender, EventArgs e)
        {
            string formattedString;
            double value;
            bool status;

            formattedString = TextBoxTheSkyXBottomAltitude.Text;
            status = Double.TryParse(formattedString, out value);

            formattedString = value.ToString("F1");

            if (status)
            {
                //TextBoxTheSkyXBottomAltitude.Text = formattedString;
                mTheSkyXBottomAltitude = value;
            }
        }

        private void TextBoxTheSkyXLeftRightAzimuth_TextChanged(object sender, EventArgs e)
        {
            string formattedString;
            double value;
            bool status;

            formattedString = TextBoxTheSkyXLeftRightAzimuth.Text;
            status = Double.TryParse(formattedString, out value);

            if (status)
            {
                //TextBoxTheSkyXLeftRightAzimuth.Text = value.ToString("F1");
                mTheSkyXLeftRightAzimuth = value;
            }
        }

        private void ButtonTheSkyXCalculate_Click(object sender, EventArgs e)
        {
            if (RadioButtonPanoImagePhoto.Checked)
            {
                DrawEquatorialLines(mPhotoBitmap);
                panel1.BackgroundImage = mPhotoBitmap;
            }

            if (RadioButtonPanoImageTransparency.Checked)
            {
                DrawEquatorialLines(mTansparencyBitmap);
                panel1.BackgroundImage = mTansparencyBitmap;
            }

            if (RadioButtonPanoImageSkyHorizon.Checked)
            {
                DrawEquatorialLines(mSkyLineBitmap);
                panel1.BackgroundImage = mSkyLineBitmap;
            }

            panel1.Invalidate(false);

            return;



            double zeroDegreePixelRow;

            zeroDegreePixelRow = Interpolate(0, mTheSkyXBottomAltitude, mTheSkyXTopAltitude, mPhotoBitmap.Height, 0);
            zeroDegreePixelRow = Math.Round(zeroDegreePixelRow);

            for (int x = 0; x < mTansparencyBitmap.Width; x++)
            {
                mTansparencyBitmap.SetPixel(x, (int)zeroDegreePixelRow, Color.White);
                mTansparencyBitmap.SetPixel(x, (int)zeroDegreePixelRow - 1, Color.White);
            }

            using (Graphics g = Graphics.FromImage(mTansparencyBitmap))
            {
                g.DrawString("Horizon", new Font("Tahoma", 36), Brushes.White, mTansparencyBitmap.Width >> 1, (float)zeroDegreePixelRow);
            }

            double merdianDegrees = (Math.Round(mTheSkyXLeftRightAzimuth) < 1) ? 360 : mTheSkyXLeftRightAzimuth;


            int meridainColumn = (int)Math.Round(Interpolate(360 - mTheSkyXLeftRightAzimuth, 0, 360, 0, mTansparencyBitmap.Width - 1));



            if (meridainColumn == 0)
            {
                mTansparencyBitmap.SetPixel(meridainColumn, 0, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn, 1, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn, 2, Color.White);
            }

            if (meridainColumn == mTansparencyBitmap.Width - 1)
            {
                mTansparencyBitmap.SetPixel(meridainColumn, mTansparencyBitmap.Width - 2, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn, mTansparencyBitmap.Width - 1, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn, mTansparencyBitmap.Width, Color.White);
            }

            for (int y = 0; y < mTansparencyBitmap.Height; y++)
            {
                mTansparencyBitmap.SetPixel(meridainColumn, y, Color.White);

                if (meridainColumn == 0)
                {
                    mTansparencyBitmap.SetPixel(meridainColumn, y, Color.White);
                    mTansparencyBitmap.SetPixel(meridainColumn + 1, y, Color.White);
                    mTansparencyBitmap.SetPixel(meridainColumn + 2, y, Color.White);
                    continue;
                }

                if (meridainColumn == mTansparencyBitmap.Width - 1)
                {
                    mTansparencyBitmap.SetPixel(meridainColumn - 3, y, Color.White);
                    mTansparencyBitmap.SetPixel(meridainColumn - 2, y, Color.White);
                    mTansparencyBitmap.SetPixel(meridainColumn - 1, y, Color.White);
                    continue;
                }

                mTansparencyBitmap.SetPixel(meridainColumn - 1, y, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn - 0, y, Color.White);
                mTansparencyBitmap.SetPixel(meridainColumn + 1, y, Color.White);
            }

            if (meridainColumn < 30)
            {
                using (Graphics g = Graphics.FromImage(mTansparencyBitmap))
                {
                    g.DrawString("Meridian", new Font("Tahoma", 36), Brushes.White, meridainColumn, (float)mTansparencyBitmap.Height - 10);
                }
            }
            else if (meridainColumn < mTansparencyBitmap.Width - 1 - 30)
            {
                using (Graphics g = Graphics.FromImage(mTansparencyBitmap))
                {
                    g.DrawString("Meridian", new Font("Tahoma", 36), Brushes.White, meridainColumn, (float)mTansparencyBitmap.Height - 10);
                }
            }
            else
            {
                using (Graphics g = Graphics.FromImage(mTansparencyBitmap))
                {
                    g.DrawString("Meridian", new Font("Tahoma", 36), Brushes.White, meridainColumn, (float)mTansparencyBitmap.Height - 10);
                }
            }




            mPanoramaPictureBox.Refresh();

            ButtonWriteHRZ.Enabled = true;
        }

        private double Interpolate(double x, double inMin, double inMax, double outMin, double outMax)
        {
            x = (x < inMin) ? inMin : x;
            x = (x > inMax) ? inMax : x;

            x = outMin + (outMax - outMin) * ((x - inMin) / (inMax - inMin));
            return x;

        }



        private void OpenPanoramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = mOpenPanoramaFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                mPanoramaFileName = mOpenPanoramaFileDialog.FileName;
                mPhotoBitmap = new Bitmap(mPanoramaFileName);
                mTansparencyBitmap = new Bitmap(mPanoramaFileName);

                mPanoramaPictureBox = new PictureBox();
                mPanoramaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                mPanoramaPictureBox.Dock = DockStyle.Fill;
                mPanoramaPictureBox.Image = mTansparencyBitmap;
                Controls.Add(mPanoramaPictureBox);

                if (mPhotoBitmap.Width % 512 != 0)
                {
                    MessageBox.Show("The horizon file must be a multiple of 512 pixels wide.\n\n" +
                        "This file is " + mPhotoBitmap.Width + " pixels wide by " + mPhotoBitmap.Height + " pixels high.\n\n" +
                        "Please select a different file.\n\n", "Horizon File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    GroupBoxTolerance.Enabled = false;
                    GroupBoxTheSkyX.Enabled = false;
                    ButtonWriteHRZ.Enabled = false;
                    return;
                }

                GroupBoxTolerance.Enabled = true;
                GroupBoxTheSkyX.Enabled = true;
                ButtonWriteHRZ.Enabled = false;

            }
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SetDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mTheSkyXLeftRightAzimuth = 0;
            mTheSkyXTopAltitude = 60;
            mTheSkyXBottomAltitude = -60;
            mTransparencyTolerance = 20;

            TextBoxTheSkyXLeftRightAzimuth.Text = mTheSkyXLeftRightAzimuth.ToString("F1");
            TextBoxTheSkyXTopAltitude.Text = mTheSkyXTopAltitude.ToString("F1");
            TextBoxTheSkyXBottomAltitude.Text = mTheSkyXBottomAltitude.ToString("F1");
            TrackBarTransparencyTolerance.Value = Convert.ToInt32(mTransparencyTolerance);
        }

        private void RadioButtonShowPhoto_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadioButtonPanoImagePhoto.Checked)
            {
                return;
            }

            panel1.BackgroundImage = mPhotoBitmap;
        }

        private void RadioButtonShowTransparency_CheckedChanged(object sender, EventArgs e)
        {

            if (!RadioButtonPanoImageTransparency.Checked)
            {
                return;
            }

            panel1.BackgroundImage = mTansparencyBitmap;
        }

        private void RadioButtonShowSkyHorizon_CheckedChanged(object sender, EventArgs e)
        {
            if (!RadioButtonPanoImageSkyHorizon.Checked)
            {
                return;
            }

            panel1.BackgroundImage = mSkyLineBitmap;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void RadioButtonHorizonImageHide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DrawEquatorialLines(Bitmap destinationBitmap)
        {
            double zeroDegreePixelRow;

            zeroDegreePixelRow = Interpolate(0, mTheSkyXBottomAltitude, mTheSkyXTopAltitude, mPhotoBitmap.Height, 0);
            zeroDegreePixelRow = Math.Round(zeroDegreePixelRow);

            using (Graphics g = Graphics.FromImage(destinationBitmap))
            {
                Pen pen = new Pen(Color.FromArgb(255, 255, 255, 255), 2);
                g.DrawLine(pen, 0, (float)zeroDegreePixelRow, destinationBitmap.Width, (float)zeroDegreePixelRow);

                g.DrawString("Horizon", new Font("Tahoma", 36), Brushes.White, destinationBitmap.Width >> 1, (float)zeroDegreePixelRow);
            }
        }
    }
}
