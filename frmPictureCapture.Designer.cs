namespace SnapTake
{
    partial class frmPictureCapture
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
            this.btCapture = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.comboBoxModes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btReady = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSettingsButton = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btSaveSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCapture
            // 
            this.btCapture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCapture.Enabled = false;
            this.btCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapture.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCapture.Location = new System.Drawing.Point(429, 74);
            this.btCapture.Name = "btCapture";
            this.btCapture.Size = new System.Drawing.Size(328, 45);
            this.btCapture.TabIndex = 2;
            this.btCapture.Text = "CAPTURE";
            this.btCapture.UseVisualStyleBackColor = false;
            this.btCapture.Click += new System.EventHandler(this.btCapture_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.btSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSave.Enabled = false;
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSave.ForeColor = System.Drawing.Color.Gainsboro;
            this.btSave.Location = new System.Drawing.Point(429, 138);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(328, 45);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "SAVE";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(12, 428);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(281, 21);
            this.comboBoxCameras.TabIndex = 5;
            // 
            // comboBoxModes
            // 
            this.comboBoxModes.FormattingEnabled = true;
            this.comboBoxModes.Location = new System.Drawing.Point(12, 492);
            this.comboBoxModes.Name = "comboBoxModes";
            this.comboBoxModes.Size = new System.Drawing.Size(281, 21);
            this.comboBoxModes.TabIndex = 6;
            this.comboBoxModes.SelectedIndexChanged += new System.EventHandler(this.comboBoxModes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Supported Cameras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Supported Resolutions";
            // 
            // btReady
            // 
            this.btReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btReady.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReady.Enabled = false;
            this.btReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReady.ForeColor = System.Drawing.Color.Gainsboro;
            this.btReady.Location = new System.Drawing.Point(429, 12);
            this.btReady.Name = "btReady";
            this.btReady.Size = new System.Drawing.Size(328, 45);
            this.btReady.TabIndex = 9;
            this.btReady.Text = "READY";
            this.btReady.UseVisualStyleBackColor = false;
            this.btReady.Click += new System.EventHandler(this.btReady_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(38, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 248);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picSettingsButton
            // 
            this.picSettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSettingsButton.Image = global::SnapTake.Properties.Resources.settings_gear;
            this.picSettingsButton.Location = new System.Drawing.Point(427, 303);
            this.picSettingsButton.Name = "picSettingsButton";
            this.picSettingsButton.Size = new System.Drawing.Size(36, 35);
            this.picSettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSettingsButton.TabIndex = 11;
            this.picSettingsButton.TabStop = false;
            this.picSettingsButton.Click += new System.EventHandler(this.picSettingsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 326);
            this.panel1.TabIndex = 12;
            // 
            // btStop
            // 
            this.btStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btStop.Enabled = false;
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStop.ForeColor = System.Drawing.Color.Gainsboro;
            this.btStop.Location = new System.Drawing.Point(429, 203);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(328, 45);
            this.btStop.TabIndex = 13;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "label3";
            // 
            // btSaveSettings
            // 
            this.btSaveSettings.Location = new System.Drawing.Point(309, 428);
            this.btSaveSettings.Name = "btSaveSettings";
            this.btSaveSettings.Size = new System.Drawing.Size(82, 23);
            this.btSaveSettings.TabIndex = 15;
            this.btSaveSettings.Text = "Save Settings";
            this.btSaveSettings.UseVisualStyleBackColor = true;
            this.btSaveSettings.Click += new System.EventHandler(this.btSaveSettings_Click);
            // 
            // frmPictureCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(769, 527);
            this.Controls.Add(this.btSaveSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picSettingsButton);
            this.Controls.Add(this.btReady);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxModes);
            this.Controls.Add(this.comboBoxCameras);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCapture);
            this.Name = "frmPictureCapture";
            this.Text = "SnapTake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPictureCapture_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.frmPictureCapture_SizeChanged);
            this.Move += new System.EventHandler(this.frmPictureCapture_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btCapture;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.ComboBox comboBoxModes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btReady;
        private System.Windows.Forms.PictureBox picSettingsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSaveSettings;
    }
}

