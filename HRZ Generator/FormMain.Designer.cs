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
            this.ButtonShowTransparency = new System.Windows.Forms.Button();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxTheSkyXTopAltitude = new System.Windows.Forms.TextBox();
            this.LabelTheSkyXTop = new System.Windows.Forms.Label();
            this.TextBoxTheSkyXBottomAltitude = new System.Windows.Forms.TextBox();
            this.LabelTheSkyXBottom = new System.Windows.Forms.Label();
            this.ButtonWriteHRZ = new System.Windows.Forms.Button();
            this.TrackBarTransparencyTolerance = new System.Windows.Forms.TrackBar();
            this.LabelTransparency = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBoxTolerance = new System.Windows.Forms.GroupBox();
            this.ButtonShowHorizon = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTransparencyTolerance)).BeginInit();
            this.GroupBoxTolerance.SuspendLayout();
            this.GroupBoxTheSkyX.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonShowTransparency
            // 
            this.ButtonShowTransparency.Location = new System.Drawing.Point(254, 30);
            this.ButtonShowTransparency.Name = "ButtonShowTransparency";
            this.ButtonShowTransparency.Size = new System.Drawing.Size(85, 40);
            this.ButtonShowTransparency.TabIndex = 0;
            this.ButtonShowTransparency.Text = "Show Transparency";
            this.ButtonShowTransparency.UseVisualStyleBackColor = true;
            this.ButtonShowTransparency.Click += new System.EventHandler(this.ButtonShowTransparency_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(12, 55);
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
            this.ButtonWriteHRZ.Location = new System.Drawing.Point(1001, 55);
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
            this.TrackBarTransparencyTolerance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarTolerance_MouseUp);
            // 
            // LabelTransparency
            // 
            this.LabelTransparency.AutoSize = true;
            this.LabelTransparency.Location = new System.Drawing.Point(214, 44);
            this.LabelTransparency.Name = "LabelTransparency";
            this.LabelTransparency.Size = new System.Drawing.Size(19, 13);
            this.LabelTransparency.TabIndex = 9;
            this.LabelTransparency.Text = "20";
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
            this.GroupBoxTolerance.Controls.Add(this.ButtonShowHorizon);
            this.GroupBoxTolerance.Controls.Add(this.TrackBarTransparencyTolerance);
            this.GroupBoxTolerance.Controls.Add(this.label3);
            this.GroupBoxTolerance.Controls.Add(this.LabelTransparency);
            this.GroupBoxTolerance.Controls.Add(this.ButtonShowTransparency);
            this.GroupBoxTolerance.Enabled = false;
            this.GroupBoxTolerance.Location = new System.Drawing.Point(115, 29);
            this.GroupBoxTolerance.Name = "GroupBoxTolerance";
            this.GroupBoxTolerance.Size = new System.Drawing.Size(441, 93);
            this.GroupBoxTolerance.TabIndex = 11;
            this.GroupBoxTolerance.TabStop = false;
            this.GroupBoxTolerance.Text = "Panoramic Horizon Photograph Transparency";
            // 
            // ButtonShowHorizon
            // 
            this.ButtonShowHorizon.Location = new System.Drawing.Point(345, 30);
            this.ButtonShowHorizon.Name = "ButtonShowHorizon";
            this.ButtonShowHorizon.Size = new System.Drawing.Size(85, 40);
            this.ButtonShowHorizon.TabIndex = 11;
            this.ButtonShowHorizon.Text = "Show\r\nSky Horizon";
            this.ButtonShowHorizon.UseVisualStyleBackColor = true;
            this.ButtonShowHorizon.Click += new System.EventHandler(this.ButtonShowHorizon_Click);
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
            this.GroupBoxTheSkyX.Location = new System.Drawing.Point(576, 29);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 584);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1130, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(1130, 24);
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
            this.setDefaultsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setDefaultsToolStripMenuItem.Text = "Set Defaults";
            this.setDefaultsToolStripMenuItem.Click += new System.EventHandler(this.SetDefaultsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Open Panorama";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OpenPanoramaToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 606);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.GroupBoxTheSkyX);
            this.Controls.Add(this.GroupBoxTolerance);
            this.Controls.Add(this.ButtonWriteHRZ);
            this.Controls.Add(this.ButtonBrowse);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "The SkyX HRZ Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTransparencyTolerance)).EndInit();
            this.GroupBoxTolerance.ResumeLayout(false);
            this.GroupBoxTolerance.PerformLayout();
            this.GroupBoxTheSkyX.ResumeLayout(false);
            this.GroupBoxTheSkyX.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonShowTransparency;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox TextBoxTheSkyXTopAltitude;
        private System.Windows.Forms.Label LabelTheSkyXTop;
        private System.Windows.Forms.TextBox TextBoxTheSkyXBottomAltitude;
        private System.Windows.Forms.Label LabelTheSkyXBottom;
        private System.Windows.Forms.Button ButtonWriteHRZ;
        private System.Windows.Forms.TrackBar TrackBarTransparencyTolerance;
        private System.Windows.Forms.Label LabelTransparency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GroupBoxTolerance;
        private System.Windows.Forms.Button ButtonShowHorizon;
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
    }
}

