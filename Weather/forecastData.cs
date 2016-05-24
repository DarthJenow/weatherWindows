using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class forecastData
    {
        int number;

        public String timeFrom;
        public String timeTo;

        public String symbolNumber;
        public String symbolName;
        public String symbolVar;

        public String precipitationValue;
        public String precipitationUnit;
        public String precipitationType;

        public String windDirectionDeg;
        public String windDirectionCode;
        public String windDirectionName;

        public double windSpeedValue;
        public String windSpeedName;

        public double temperatureValue;
        public double temperatureMax;
        public double temperatureMin;
        public String temperatureUnit;

        public String pressureValue;
        public String pressureUnit;

        public String humidityValue;
        public String humidityUnit;

        public String cloudsAll;
        public String cloudsValue;
        public String cloudsUnit;

        public forecastData(int args)
        {
            number = args;
        }
    }
}
