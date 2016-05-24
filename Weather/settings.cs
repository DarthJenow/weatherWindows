using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public partial class settings : Form
    {
        public settings(String startPoint)
        {
            InitializeComponent();

            textBoxApiKey.Text = Properties.Settings.Default.apikey; // loads the current api-key in the textbox

            switch (startPoint)
            {
                case "api":
                    tabControlSettings.SelectedTab = tabPageApiKey;
                    break;
            }
        }

        /// <summary>
        /// If clicked, it opens the website where you can find your api-key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://home.openweathermap.org/api_keys");
        }

        /// <summary>
        /// If the form closes, it checks if there are any unsaved changes. if yes it warns you
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Boolean askSave = false;

            // check for unsaved changes
            askSave = radioButtonTempCelsius.Checked != (Properties.Settings.Default.setTempUnit == "Celsius");
            askSave = radioButtonTempFahrenheit.Checked != (Properties.Settings.Default.setTempUnit == "Fahrenheit") || askSave;
            askSave = radioButtonTempKelvin.Checked != (Properties.Settings.Default.setTempUnit == "Kelvin") || askSave;
            askSave = radioButtonKMH.Checked != (Properties.Settings.Default.setWindSpeedUnit == "km/h") || askSave;
            askSave = radioButtonMPH.Checked != (Properties.Settings.Default.setWindSpeedUnit == "mi/h") || askSave;
            askSave = radioButtonMS.Checked != (Properties.Settings.Default.setWindSpeedUnit == "m/s") || askSave;
            askSave = (textBoxKey.Text != Properties.Settings.Default.apikey) || askSave;

            // warn user
            if (askSave)
            {
                if (MessageBox.Show("Do you really want to close? All unsaved changes get lost.", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// saves the data if executed
        /// </summary>
        private void saveData ()
        {
            Weather.Properties.Settings settings = Properties.Settings.Default;

            // save units
            if (radioButtonTempCelsius.Checked)
            {
                settings.setTempUnit = "Celsius";
            }
            if (radioButtonTempFahrenheit.Checked)
            {
                settings.setTempUnit = "Fahrenheit";
            }
            if (radioButtonTempKelvin.Checked)
            {
                settings.setTempUnit = "Kelvin";
            }

            if (radioButtonMS.Checked)
            {
                settings.setWindSpeedUnit = "m/s";
            }
            if (radioButtonKMH.Checked)
            {
                settings.setWindSpeedUnit = "km/h";
            }
            if (radioButtonMPH.Checked)
            {
                settings.setWindSpeedUnit = "mi/h";
            }

            settings.apikey = textBoxKey.Text; // save the api-key in the textbox to the settings

            settings.Save(); // save the settings file

            // reloads the data in the main form
            if (System.Windows.Forms.Application.OpenForms["main"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["main"] as main).readXmlCurrent();
                (System.Windows.Forms.Application.OpenForms["main"] as main).showDataCurrent();
            }
        }

        /// <summary>
        /// Gets executed if the save button gets klicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveData();
            this.Close();
        }

        /// <summary>
        /// Gets executed if the cancel button gets klicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Gets executed if the apply button gets klicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        /// <summary>
        /// Gets executed if the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settings_Load(object sender, EventArgs e)
        {
            // Selects the current active temperature unit
            switch (Properties.Settings.Default.setTempUnit)
            {
                case "Celsius":
                    radioButtonTempCelsius.Checked = true;
                    break;
                case "Fahrenheit":
                    radioButtonTempFahrenheit.Checked = true;
                    break;
                case "Kelvin":
                    radioButtonTempKelvin.Checked = true;
                    break;
            }

            // Selects the current active speed unit
            switch (Properties.Settings.Default.setWindSpeedUnit)
            {
                case "m/s":
                    radioButtonMS.Checked = true;
                    break;

                case "km/h":
                    radioButtonKMH.Checked = true;
                    break;

                case "mi/h":
                    radioButtonMPH.Checked = true;
                    break;
            }

            // load api-key
            textBoxKey.Text = Properties.Settings.Default.apikey;
        }
    }
}
