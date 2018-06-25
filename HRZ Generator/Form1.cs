using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRZ_Generator
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonShowTransparency_Click(object sender, EventArgs e)
        {
            mBoolShowHorizonLine = false;
            FindHorizon();
        }
        private void ButtonShowHorizon_Click(object sender, EventArgs e)
        {
            mBoolShowHorizonLine = true;
            FindHorizon();
        }
        private void TrackBarTolerance_Scroll(object sender, EventArgs e)
        {
            mTransparencyTolerance = trackBar1.Value;
            label4.Text = mTransparencyTolerance.ToString();

            mBoolTrackBarToleranceStill = false;
        }

        private void ButtonWriteHRZ_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Custom Horizon.txt";

            int a = mHorizonData[0];

            int degreeSpan;
            int degreeSpanRemainder;
            int degreeIndex;
            int max;

            degreeSpan = mPanoramaBitmap.Width / 360;
            degreeSpanRemainder = mPanoramaBitmap.Width % 360;

            degreeIndex = 0;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {

                for (int degree = 0; degree < 360; degree++)
                {
                    max = 1000000;
                    for (int degreeRange = 0; degreeRange < degreeSpan; degreeRange++)
                    {
                        max = (mHorizonData[degreeIndex] < max) ? mHorizonData[degreeIndex] : max;
                    }

                    degreeIndex += degreeSpan;


                    string text = string.Format("{0,9:##.00}", Convert.ToDouble(max));
                    file.WriteLine(text);
                }
            }




        }


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
                                pixels[columnAddress + 1] = 255;
                                pixels[columnAddress] = 255;

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
                }
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

        
    }
}
