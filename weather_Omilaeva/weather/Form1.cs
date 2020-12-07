
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;

namespace weather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string url = "http://api.openweathermap.org/data/2.5/weather?q=Donetsk&appid=1eaa4e8c2e0d05fef8140b2d11fbf888&units=metric";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string response = reader.ReadToEnd();
            richTextBox1.Text = response;
            WeatherResponse wr = JsonConvert.DeserializeObject<WeatherResponse>(response);
            lCity.Text = wr.Name;
            lTemp.Text = wr.Main.temp.ToString();
        }
    }
}
