namespace HRZ_Generator
{
    partial class Form1
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
            this.TextBoxSkyXAzimuth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ButtonWriteHRZ = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBoxTolerance = new System.Windows.Forms.GroupBox();
            this.ButtonShowHorizon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.GroupBoxTolerance.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonShowTransparency
            // 
            this.ButtonShowTransparency.Location = new System.Drawing.Point(258, 32);
            this.ButtonShowTransparency.Name = "ButtonShowTransparency";
            this.ButtonShowTransparency.Size = new System.Drawing.Size(85, 40);
            this.ButtonShowTransparency.TabIndex = 0;
            this.ButtonShowTransparency.Text = "Show Transparency";
            this.ButtonShowTransparency.UseVisualStyleBackColor = true;
            this.ButtonShowTransparency.Click += new System.EventHandler(this.ButtonShowTransparency_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(12, 19);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 23);
            this.ButtonBrowse.TabIndex = 1;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // TextBoxSkyXAzimuth
            // 
            this.TextBoxSkyXAzimuth.Location = new System.Drawing.Point(585, 26);
            this.TextBoxSkyXAzimuth.Name = "TextBoxSkyXAzimuth";
            this.TextBoxSkyXAzimuth.Size = new System.Drawing.Size(100, 20);
            this.TextBoxSkyXAzimuth.TabIndex = 2;
            this.TextBoxSkyXAzimuth.Text = "Degrees";
            this.TextBoxSkyXAzimuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "The SkyX Azimuth";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(698, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Degrees";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Telescope Alititude";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "s";
            // 
            // ButtonWriteHRZ
            // 
            this.ButtonWriteHRZ.Location = new System.Drawing.Point(1043, 12);
            this.ButtonWriteHRZ.Name = "ButtonWriteHRZ";
            this.ButtonWriteHRZ.Size = new System.Drawing.Size(141, 23);
            this.ButtonWriteHRZ.TabIndex = 6;
            this.ButtonWriteHRZ.Text = "Write \"custom horizon.hrz\"";
            this.ButtonWriteHRZ.UseVisualStyleBackColor = true;
            this.ButtonWriteHRZ.Click += new System.EventHandler(this.ButtonWriteHRZ_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 30);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(207, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBarTolerance_Scroll);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarTolerance_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "20";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tolerancce";
            // 
            // GroupBoxTolerance
            // 
            this.GroupBoxTolerance.Controls.Add(this.ButtonShowHorizon);
            this.GroupBoxTolerance.Controls.Add(this.trackBar1);
            this.GroupBoxTolerance.Controls.Add(this.label3);
            this.GroupBoxTolerance.Controls.Add(this.label4);
            this.GroupBoxTolerance.Controls.Add(this.ButtonShowTransparency);
            this.GroupBoxTolerance.Location = new System.Drawing.Point(112, 9);
            this.GroupBoxTolerance.Name = "GroupBoxTolerance";
            this.GroupBoxTolerance.Size = new System.Drawing.Size(441, 100);
            this.GroupBoxTolerance.TabIndex = 11;
            this.GroupBoxTolerance.TabStop = false;
            this.GroupBoxTolerance.Text = "Horizon Transparency Tolerance";
            // 
            // ButtonShowHorizon
            // 
            this.ButtonShowHorizon.Location = new System.Drawing.Point(349, 32);
            this.ButtonShowHorizon.Name = "ButtonShowHorizon";
            this.ButtonShowHorizon.Size = new System.Drawing.Size(77, 40);
            this.ButtonShowHorizon.TabIndex = 11;
            this.ButtonShowHorizon.Text = "Show Horizon Line";
            this.ButtonShowHorizon.UseVisualStyleBackColor = true;
            this.ButtonShowHorizon.Click += new System.EventHandler(this.ButtonShowHorizon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 606);
            this.Controls.Add(this.GroupBoxTolerance);
            this.Controls.Add(this.ButtonWriteHRZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxSkyXAzimuth);
            this.Controls.Add(this.ButtonBrowse);
            this.Name = "Form1";
            this.Text = "HRZ Generator";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.GroupBoxTolerance.ResumeLayout(false);
            this.GroupBoxTolerance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonShowTransparency;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox TextBoxSkyXAzimuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ButtonWriteHRZ;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GroupBoxTolerance;
        private System.Windows.Forms.Button ButtonShowHorizon;
    }
}

