using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace Weather
{
    public partial class main : Form
    {
        //create a 'shortcut' for the settings file
        Weather.Properties.Settings settings = Properties.Settings.Default;

        // list with the 40 forecasts
        List<forecastData> fcDl = new List<forecastData>();

        // counter for the current page of the forecast data
        int forecastPage = 0;

        // needed for double.TryParse()
        double d;

        // the variables for the current-weather info
        #region variables_currentWeather
        string cityID;
        string cityName;
        double cityCoordLon;
        double cityCoordLat;
        string country;
        string sunRise;
        string sunSet;
        double tempVal;
        double tempMin;
        double tempMax;
        string tempUnit;
        double humidity;
        string humidityUnit;
        double pressure;
        string pressureUnit;
        double windSpeedValue;
        string windSpeedName;
        double windDirectionValue;
        string windDirectionCode;
        string windDirectionName;
        double cloudsValue;
        string cloudsName;
        double visibilityValue;
        double precipitationValue;
        string precipitationMode;
        int weatherNumber;
        string weatherValue;
        string weatherIcon;
        string lastUpdate;
        #endregion

        public main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// downloads and reads the xml file for the current weather from openweathermap.org
        /// </summary>
        public void readXmlCurrent()
        {
            // read the stored xml-file from the settings. if there is an internet connection it gets overwritten
            XDocument currentXml = XDocument.Parse(settings.currentXml);

            // trys to download the current data from the openweathermap-api
            try
            {
                String[] currentCityID = settings.cityID.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                // get the data from the api and store it in a XDocument
                currentXml = XDocument.Load("http://api.openweathermap.org/data/2.5/weather?id=" + currentCityID[currentCityID.Length - 1] + "&appid=" + settings.apikey + "&mode=xml&units=metric");

                // save the xdocument to the settings
                settings.currentXml = currentXml.ToString();
            }
            catch
            {
                // checks for an internet connection
                if (checkInternet())
                { // exception caused by an invalid cityID or api-key
                    MessageBox.Show("You have entered an invalid cityID or an invalid api-key. Please check if they are correct.", "Invalid cityID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { // exception caused by a non existing internet connection
                    MessageBox.Show("You have no connection to the internet. Showing the saved data.", "No internet connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            XElement current = currentXml.Element("current");

            XElement city = current.Element("city");

            // read the city id and name
            #region read_city
            cityID = (string)city.Attribute("id");
            cityName = (string)city.Attribute("name");
            #endregion

            // read the coordinates
            #region read_coord
            XElement coord = city.Element("coord");
            if (((string)coord.Attribute("lon"))[0] == '-') // longitude
            {
                double.TryParse(((string)coord.Attribute("lon")).Split(new Char[] { '-' })[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);

                cityCoordLon = -1 * d;
            }
            else
            {
                double.TryParse(((string)coord.Attribute("lon")), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);

                cityCoordLon = d;
            }
            if (((string)coord.Attribute("lat"))[0] == '-') // latitude
            {
                double.TryParse(((string)coord.Attribute("lat")).Split(new Char[] { '-' })[1], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);

                cityCoordLat = -1 * d;
            }
            else
            {
                double.TryParse(((string)coord.Attribute("lat")), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);

                cityCoordLat = d;
            }
            #endregion

            // read the country letters
            #region read_country
            country = (string)city.Element("country").Value;
            #endregion

            // read the sunrise / -set
            #region read_suns
            XElement sun = city.Element("sun");
            sunRise = (string)sun.Attribute("rise");
            sunSet = (string)sun.Attribute("set");
            #endregion

            // read the temperature
            #region read_temp
            XElement temperature = current.Element("temperature");
            double.TryParse((string)temperature.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            tempVal = d;
            double.TryParse((string)temperature.Attribute("min"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            tempVal = d;
            double.TryParse((string)temperature.Attribute("max"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            tempMax = d;
            tempUnit = (string)temperature.Attribute("unit");
            #endregion

            // read the humidity
            #region read_humidity
            XElement hum = current.Element("humidity");
            double.TryParse((string)hum.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            humidity = d;
            humidityUnit = (string)hum.Attribute("unit");
            #endregion

            // read the pressure
            #region read_pressure
            XElement press = current.Element("pressure");
            double.TryParse((string)press.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            pressure = d;
            pressureUnit = (string)press.Attribute("unit");
            #endregion

            // read the wind
            #region read_wind
            XElement wind = current.Element("wind");

            XElement windSpeed = wind.Element("speed");
            XElement windDir = wind.Element("direction");

            double.TryParse((string)windSpeed.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            windSpeedValue = d;
            windSpeedName = (string)windSpeed.Attribute("name");

            double.TryParse((string)windDir.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            windDirectionValue = d;
            windDirectionCode = (string)windDir.Attribute("code");
            windDirectionName = (string)windDir.Attribute("name");
            #endregion

            // read the clouds
            #region read_clouds
            XElement clouds = current.Element("clouds");
            double.TryParse((string)clouds.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            cloudsValue = d;
            cloudsName = (string)clouds.Attribute("name");
            #endregion

            // read visibility
            #region read_visibility
            XElement visibility = current.Element("visibility");
            double.TryParse((string)visibility.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            visibilityValue = d;
            #endregion

            // read precipitation
            #region read_precipitation
            XElement precipitation = current.Element("precipitation");
            double.TryParse((string)precipitation.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
            precipitationValue = d;
            precipitationMode = (string)precipitation.Attribute("mode");
            #endregion

            // read weather
            #region read_weather
            XElement weather = current.Element("weather");
            int i;
            int.TryParse((string)weather.Attribute("number"), out i);
            weatherNumber = i;
            weatherValue = (string)weather.Attribute("value");
            weatherIcon = (string)weather.Attribute("icon");
            #endregion

            // read the last update
            #region read_lastUpdate
            lastUpdate = (string)current.Element("lastupdate").Attribute("value");
            #endregion
        }

        /// <summary>
        /// downloads and reads the xml file for the forecast from openweathermap.org
        /// </summary>
        public void readXmlForecast()
        {
            // read the stored xml-file from the settings. if there is an internet connection it gets overwritten
            XDocument forecastXml = XDocument.Parse(settings.forecastXml);

            try
            {
                String[] currentCityID = settings.cityID.Split(new char[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                // loads the data from the api
                forecastXml = XDocument.Load("http://api.openweathermap.org/data/2.5/forecast?id=" + currentCityID[currentCityID.Length - 1] + "&mode=xml&appid=" + settings.apikey + "&units=metric");

                // saves the XDocument to the settings
                settings.forecastXml = forecastXml.ToString();
            }
            catch
            {

            }

            XElement weatherdata = forecastXml.Element("weatherdata");

            XElement forecast = weatherdata.Element("forecast");

            int i = 0;
            foreach (XElement time in forecast.Elements("time"))
            {
                fcDl.Add(new forecastData(i));

                // reads and saves the from- and to-times of the coming measurement
                #region read_times
                fcDl[i].timeFrom = (string)time.Attribute("from");
                fcDl[i].timeTo = (string)time.Attribute("to");
                #endregion

                // read and save the symbol parameters
                #region read_symbols
                XElement symbol = time.Element("symbol");
                fcDl[i].symbolName = (string)symbol.Attribute("name");
                fcDl[i].symbolNumber = (string)symbol.Attribute("number");
                fcDl[i].symbolVar = (string)symbol.Attribute("var");
                #endregion

                // read and save precipitation values
                #region read_precipitation
                XElement preci = time.Element("precipitation");
                fcDl[i].precipitationValue = (string)preci.Attribute("value");
                fcDl[i].precipitationUnit = (string)preci.Attribute("unit");
                fcDl[i].precipitationType = (string)preci.Attribute("type");
                #endregion

                // read and save wind-direction values
                #region read_windDirection
                XElement windDirection = time.Element("windDirection");
                fcDl[i].windDirectionDeg = (string)windDirection.Attribute("deg");
                fcDl[i].windDirectionCode = (string)windDirection.Attribute("code");
                fcDl[i].windDirectionName = (string)windDirection.Attribute("name");
                #endregion

                // read and save wind-speed values
                #region read_windSpeed
                XElement windSpeed = time.Element("windSpeed");
                double.TryParse((string)windSpeed.Attribute("mps"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
                fcDl[i].windSpeedValue = d;
                fcDl[i].windSpeedName = (string)windSpeed.Attribute("name");
                #endregion

                // read and save the temperature
                #region read_temperature
                XElement temp = time.Element("temperature");
                fcDl[i].temperatureUnit = (string)temp.Attribute("unit");
                double.TryParse((string)temp.Attribute("value"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
                fcDl[i].temperatureValue = d;
                double.TryParse((string)temp.Attribute("min"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
                fcDl[i].temperatureMax = d;
                double.TryParse((string)temp.Attribute("max"), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out d);
                fcDl[i].temperatureMin = d;
                #endregion

                // read and save pressure values
                #region read_pressure
                XElement pressure = time.Element("pressure");
                fcDl[i].pressureUnit = (string)pressure.Attribute("unit");
                fcDl[i].pressureValue = (string)pressure.Attribute("value");
                #endregion

                // read and save humidity values
                #region read_humidity
                XElement humidity = time.Element("humidity");
                fcDl[i].humidityUnit = (string)humidity.Attribute("unit");
                fcDl[i].humidityValue = (string)humidity.Attribute("value");
                #endregion

                // read and save the cloud values
                #region read_clouds
                XElement clouds = time.Element("clouds");
                fcDl[i].cloudsValue = (string)clouds.Attribute("value");
                fcDl[i].cloudsAll = (string)clouds.Attribute("all");
                fcDl[i].cloudsUnit = (string)clouds.Attribute("unit");
                #endregion

                i++;
            }

            // adds the dates to the combobox
            #region add_dates
            foreach (var item in fcDl)
            {
                comboBox1.Items.Add(item.timeTo.Replace('T', ' '));
            }

            // adds the dates to the domain-up-down
            foreach (var item in comboBox1.Items)
            {
                domainUpDown1.Items.Add(item);
            }
            #endregion
        }

        /// <summary>
        /// writes the data stored in the variables in the textboxes
        /// </summary>
        public void showDataCurrent()
        {
            if (cityName != "")
            {
                // write the city name in the header
                this.Text = "Weather - " + cityName;

                // show city name
                textBoxCity.Text = cityName;

                // show coordinates
                #region show_coordinates
                if (cityCoordLat < 0)
                {
                    textBoxCoord.Text = cityCoordLat.ToString() + "°S";
                }
                else
                {
                    textBoxCoord.Text = cityCoordLat.ToString() + "°N";
                }
                textBoxCoord.Text += ' ';
                if (cityCoordLon < 0)
                {
                    textBoxCoord.Text += cityCoordLon.ToString() + "°W";
                }
                else
                {
                    textBoxCoord.Text += cityCoordLon.ToString() + "°E";
                }
                #endregion

                // show sunrise time
                #region show_sunrise
                String sunRiseNew = "";
                Boolean startTime = false;
                for (int a = 0; a < sunRise.Length; a++)
                {
                    if (startTime)
                    {
                        sunRiseNew += sunRise[a];
                    }
                    if (sunRise[a] == 'T')
                    {
                        startTime = true;
                    }
                }
                textBoxSunRise.Text = sunRiseNew;
                #endregion

                // show sunset time
                #region show_sunset
                String sunSetNew = "";
                startTime = false;
                for (int a = 0; a < sunSet.Length; a++)
                {
                    if (startTime)
                    {
                        sunSetNew += sunSet[a];
                    }
                    if (sunSet[a] == 'T')
                    {
                        startTime = true;
                    }
                }
                textBoxSunSet.Text = sunSetNew;
                #endregion

                // show temp
                #region show_temp
                switch (settings.setTempUnit)
                {
                    case "Celsius":
                        textBoxTemp.Text = tempVal.ToString() + "°C";
                        break;

                    case "Fahrenheit":
                        textBoxTemp.Text = Math.Round(tempVal *1.8 + 32, 2).ToString() + "°F";
                        break;

                    case "Kelvin":
                        textBoxTemp.Text = (tempVal + 273.15).ToString() + "°K";
                        break;
                }
                #endregion

                // show tempMin
                #region show_tempMin
                switch (settings.setTempUnit)
                {
                    case "Celsius":
                        textBoxTempMin.Text = tempMin.ToString() + "°C";
                        break;

                    case "Fahrenheit":
                        textBoxTempMin.Text = Math.Round(tempMin * 1.8 + 32, 2).ToString() + "°F";
                        break;

                    case "Kelvin":
                        textBoxTempMin.Text = (tempMin + 273.15).ToString() + "°K";
                        break;
                }
                #endregion

                // show tempMax
                #region show_tempMax
                switch (settings.setTempUnit)
                {
                    case "Celsius":
                        textBoxTempMax.Text = tempMax.ToString() + "°C";
                        break;

                    case "Fahrenheit":
                        textBoxTempMax.Text = Math.Round(tempMax * 1.8 + 32, 2).ToString() + "°F";
                        break;

                    case "Kelvin":
                        textBoxTempMax.Text = (tempMax + 273.15).ToString() + "°K";
                        break;
                }
                #endregion

                // show humidity
                textBoxHumidity.Text = humidity.ToString() + humidityUnit;

                // show pressure
                textBoxPressure.Text = pressure.ToString() + pressureUnit;

                // show windSpeedValue
                #region show_windSpeedValue
                switch (settings.setWindSpeedUnit)
                {
                    case "m/s":
                        textBoxWindSpeedValue.Text = windSpeedValue.ToString() + "m/s";
                        break;

                    case "km/h":
                        textBoxWindSpeedValue.Text = Math.Round(windSpeedValue * 3.6, 2).ToString() + "km/h";
                        break;

                    case "mi/h":
                        textBoxWindSpeedValue.Text = Math.Round(windSpeedValue * 2.2369362920544, 2).ToString() + "mi/s";
                        break;
                }
                #endregion

                // show windSpeedName
                textBoxWindSpeedName.Text = windSpeedName;

                // show windDirectionValue
                textBoxWindDirectionValue.Text = windDirectionValue.ToString() + "°";

                // show windDirectionCode
                textBoxWindDirectionCode.Text = windDirectionCode;

                // show windDirectionName
                textBoxWindDirectionName.Text = windDirectionName;

                // show cloudsValue
                textBoxCloudsValue.Text = cloudsValue.ToString() + "%";

                // show cloudsName
                textBoxCloudsName.Text = cloudsName;

                // show visibility
                #region show_visibility
                if (visibilityValue != 0)
                {
                    textBoxVisibility.Text = visibilityValue.ToString() + "m";
                }
                #endregion

                // show precipitation
                #region show_precipitation
                if (precipitationMode != "no")
                {
                    textBoxPrecipitationMode.Text = precipitationMode;
                }
                textBoxPrecipitationValue.Text = precipitationValue.ToString() + "mm";
                #endregion

                // show weather icon
                #region show_weathericon
                try
                {
                    pictureBoxWeatherIcon.Load("http://openweathermap.org/img/w/" + weatherIcon + ".png");
                }
                catch (Exception ex) when (ex is FormatException || ex is WebException)
                {

                }
                #endregion

                // show lastupdate
                textBoxLastUpdate.Text = lastUpdate.Replace('T', ' ');
            }
            else // if no data is loaded, header is default and boxes get emptied
            {
                // show a neutral header
                this.Text = "Weather";

                // clear city name
                textBoxCity.Text = "";

                // clear coordinates
                textBoxCoord.Text = "";

                // clear sunrise 
                textBoxSunRise.Text = "";

                // clear sunset time
                textBoxSunSet.Text = "";

                // clear temp
                textBoxTemp.Text = "";

                // clear tempMin
                textBoxTempMin.Text = "";

                // clear tempMax
                textBoxTempMax.Text = "";

                // clear humidity
                textBoxHumidity.Text = "";

                // clear pressure
                textBoxPressure.Text = "";

                // clear windSpeedValue
                textBoxWindSpeedValue.Text = "";

                // clear windSpeedName
                textBoxWindSpeedName.Text = "";

                // clear windDirectionValue
                textBoxWindDirectionValue.Text = "";

                // clear windDirectionCode
                textBoxWindDirectionCode.Text = "";

                // clear windDirectionName
                textBoxWindDirectionName.Text = "";

                // clear cloudsValue
                textBoxCloudsValue.Text = "";

                // clear cloudsName
                textBoxCloudsName.Text = "";

                // clear visibility"
                textBoxVisibility.Text = "";

                // clear precipitation
                textBoxPrecipitationMode.Text = ""; ;
                textBoxPrecipitationValue.Text = "";

                // clear weather icon
                pictureBoxWeatherIcon.Image = null;

                // clear last update
                textBoxLastUpdate.Text = "";
            }
        }

        /// <summary>
        /// If executed, it shows the forecast data in the boxes
        /// </summary>
        public void showDataForecast()
        {
            if (cityName != "")
            {
                // show time / date
                textBoxTime.Text = fcDl[forecastPage].timeTo.Replace('T', ' ');

                // show weather image
                #region show_weather_image
                try
                {
                    fPictureBoxWeatherIcon.Load("http://openweathermap.org/img/w/" + fcDl[forecastPage].symbolVar + ".png");
                }
                catch (Exception ex) when (ex is FormatException || ex is WebException)
                {

                }
                #endregion

                // show the weather name
                fTextBoxWeather.Text = fcDl[forecastPage].symbolName;

                // show wind name
                fTextBoxWindName.Text = fcDl[forecastPage].windSpeedName + ", " + fcDl[forecastPage].windDirectionName;

                // show wind value
                #region show_wind_value
                switch (settings.setWindSpeedUnit)
                {
                    case "m/s":
                        fTextBoxWindValue.Text = fcDl[forecastPage].windSpeedValue + "m/s";
                        break;

                    case "km/h":
                        fTextBoxWindValue.Text = Math.Round(fcDl[forecastPage].windSpeedValue * 3.6, 2).ToString() + "km/h";
                        break;

                    case "mi/h":
                        fTextBoxWindValue.Text = Math.Round(fcDl[forecastPage].windSpeedValue * 2.2369362920544, 2).ToString() + "mi/s";
                        break;
                }
                fTextBoxWindValue.Text += " " + fcDl[forecastPage].windDirectionCode;
                #endregion

                // show the temperature
                #region show_temperature
                switch (settings.setTempUnit)
                {
                    case "Celsius":
                        fTextBoxTemp.Text = fcDl[forecastPage].temperatureValue.ToString() + "°C";
                        break;

                    case "Fahrenheit":
                        fTextBoxTemp.Text = Math.Round(fcDl[forecastPage].temperatureValue * 1.8 + 32, 2).ToString() + "°F";
                        break;

                    case "Kelvin":
                        fTextBoxTemp.Text = (fcDl[forecastPage].temperatureValue + 273.15).ToString() + "°K";
                        break;
                }
                #endregion

                // show the pressure
                fTextBoxPressure.Text = fcDl[forecastPage].pressureValue + fcDl[forecastPage].pressureUnit;

                // show the humidity
                fTextBoxHumidity.Text = fcDl[forecastPage].humidityValue + fcDl[forecastPage].humidityUnit;

                // show the clouds
                fTextBoxClouds.Text = fcDl[forecastPage].cloudsValue;
            }
            else
            {
                // clear time / date
                textBoxTime.Text = "";

                // clear weather image
                fPictureBoxWeatherIcon.Image = null;

                // clear the weather name
                fTextBoxWeather.Text = "";

                // clear wind name
                fTextBoxWindName.Text = "";

                // clear wind value
                fTextBoxWindValue.Text = "";

                // clear the temperature
                fTextBoxTemp.Text = "";

                // clear the pressure
                fTextBoxPressure.Text = "";

                // clear the humidity
                fTextBoxHumidity.Text = "";

                // clear the clouds
                fTextBoxClouds.Text = "";
            }
        }

        /// <summary>
        /// checsk for an internet connection trhough connecting to example.org
        /// </summary>
        public bool checkInternet()
        {
            try
            {
                using (new WebClient().OpenRead("http://example.org/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// if called, opens the settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new settings(null).ShowDialog();
        }

        // gets executed if the form gets loaded; downloads and shows the weather infos
        private void main_Load(object sender, EventArgs e)
        {   
            //checks if a api-key is setted
            if (settings.apikey == "")
            { // if not, announce a change to settings
                MessageBox.Show("You need a API-key for the programm to work.\r\nGo to settings and insert one.", "API-key needed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                new settings("api").ShowDialog();
            }
            else
            {
                readXmlCurrent();

                readXmlForecast();
            }

            // Select the first one in the combobox and the domain-up-down
            domainUpDown1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            showDataCurrent();

            showDataForecast();

            // selects the city label --> clouds box not selected
            labelCity.Select();
        }

        // refreshs the weather infos
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readXmlCurrent();
            readXmlForecast();

            showDataCurrent();
            showDataForecast();
        }

        /// <summary>
        /// If called, shows weather data credits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The weather data comes from openweather.com\r\nNavigate to site?", "Weather-data credits", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("http://openweathermap.org/");
            }
        }

        /// <summary>
        /// If called, shows the credits for the icons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All icons came from icons8.com\r\nNavigate to site?", "Icon credits", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("http://icons8.com/license/");
            }
        }

        /// <summary>
        /// Opens the bookmarks form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookmarks bookmarks = new bookmarks();
            bookmarks.ShowDialog();
        }

        /// <summary>
        /// If executed: closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// gets executed if the selected item in the combo-box gets changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // sets the current forecastpage to the selected entry
            forecastPage = comboBox1.SelectedIndex;

            // reloads the data in the forecast boxes
            showDataForecast();

            // selects in the domain-up-down the correct entry
            domainUpDown1.SelectedIndex = comboBox1.SelectedIndex;
        }

        /// <summary>
        /// gets executed if the selected item in the domain-up-down gets changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            // sets the current forecastpage to the selected entry
            forecastPage = domainUpDown1.SelectedIndex;

            // reloads the data in the forecast boxes
            showDataForecast();

            // selects in the combobox the correct entry
            comboBox1.SelectedIndex = domainUpDown1.SelectedIndex;
        }

        /// <summary>
        /// gets executed if the from closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.Save(); // saves the settings
        }

        /// <summary>
        /// Shows the version of the programm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The current version is " + settings.version, "Version Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// shows a link to the blog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void developedByJ3n0WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Developed by J3n0W.\r\nGo to the blog?", "Developer info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://j3n0w.wordpress.com/");
            }
        }
    }
}
