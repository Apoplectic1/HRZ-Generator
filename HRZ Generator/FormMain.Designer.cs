using System.Windows.Forms;

namespace HRZ_Generator
{
    partial class FormMain
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
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxTheSkyXTopAltitude = new System.Windows.Forms.TextBox();
            this.LabelTheSkyXTop = new System.Windows.Forms.Label();
            this.TextBoxTheSkyXBottomAltitude = new System.Windows.Forms.TextBox();
            this.LabelTheSkyXBottom = new System.Windows.Forms.Label();
            this.ButtonWriteHRZ = new System.Windows.Forms.Button();
            this.TrackBarTransparencyTolerance = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBoxTolerance = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonHorizonImageSkyHorizonMask = new System.Windows.Forms.RadioButton();
            this.RadioButtonHorizonImageMeridianHorizon = new System.Windows.Forms.RadioButton();
            this.RadioButtonHorizonImageHide = new System.Windows.Forms.RadioButton();
            this.GroupBoxPanoramaImage = new System.Windows.Forms.GroupBox();
            this.RadioButtonPanoImageSkyHorizon = new System.Windows.Forms.RadioButton();
            this.RadioButtonPanoImageTransparency = new System.Windows.Forms.RadioButton();
            this.RadioButtonPanoImagePhoto = new System.Windows.Forms.RadioButton();
            this.GroupBoxTheSkyX = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonTheSkyXCalculate = new System.Windows.Forms.Button();
            this.TextBoxTheSkyXLeftRightAzimuth = new System.Windows.Forms.TextBox();
            this.LabelTheSkyXLeftRight = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupBoxPanoramaControls = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTransparencyTolerance)).BeginInit();
            this.GroupBoxTolerance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupBoxPanoramaImage.SuspendLayout();
            this.GroupBoxTheSkyX.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GroupBoxPanoramaControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(16, 49);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(88, 43);
            this.ButtonBrowse.TabIndex = 1;
            this.ButtonBrowse.Text = "Browse For\r\nPanorama";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // TextBoxTheSkyXTopAltitude
            // 
            this.TextBoxTheSkyXTopAltitude.Location = new System.Drawing.Point(21, 40);
            this.TextBoxTheSkyXTopAltitude.Name = "TextBoxTheSkyXTopAltitude";
            this.TextBoxTheSkyXTopAltitude.Size = new System.Drawing.Size(76, 20);
            this.TextBoxTheSkyXTopAltitude.TabIndex = 2;
            this.TextBoxTheSkyXTopAltitude.Text = "60.0";
            this.TextBoxTheSkyXTopAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxTheSkyXTopAltitude.TextChanged += new System.EventHandler(this.TextBoxTheSkyXTopAltitude_TextChanged);
            // 
            // LabelTheSkyXTop
            // 
            this.LabelTheSkyXTop.AutoSize = true;
            this.LabelTheSkyXTop.Location = new System.Drawing.Point(23, 23);
            this.LabelTheSkyXTop.Name = "LabelTheSkyXTop";
            this.LabelTheSkyXTop.Size = new System.Drawing.Size(73, 13);
            this.LabelTheSkyXTop.TabIndex = 3;
            this.LabelTheSkyXTop.Text = "Top TrackBar";
            // 
            // TextBoxTheSkyXBottomAltitude
            // 
            this.TextBoxTheSkyXBottomAltitude.Location = new System.Drawing.Point(120, 40);
            this.TextBoxTheSkyXBottomAltitude.Name = "TextBoxTheSkyXBottomAltitude";
            this.TextBoxTheSkyXBottomAltitude.Size = new System.Drawing.Size(76, 20);
            this.TextBoxTheSkyXBottomAltitude.TabIndex = 4;
            this.TextBoxTheSkyXBottomAltitude.Text = "-60.0";
            this.TextBoxTheSkyXBottomAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxTheSkyXBottomAltitude.TextChanged += new System.EventHandler(this.TextBoxTheSkyXBottomAltitude_TextChanged);
            // 
            // LabelTheSkyXBottom
            // 
            this.LabelTheSkyXBottom.AutoSize = true;
            this.LabelTheSkyXBottom.Location = new System.Drawing.Point(115, 23);
            this.LabelTheSkyXBottom.Name = "LabelTheSkyXBottom";
            this.LabelTheSkyXBottom.Size = new System.Drawing.Size(87, 13);
            this.LabelTheSkyXBottom.TabIndex = 5;
            this.LabelTheSkyXBottom.Text = "Bottom TrackBar";
            // 
            // ButtonWriteHRZ
            // 
            this.ButtonWriteHRZ.Enabled = false;
            this.ButtonWriteHRZ.Location = new System.Drawing.Point(1101, 49);
            this.ButtonWriteHRZ.Name = "ButtonWriteHRZ";
            this.ButtonWriteHRZ.Size = new System.Drawing.Size(118, 43);
            this.ButtonWriteHRZ.TabIndex = 6;
            this.ButtonWriteHRZ.Text = "Write \r\n\"Custom Horizon.hrz\"";
            this.ButtonWriteHRZ.UseVisualStyleBackColor = true;
            this.ButtonWriteHRZ.Click += new System.EventHandler(this.ButtonWriteHRZ_Click);
            // 
            // TrackBarTransparencyTolerance
            // 
            this.TrackBarTransparencyTolerance.Location = new System.Drawing.Point(6, 28);
            this.TrackBarTransparencyTolerance.Maximum = 255;
            this.TrackBarTransparencyTolerance.Name = "TrackBarTransparencyTolerance";
            this.TrackBarTransparencyTolerance.Size = new System.Drawing.Size(207, 45);
            this.TrackBarTransparencyTolerance.TabIndex = 7;
            this.TrackBarTransparencyTolerance.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TrackBarTransparencyTolerance.Value = 20;
            this.TrackBarTransparencyTolerance.Scroll += new System.EventHandler(this.TrackBarTolerance_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Transparency Tolerance";
            // 
            // GroupBoxTolerance
            // 
            this.GroupBoxTolerance.Controls.Add(this.groupBox2);
            this.GroupBoxTolerance.Controls.Add(this.GroupBoxPanoramaImage);
            this.GroupBoxTolerance.Controls.Add(this.TrackBarTransparencyTolerance);
            this.GroupBoxTolerance.Controls.Add(this.label3);
            this.GroupBoxTolerance.Enabled = false;
            this.GroupBoxTolerance.Location = new System.Drawing.Point(126, 19);
            this.GroupBoxTolerance.Name = "GroupBoxTolerance";
            this.GroupBoxTolerance.Size = new System.Drawing.Size(533, 93);
            this.GroupBoxTolerance.TabIndex = 11;
            this.GroupBoxTolerance.TabStop = false;
            this.GroupBoxTolerance.Text = "Panoramic Horizon Photograph Transparency";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButtonHorizonImageSkyHorizonMask);
            this.groupBox2.Controls.Add(this.RadioButtonHorizonImageMeridianHorizon);
            this.groupBox2.Controls.Add(this.RadioButtonHorizonImageHide);
            this.groupBox2.Location = new System.Drawing.Point(374, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 75);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equatorial Lines";
            // 
            // RadioButtonHorizonImageSkyHorizonMask
            // 
            this.RadioButtonHorizonImageSkyHorizonMask.AutoSize = true;
            this.RadioButtonHorizonImageSkyHorizonMask.Location = new System.Drawing.Point(17, 55);
            this.RadioButtonHorizonImageSkyHorizonMask.Name = "RadioButtonHorizonImageSkyHorizonMask";
            this.RadioButtonHorizonImageSkyHorizonMask.Size = new System.Drawing.Size(111, 17);
            this.RadioButtonHorizonImageSkyHorizonMask.TabIndex = 2;
            this.RadioButtonHorizonImageSkyHorizonMask.Text = "Sky Horizon Mask";
            this.RadioButtonHorizonImageSkyHorizonMask.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHorizonImageMeridianHorizon
            // 
            this.RadioButtonHorizonImageMeridianHorizon.AutoSize = true;
            this.RadioButtonHorizonImageMeridianHorizon.Checked = true;
            this.RadioButtonHorizonImageMeridianHorizon.Location = new System.Drawing.Point(17, 35);
            this.RadioButtonHorizonImageMeridianHorizon.Name = "RadioButtonHorizonImageMeridianHorizon";
            this.RadioButtonHorizonImageMeridianHorizon.Size = new System.Drawing.Size(106, 17);
            this.RadioButtonHorizonImageMeridianHorizon.TabIndex = 1;
            this.RadioButtonHorizonImageMeridianHorizon.TabStop = true;
            this.RadioButtonHorizonImageMeridianHorizon.Text = "Meridian/Horizon";
            this.RadioButtonHorizonImageMeridianHorizon.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHorizonImageHide
            // 
            this.RadioButtonHorizonImageHide.AutoSize = true;
            this.RadioButtonHorizonImageHide.Location = new System.Drawing.Point(17, 15);
            this.RadioButtonHorizonImageHide.Name = "RadioButtonHorizonImageHide";
            this.RadioButtonHorizonImageHide.Size = new System.Drawing.Size(47, 17);
            this.RadioButtonHorizonImageHide.TabIndex = 0;
            this.RadioButtonHorizonImageHide.Text = "Hide";
            this.RadioButtonHorizonImageHide.UseVisualStyleBackColor = true;
            this.RadioButtonHorizonImageHide.CheckedChanged += new System.EventHandler(this.RadioButtonHorizonImageHide_CheckedChanged);
            // 
            // GroupBoxPanoramaImage
            // 
            this.GroupBoxPanoramaImage.Controls.Add(this.RadioButtonPanoImageSkyHorizon);
            this.GroupBoxPanoramaImage.Controls.Add(this.RadioButtonPanoImageTransparency);
            this.GroupBoxPanoramaImage.Controls.Add(this.RadioButtonPanoImagePhoto);
            this.GroupBoxPanoramaImage.Location = new System.Drawing.Point(241, 11);
            this.GroupBoxPanoramaImage.Name = "GroupBoxPanoramaImage";
            this.GroupBoxPanoramaImage.Size = new System.Drawing.Size(111, 76);
            this.GroupBoxPanoramaImage.TabIndex = 11;
            this.GroupBoxPanoramaImage.TabStop = false;
            this.GroupBoxPanoramaImage.Text = "Panoramic Image";
            // 
            // RadioButtonPanoImageSkyHorizon
            // 
            this.RadioButtonPanoImageSkyHorizon.AutoSize = true;
            this.RadioButtonPanoImageSkyHorizon.Location = new System.Drawing.Point(14, 55);
            this.RadioButtonPanoImageSkyHorizon.Name = "RadioButtonPanoImageSkyHorizon";
            this.RadioButtonPanoImageSkyHorizon.Size = new System.Drawing.Size(82, 17);
            this.RadioButtonPanoImageSkyHorizon.TabIndex = 2;
            this.RadioButtonPanoImageSkyHorizon.Text = "Sky Horizon";
            this.RadioButtonPanoImageSkyHorizon.UseVisualStyleBackColor = true;
            this.RadioButtonPanoImageSkyHorizon.CheckedChanged += new System.EventHandler(this.RadioButtonShowSkyHorizon_CheckedChanged);
            // 
            // RadioButtonPanoImageTransparency
            // 
            this.RadioButtonPanoImageTransparency.AutoSize = true;
            this.RadioButtonPanoImageTransparency.Location = new System.Drawing.Point(14, 35);
            this.RadioButtonPanoImageTransparency.Name = "RadioButtonPanoImageTransparency";
            this.RadioButtonPanoImageTransparency.Size = new System.Drawing.Size(90, 17);
            this.RadioButtonPanoImageTransparency.TabIndex = 1;
            this.RadioButtonPanoImageTransparency.Text = "Transparency";
            this.RadioButtonPanoImageTransparency.UseVisualStyleBackColor = true;
            this.RadioButtonPanoImageTransparency.CheckedChanged += new System.EventHandler(this.RadioButtonShowTransparency_CheckedChanged);
            // 
            // RadioButtonPanoImagePhoto
            // 
            this.RadioButtonPanoImagePhoto.AutoSize = true;
            this.RadioButtonPanoImagePhoto.Checked = true;
            this.RadioButtonPanoImagePhoto.Location = new System.Drawing.Point(14, 15);
            this.RadioButtonPanoImagePhoto.Name = "RadioButtonPanoImagePhoto";
            this.RadioButtonPanoImagePhoto.Size = new System.Drawing.Size(53, 17);
            this.RadioButtonPanoImagePhoto.TabIndex = 0;
            this.RadioButtonPanoImagePhoto.TabStop = true;
            this.RadioButtonPanoImagePhoto.Text = "Photo";
            this.RadioButtonPanoImagePhoto.UseVisualStyleBackColor = true;
            this.RadioButtonPanoImagePhoto.CheckedChanged += new System.EventHandler(this.RadioButtonShowPhoto_CheckedChanged);
            // 
            // GroupBoxTheSkyX
            // 
            this.GroupBoxTheSkyX.Controls.Add(this.label5);
            this.GroupBoxTheSkyX.Controls.Add(this.label2);
            this.GroupBoxTheSkyX.Controls.Add(this.label1);
            this.GroupBoxTheSkyX.Controls.Add(this.ButtonTheSkyXCalculate);
            this.GroupBoxTheSkyX.Controls.Add(this.TextBoxTheSkyXLeftRightAzimuth);
            this.GroupBoxTheSkyX.Controls.Add(this.LabelTheSkyXLeftRight);
            this.GroupBoxTheSkyX.Controls.Add(this.LabelTheSkyXTop);
            this.GroupBoxTheSkyX.Controls.Add(this.TextBoxTheSkyXTopAltitude);
            this.GroupBoxTheSkyX.Controls.Add(this.TextBoxTheSkyXBottomAltitude);
            this.GroupBoxTheSkyX.Controls.Add(this.LabelTheSkyXBottom);
            this.GroupBoxTheSkyX.Enabled = false;
            this.GroupBoxTheSkyX.Location = new System.Drawing.Point(665, 19);
            this.GroupBoxTheSkyX.Name = "GroupBoxTheSkyX";
            this.GroupBoxTheSkyX.Size = new System.Drawing.Size(414, 93);
            this.GroupBoxTheSkyX.TabIndex = 12;
            this.GroupBoxTheSkyX.TabStop = false;
            this.GroupBoxTheSkyX.Text = "The SkyX Horizon Photograph Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Azimuth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Altitude";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Altitude";
            // 
            // ButtonTheSkyXCalculate
            // 
            this.ButtonTheSkyXCalculate.Location = new System.Drawing.Point(317, 25);
            this.ButtonTheSkyXCalculate.Name = "ButtonTheSkyXCalculate";
            this.ButtonTheSkyXCalculate.Size = new System.Drawing.Size(77, 40);
            this.ButtonTheSkyXCalculate.TabIndex = 8;
            this.ButtonTheSkyXCalculate.Text = "Calculate";
            this.ButtonTheSkyXCalculate.UseVisualStyleBackColor = true;
            this.ButtonTheSkyXCalculate.Click += new System.EventHandler(this.ButtonTheSkyXCalculate_Click);
            // 
            // TextBoxTheSkyXLeftRightAzimuth
            // 
            this.TextBoxTheSkyXLeftRightAzimuth.Location = new System.Drawing.Point(222, 39);
            this.TextBoxTheSkyXLeftRightAzimuth.Name = "TextBoxTheSkyXLeftRightAzimuth";
            this.TextBoxTheSkyXLeftRightAzimuth.Size = new System.Drawing.Size(76, 20);
            this.TextBoxTheSkyXLeftRightAzimuth.TabIndex = 7;
            this.TextBoxTheSkyXLeftRightAzimuth.Text = "0.0";
            this.TextBoxTheSkyXLeftRightAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxTheSkyXLeftRightAzimuth.TextChanged += new System.EventHandler(this.TextBoxTheSkyXLeftRightAzimuth_TextChanged);
            // 
            // LabelTheSkyXLeftRight
            // 
            this.LabelTheSkyXLeftRight.AutoSize = true;
            this.LabelTheSkyXLeftRight.Location = new System.Drawing.Point(209, 23);
            this.LabelTheSkyXLeftRight.Name = "LabelTheSkyXLeftRight";
            this.LabelTheSkyXLeftRight.Size = new System.Drawing.Size(102, 13);
            this.LabelTheSkyXLeftRight.TabIndex = 6;
            this.LabelTheSkyXLeftRight.Text = "Left/Right TrackBar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 588);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1271, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(174, 17);
            this.toolStripStatusLabel1.Text = "2018 - Skyhawk Consulting, Inc.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1271, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDefaultsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setDefaultsToolStripMenuItem
            // 
            this.setDefaultsToolStripMenuItem.Name = "setDefaultsToolStripMenuItem";
            this.setDefaultsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setDefaultsToolStripMenuItem.Text = "Set Defaults";
            this.setDefaultsToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Open Panorama";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OpenPanoramaToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1247, 390);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // GroupBoxPanoramaControls
            // 
            this.GroupBoxPanoramaControls.Controls.Add(this.GroupBoxTheSkyX);
            this.GroupBoxPanoramaControls.Controls.Add(this.GroupBoxTolerance);
            this.GroupBoxPanoramaControls.Controls.Add(this.ButtonBrowse);
            this.GroupBoxPanoramaControls.Controls.Add(this.ButtonWriteHRZ);
            this.GroupBoxPanoramaControls.Location = new System.Drawing.Point(12, 26);
            this.GroupBoxPanoramaControls.Name = "GroupBoxPanoramaControls";
            this.GroupBoxPanoramaControls.Size = new System.Drawing.Size(1247, 122);
            this.GroupBoxPanoramaControls.TabIndex = 16;
            this.GroupBoxPanoramaControls.TabStop = false;
            this.GroupBoxPanoramaControls.Text = "The SkyX Panorama Controls";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 610);
            this.Controls.Add(this.GroupBoxPanoramaControls);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "The SkyX HRZ Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTransparencyTolerance)).EndInit();
            this.GroupBoxTolerance.ResumeLayout(false);
            this.GroupBoxTolerance.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBoxPanoramaImage.ResumeLayout(false);
            this.GroupBoxPanoramaImage.PerformLayout();
            this.GroupBoxTheSkyX.ResumeLayout(false);
            this.GroupBoxTheSkyX.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GroupBoxPanoramaControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox TextBoxTheSkyXTopAltitude;
        private System.Windows.Forms.Label LabelTheSkyXTop;
        private System.Windows.Forms.TextBox TextBoxTheSkyXBottomAltitude;
        private System.Windows.Forms.Label LabelTheSkyXBottom;
        private System.Windows.Forms.Button ButtonWriteHRZ;
        private System.Windows.Forms.TrackBar TrackBarTransparencyTolerance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GroupBoxTolerance;
        private System.Windows.Forms.GroupBox GroupBoxTheSkyX;
        private System.Windows.Forms.TextBox TextBoxTheSkyXLeftRightAzimuth;
        private System.Windows.Forms.Label LabelTheSkyXLeftRight;
        private System.Windows.Forms.Button ButtonTheSkyXCalculate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDefaultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.GroupBox GroupBoxPanoramaImage;
        private System.Windows.Forms.RadioButton RadioButtonPanoImageSkyHorizon;
        private System.Windows.Forms.RadioButton RadioButtonPanoImageTransparency;
        private System.Windows.Forms.RadioButton RadioButtonPanoImagePhoto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox GroupBoxPanoramaControls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioButtonHorizonImageSkyHorizonMask;
        private System.Windows.Forms.RadioButton RadioButtonHorizonImageMeridianHorizon;
        private System.Windows.Forms.RadioButton RadioButtonHorizonImageHide;
    }
}

