namespace Weather
{
    partial class settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.textBoxInfoText = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageUnits = new System.Windows.Forms.TabPage();
            this.groupBoxWindSpeed = new System.Windows.Forms.GroupBox();
            this.radioButtonMPH = new System.Windows.Forms.RadioButton();
            this.radioButtonKMH = new System.Windows.Forms.RadioButton();
            this.radioButtonMS = new System.Windows.Forms.RadioButton();
            this.groupBoxTempUnit = new System.Windows.Forms.GroupBox();
            this.radioButtonTempKelvin = new System.Windows.Forms.RadioButton();
            this.radioButtonTempFahrenheit = new System.Windows.Forms.RadioButton();
            this.radioButtonTempCelsius = new System.Windows.Forms.RadioButton();
            this.tabPageApiKey = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControlSettings.SuspendLayout();
            this.tabPageUnits.SuspendLayout();
            this.groupBoxWindSpeed.SuspendLayout();
            this.groupBoxTempUnit.SuspendLayout();
            this.tabPageApiKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInfoText
            // 
            this.textBoxInfoText.AcceptsReturn = true;
            this.textBoxInfoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInfoText.Location = new System.Drawing.Point(7, 41);
            this.textBoxInfoText.Multiline = true;
            this.textBoxInfoText.Name = "textBoxInfoText";
            this.textBoxInfoText.ReadOnly = true;
            this.textBoxInfoText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxInfoText.Size = new System.Drawing.Size(435, 89);
            this.textBoxInfoText.TabIndex = 0;
            this.textBoxInfoText.Text = "To use this software, you need an API-key from http://openweathermap.org/. You ne" +
    "ed to sign up (free) and than you can get your own key at:\r\n";
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(105, 6);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(334, 29);
            this.textBoxApiKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "API-Key:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(7, 133);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(394, 25);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://home.openweathermap.org/api_keys";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSettings.Controls.Add(this.tabPageUnits);
            this.tabControlSettings.Controls.Add(this.tabPageApiKey);
            this.tabControlSettings.Location = new System.Drawing.Point(12, 12);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(572, 340);
            this.tabControlSettings.TabIndex = 5;
            // 
            // tabPageUnits
            // 
            this.tabPageUnits.AutoScroll = true;
            this.tabPageUnits.Controls.Add(this.groupBoxWindSpeed);
            this.tabPageUnits.Controls.Add(this.groupBoxTempUnit);
            this.tabPageUnits.Location = new System.Drawing.Point(4, 33);
            this.tabPageUnits.Name = "tabPageUnits";
            this.tabPageUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnits.Size = new System.Drawing.Size(564, 303);
            this.tabPageUnits.TabIndex = 2;
            this.tabPageUnits.Text = "Units";
            this.tabPageUnits.UseVisualStyleBackColor = true;
            // 
            // groupBoxWindSpeed
            // 
            this.groupBoxWindSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWindSpeed.Controls.Add(this.radioButtonMPH);
            this.groupBoxWindSpeed.Controls.Add(this.radioButtonKMH);
            this.groupBoxWindSpeed.Controls.Add(this.radioButtonMS);
            this.groupBoxWindSpeed.Location = new System.Drawing.Point(9, 145);
            this.groupBoxWindSpeed.Name = "groupBoxWindSpeed";
            this.groupBoxWindSpeed.Size = new System.Drawing.Size(549, 133);
            this.groupBoxWindSpeed.TabIndex = 3;
            this.groupBoxWindSpeed.TabStop = false;
            this.groupBoxWindSpeed.Text = "Windspeed";
            // 
            // radioButtonMPH
            // 
            this.radioButtonMPH.AutoSize = true;
            this.radioButtonMPH.Location = new System.Drawing.Point(6, 98);
            this.radioButtonMPH.Name = "radioButtonMPH";
            this.radioButtonMPH.Size = new System.Drawing.Size(215, 29);
            this.radioButtonMPH.TabIndex = 2;
            this.radioButtonMPH.TabStop = true;
            this.radioButtonMPH.Text = "miles per hour (mi/h)";
            this.radioButtonMPH.UseVisualStyleBackColor = true;
            // 
            // radioButtonKMH
            // 
            this.radioButtonKMH.AutoSize = true;
            this.radioButtonKMH.Location = new System.Drawing.Point(6, 63);
            this.radioButtonKMH.Name = "radioButtonKMH";
            this.radioButtonKMH.Size = new System.Drawing.Size(254, 29);
            this.radioButtonKMH.TabIndex = 1;
            this.radioButtonKMH.TabStop = true;
            this.radioButtonKMH.Text = "kilometre per hour (km/h)";
            this.radioButtonKMH.UseVisualStyleBackColor = true;
            // 
            // radioButtonMS
            // 
            this.radioButtonMS.AutoSize = true;
            this.radioButtonMS.Location = new System.Drawing.Point(6, 28);
            this.radioButtonMS.Name = "radioButtonMS";
            this.radioButtonMS.Size = new System.Drawing.Size(239, 29);
            this.radioButtonMS.TabIndex = 0;
            this.radioButtonMS.TabStop = true;
            this.radioButtonMS.Text = "metre per second (m/s)";
            this.radioButtonMS.UseVisualStyleBackColor = true;
            // 
            // groupBoxTempUnit
            // 
            this.groupBoxTempUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTempUnit.Controls.Add(this.radioButtonTempKelvin);
            this.groupBoxTempUnit.Controls.Add(this.radioButtonTempFahrenheit);
            this.groupBoxTempUnit.Controls.Add(this.radioButtonTempCelsius);
            this.groupBoxTempUnit.Location = new System.Drawing.Point(3, 6);
            this.groupBoxTempUnit.Name = "groupBoxTempUnit";
            this.groupBoxTempUnit.Size = new System.Drawing.Size(555, 133);
            this.groupBoxTempUnit.TabIndex = 1;
            this.groupBoxTempUnit.TabStop = false;
            this.groupBoxTempUnit.Text = "Temperature";
            // 
            // radioButtonTempKelvin
            // 
            this.radioButtonTempKelvin.AutoSize = true;
            this.radioButtonTempKelvin.Location = new System.Drawing.Point(6, 98);
            this.radioButtonTempKelvin.Name = "radioButtonTempKelvin";
            this.radioButtonTempKelvin.Size = new System.Drawing.Size(124, 29);
            this.radioButtonTempKelvin.TabIndex = 2;
            this.radioButtonTempKelvin.TabStop = true;
            this.radioButtonTempKelvin.Text = "Kelvin (K)";
            this.radioButtonTempKelvin.UseVisualStyleBackColor = true;
            // 
            // radioButtonTempFahrenheit
            // 
            this.radioButtonTempFahrenheit.AutoSize = true;
            this.radioButtonTempFahrenheit.Location = new System.Drawing.Point(6, 63);
            this.radioButtonTempFahrenheit.Name = "radioButtonTempFahrenheit";
            this.radioButtonTempFahrenheit.Size = new System.Drawing.Size(169, 29);
            this.radioButtonTempFahrenheit.TabIndex = 1;
            this.radioButtonTempFahrenheit.TabStop = true;
            this.radioButtonTempFahrenheit.Text = "Fahrenheit (°F)";
            this.radioButtonTempFahrenheit.UseVisualStyleBackColor = true;
            // 
            // radioButtonTempCelsius
            // 
            this.radioButtonTempCelsius.AutoSize = true;
            this.radioButtonTempCelsius.Location = new System.Drawing.Point(6, 28);
            this.radioButtonTempCelsius.Name = "radioButtonTempCelsius";
            this.radioButtonTempCelsius.Size = new System.Drawing.Size(144, 29);
            this.radioButtonTempCelsius.TabIndex = 0;
            this.radioButtonTempCelsius.TabStop = true;
            this.radioButtonTempCelsius.Text = "Celsius (°C)";
            this.radioButtonTempCelsius.UseVisualStyleBackColor = true;
            // 
            // tabPageApiKey
            // 
            this.tabPageApiKey.Controls.Add(this.linkLabel2);
            this.tabPageApiKey.Controls.Add(this.textBoxKey);
            this.tabPageApiKey.Controls.Add(this.textBoxInfoText);
            this.tabPageApiKey.Controls.Add(this.textBoxApiKey);
            this.tabPageApiKey.Controls.Add(this.linkLabel1);
            this.tabPageApiKey.Controls.Add(this.textBox1);
            this.tabPageApiKey.Controls.Add(this.label2);
            this.tabPageApiKey.Controls.Add(this.label1);
            this.tabPageApiKey.Location = new System.Drawing.Point(4, 33);
            this.tabPageApiKey.Name = "tabPageApiKey";
            this.tabPageApiKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApiKey.Size = new System.Drawing.Size(564, 303);
            this.tabPageApiKey.TabIndex = 1;
            this.tabPageApiKey.Text = "API-Key";
            this.tabPageApiKey.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(7, 133);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(394, 25);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://home.openweathermap.org/api_keys";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBoxKey
            // 
            this.textBoxKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKey.Location = new System.Drawing.Point(105, 6);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(337, 29);
            this.textBoxKey.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(7, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(432, 89);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "To use this software, you need an API-key from http://openweathermap.org/. You ne" +
    "ed to sign up (free) and than you can get your own key at:\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "API-Key:";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(494, 358);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(90, 42);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(398, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 42);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(302, 358);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 42);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(596, 412);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.buttonApply);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settings";
            this.ShowInTaskbar = false;
            this.Text = "Change API-Key";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settings_FormClosing);
            this.Load += new System.EventHandler(this.settings_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageUnits.ResumeLayout(false);
            this.groupBoxWindSpeed.ResumeLayout(false);
            this.groupBoxWindSpeed.PerformLayout();
            this.groupBoxTempUnit.ResumeLayout(false);
            this.groupBoxTempUnit.PerformLayout();
            this.tabPageApiKey.ResumeLayout(false);
            this.tabPageApiKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInfoText;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageApiKey;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageUnits;
        private System.Windows.Forms.RadioButton radioButtonTempCelsius;
        private System.Windows.Forms.GroupBox groupBoxTempUnit;
        private System.Windows.Forms.RadioButton radioButtonTempFahrenheit;
        private System.Windows.Forms.RadioButton radioButtonTempKelvin;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.GroupBox groupBoxWindSpeed;
        private System.Windows.Forms.RadioButton radioButtonMS;
        private System.Windows.Forms.RadioButton radioButtonMPH;
        private System.Windows.Forms.RadioButton radioButtonKMH;
    }
}