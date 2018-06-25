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
        private OpenFileDialog mPanoramaFileDialog = new System.Windows.Forms.OpenFileDialog();
        private string mPanoramaFileName;
        private Bitmap mPanoramaBitmap = null;
        private Bitmap mFormBitmap = null;
        private int mTransparencyTolerance = 20;
        private PictureBox mPanoramaPictureBox;
        private int[] mHorizonData = null;
        private bool mBoolTrackBarToleranceStill = true;
        private bool mBoolShowHorizonLine;

        private double mTheSkyXTopAltitude = 90.0;
        private double mTheSkyXBottomAltitude = -90.0;
        private double mTheSkyXLeftRightAzimuth = 0.0;

        public FormMain()
        {
            InitializeComponent();
        }


        void SaveUiPersistanceStatesInternal()
        {
            Settings.Default.Persist_SkyXLeftRightAzimuth = mTheSkyXLeftRightAzimuth;
            Settings.Default.Persist_SkyXTopAltitude = mTheSkyXTopAltitude;
            Settings.Default.Pesist_SkyXBottomAltitude = mTheSkyXBottomAltitude;
            Settings.Default.Persist_TransparencyTolerance = mTransparencyTolerance;
        }
        void RecallUiPersistanceStatesInternal()
        {
            mTheSkyXLeftRightAzimuth = Settings.Default.Persist_SkyXLeftRightAzimuth;
            mTheSkyXTopAltitude = Settings.Default.Persist_SkyXTopAltitude;
            mTheSkyXBottomAltitude = Settings.Default.Pesist_SkyXBottomAltitude;
            mTransparencyTolerance = Settings.Default.Persist_TransparencyTolerance;
        }

        private void ButtonShowTransparency_Click(object sender, EventArgs e)
        {
            mBoolShowHorizonLine = false;
            FindHorizon();

            GroupBoxTolerance.Enabled = true;
            GroupBoxTheSkyX.Enabled = true;
            ButtonWriteHRZ.Enabled = false;
        }
        private void ButtonShowHorizon_Click(object sender, EventArgs e)
        {
            mBoolShowHorizonLine = true;
            FindHorizon();

            GroupBoxTolerance.Enabled = true;
            GroupBoxTheSkyX.Enabled = true;
            ButtonWriteHRZ.Enabled = false;
        }
        private void TrackBarTolerance_Scroll(object sender, EventArgs e)
        {
            mTransparencyTolerance = trackBar1.Value;
            label4.Text = mTransparencyTolerance.ToString();

            mBoolTrackBarToleranceStill = false;
        }

        private void ButtonWriteHRZ_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveHorizonFile = new SaveFileDialog();
            saveHorizonFile.FileName = "Custom Horizon.hrz";
            saveHorizonFile.Filter = "Horizon files (*.hrz)|*.hrz|All files (*.*)|*.*";
            saveHorizonFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Software Bisque\TheSkyX Professional Edition";

            if (saveHorizonFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string path = Path.GetFullPath(saveHorizonFile.FileName);

            string text;

            int max;
            double maxAltitude;
            double degreeSpan;
            int columnStart;
            int columnStop;
            double degreeColumnStart;
            double degreeColumnStop;

            int[] doubleHorizon = new int[mPanoramaBitmap.Width * 2];

            for (int x = 0; x < mPanoramaBitmap.Width; x++)
            {
                doubleHorizon[x] = mHorizonData[x];

            }
            for (int x = mPanoramaBitmap.Width; x < mPanoramaBitmap.Width * 2; x++)
            {
                doubleHorizon[x] = mHorizonData[x - mPanoramaBitmap.Width];
            }


            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine("360");

                degreeSpan = mPanoramaBitmap.Width / 360.0;

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

                    maxAltitude = Interpolate(max, 0, mPanoramaBitmap.Height, mTheSkyXTopAltitude, mTheSkyXBottomAltitude);

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
        //public Bitmap sCopy32BPPBitmapSafe(Bitmap srourceBitmap, double Azimuth)
        //{

        //    Rectangle sourceRectangle;
        //    Rectangle destinationRectangle;
        //    BitmapData sourceData;
        //    BitmapData destinationData;
        //    Int64 srcScan0;
        //    Int64 resScan0;
        //    int srcStride;
        //    int resStride;
        //    int rowLength;



        //    Bitmap destinationBitmap = new Bitmap(srourceBitmap.Width, srourceBitmap.Height, PixelFormat.Format32bppArgb);

        //    // Convert Degrees to Bitmap Columns - Find the azimuth Degree Column
        //    double azimuthColumn = Interpolate(Azimuth, 0, 359, 0, srourceBitmap.Width);
        //    azimuthColumn = Math.Round(azimuthColumn);

        //    // find the last column that holds degree 359.99999
        //    double lastColumn = Interpolate(359, 0, 359, 0, srourceBitmap.Width);
        //    lastColumn = Math.Round(lastColumn);


        //    // move data in two block transfers

        //    sourceRectangle      = new Rectangle(0,                  0, srourceBitmap.Width - (int)azimuthColumn, srourceBitmap.Height);
        //    destinationRectangle = new Rectangle((int)azimuthColumn, 0, srourceBitmap.Width - (int)azimuthColumn, srourceBitmap.Height);

        //    sourceData      = srourceBitmap.LockBits(sourceRectangle,          ImageLockMode.ReadOnly,  srourceBitmap.PixelFormat);
        //    destinationData = destinationBitmap.LockBits(destinationRectangle, ImageLockMode.WriteOnly, destinationBitmap.PixelFormat);

        //    srcScan0 = sourceData.Scan0.ToInt64();
        //    resScan0 = destinationData.Scan0.ToInt64();

        //    srcStride = sourceData.Stride;
        //    resStride = destinationData.Stride;
        //    rowLength = Math.Abs(sourceData.Stride);

        //    try
        //    {
        //        byte[] buffer = new byte[rowLength];
        //        for (int y = 0; y < sourceData.Height; y++)
        //        {
        //            Marshal.Copy(new IntPtr(srcScan0 + y * srcStride), buffer, 0, rowLength);
        //            Marshal.Copy(buffer, 0, new IntPtr(resScan0 + y * resStride), rowLength);
        //        }
        //    }
        //    finally
        //    {
        //        srourceBitmap.UnlockBits(sourceData);
        //        destinationBitmap.UnlockBits(destinationData);
        //    }





        //    sourceRectangle      = new Rectangle(0,                  0, srourceBitmap.Width - (int)azimuthColumn, srourceBitmap.Height);
        //    destinationRectangle = new Rectangle((int)azimuthColumn, 0, srourceBitmap.Width - (int)azimuthColumn, srourceBitmap.Height);

        //    sourceData = srourceBitmap.LockBits(sourceRectangle, ImageLockMode.ReadOnly, srourceBitmap.PixelFormat);
        //    destinationData = destinationBitmap.LockBits(destinationRectangle, ImageLockMode.WriteOnly, destinationBitmap.PixelFormat);

        //    srcScan0 = sourceData.Scan0.ToInt64();
        //    resScan0 = destinationData.Scan0.ToInt64();

        //    srcStride = sourceData.Stride;
        //    resStride = destinationData.Stride;
        //    rowLength = Math.Abs(sourceData.Stride);

        //    try
        //    {
        //        byte[] buffer = new byte[rowLength];
        //        for (int y = 0; y < sourceData.Height; y++)
        //        {
        //            Marshal.Copy(new IntPtr(srcScan0 + y * srcStride), buffer, 0, rowLength);
        //            Marshal.Copy(buffer, 0, new IntPtr(resScan0 + y * resStride), rowLength);
        //        }
        //    }
        //    finally
        //    {
        //        srourceBitmap.UnlockBits(sourceData);
        //        destinationBitmap.UnlockBits(destinationData);
        //    }





        //    return destinationBitmap;
        //}

        private void FindHorizon()
        {
            int height;
            int width;
            int size;

            height = mPanoramaBitmap.Height;
            width = mPanoramaBitmap.Width;
            mHorizonData = new int[width];


            // Copy the original image to the byte array
            BitmapData panoramaBitmapData = mPanoramaBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, mPanoramaBitmap.PixelFormat);
            IntPtr panoramaPointer = panoramaBitmapData.Scan0;

            size = Math.Abs(panoramaBitmapData.Stride) * height;

            byte[] pixels = new byte[size];

            Marshal.Copy(panoramaPointer, pixels, 0, size);

            mPanoramaBitmap.UnlockBits(panoramaBitmapData);


            // the formBitmap will be updated with the transparency check values
            BitmapData formBitmapData = mFormBitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, mFormBitmap.PixelFormat);
            IntPtr formPointer = formBitmapData.Scan0;


            for (int x = 0; x < width; x++)
            {
                bool bFound = false;
                int columnAddress;

                columnAddress = x << 2;

                for (int y = 0; y < height; y++)
                {
                    if (pixels[columnAddress + 3] > mTransparencyTolerance)
                    {
                        if (mBoolShowHorizonLine)
                        {
                            if (bFound == false)
                            {
                                // Find the non-transparent pixels in the x-column - Set bFound when we find the first one 
                                pixels[columnAddress + 3] = 255;
                                pixels[columnAddress + 2] = 255;
                                pixels[columnAddress + 1] = 0;
                                pixels[columnAddress] = 0;
                                pixels[columnAddress - formBitmapData.Stride + 3] = 255;
                                pixels[columnAddress - formBitmapData.Stride + 2] = 255;
                                pixels[columnAddress - formBitmapData.Stride + 1] = 0;
                                pixels[columnAddress - formBitmapData.Stride] = 0;
                                pixels[columnAddress - formBitmapData.Stride - formBitmapData.Stride + 3] = 255;
                                pixels[columnAddress - formBitmapData.Stride - formBitmapData.Stride + 2] = 255;
                                pixels[columnAddress - formBitmapData.Stride - formBitmapData.Stride + 1] = 0;
                                pixels[columnAddress - formBitmapData.Stride] = 0;

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



                    columnAddress += formBitmapData.Stride;

                }
            }

            Marshal.Copy(pixels, 0, formPointer, size);
            mFormBitmap.UnlockBits(formBitmapData);

            mPanoramaPictureBox.Refresh();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = mPanoramaFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                mPanoramaFileName = mPanoramaFileDialog.FileName;
                mPanoramaBitmap = new Bitmap(mPanoramaFileName);
                mFormBitmap = new Bitmap(mPanoramaFileName);

                mPanoramaPictureBox = new PictureBox();
                mPanoramaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                mPanoramaPictureBox.Dock = DockStyle.Fill;

                mPanoramaPictureBox.Image = mFormBitmap;

                Controls.Add(mPanoramaPictureBox);

                if (mPanoramaBitmap.Width % 512 != 0)
                {
                    MessageBox.Show("The horizon file must be a multiple of 512 pixels wide.\n\n" +
                        "This file is " + mPanoramaBitmap.Width + " pixels wide by " + mPanoramaBitmap.Height + " pixels high.\n\n" +
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

        private void TrackBarTolerance_MouseUp(object sender, MouseEventArgs e)
        {
            if (mBoolTrackBarToleranceStill)
            {
                mBoolTrackBarToleranceStill = false;
                FindHorizon();
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
            double zeroDegreePixelRow;

            zeroDegreePixelRow = Interpolate(0, mTheSkyXBottomAltitude, mTheSkyXTopAltitude, mPanoramaBitmap.Height, 0);
            zeroDegreePixelRow = Math.Round(zeroDegreePixelRow);

            for (int x = 0; x < mFormBitmap.Width; x++)
            {
                mFormBitmap.SetPixel(x, (int)zeroDegreePixelRow, Color.White);
                mFormBitmap.SetPixel(x, (int)zeroDegreePixelRow - 1, Color.White);
            }

            using (Graphics g = Graphics.FromImage(mFormBitmap))
            {
                g.DrawString("Horizon", new Font("Tahoma", 36), Brushes.White, mPanoramaBitmap.Width >> 1, (float)zeroDegreePixelRow);
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
