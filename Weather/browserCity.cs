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
    public partial class browserCity : Form
    {
        public browserCity()
        {
            InitializeComponent();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host == "openweathermap.org")
            {
                if (e.Url.AbsoluteUri.Contains("openweathermap.org/city/"))
                {
                    string[] url = e.Url.ToString().Split(new char[] { '/' });

                    MessageBox.Show(url[url.Length - 1]);

                    e.Cancel = true;
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://openweathermap.org/");
        }

        private void browserCity_Load(object sender, EventArgs e)
        {
            buttonHome_Click(null, null);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void buttonFor_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
    }
}
