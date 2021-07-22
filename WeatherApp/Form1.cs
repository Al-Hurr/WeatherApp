using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp.Models;

namespace WeatherApp
{

    public partial class Form1 : Form
    {
        public List<City> Cities { get; set; }
        public List<string> RefreshTime = new List<string> { "0,5", "1", "5", "10", "15", "15" };

        System.Windows.Forms.Timer RefreshTimer = new System.Windows.Forms.Timer();
        public int Interval { get; set; }
        public WeatherInfo weatherInfo { get; set; }

        public Form1()
        {
            InitializeComponent();
            var cityNames = InitializeCities();
            citiesCombo.DataSource = Cities;
            citiesCombo.DisplayMember = "Name";
            refreshCombo.DataSource = RefreshTime;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var city = (City)citiesCombo.SelectedItem;

            weatherInfo = RequestClass.GetWeather(city.Latitude, city.Longitude, "ru_RU", true.ToString());

            listBox1.Items.Clear();
            listBox1.Items.AddRange(new string[]
            {
                    "Название города:   " + weatherInfo.CityName,
                    "Дата:   " + weatherInfo.Now,
                    "Температура (°C):   " + weatherInfo.Temp,
                    "Ощущаемая температура (°C):   " + weatherInfo.FeelLike,
                    "Описание погоды:   " + weatherInfo.Сondition,
                    "Скорость ветра (в м/с):   " + weatherInfo.WindSpeed,
                    "Направление ветра:   " + weatherInfo.WindDir,
                    "Давление (в мм рт. ст.):   " + weatherInfo.PressureMm,
                    "Влажность воздуха (в процентах):   " + weatherInfo.Humidity,
                    "Время суток:   " + weatherInfo.Daytime,
                    "Сезон:   " + weatherInfo.Season,
                    "Тип осадков:   " + weatherInfo.PrecType,
                    "Облачность:   " + weatherInfo.Cloudness
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTimer.Interval = Interval != default(int) ? Interval : 60000;
            RefreshTimer.Tick += new System.EventHandler(comboBox1_SelectedIndexChanged);
            RefreshTimer.Start();
        }

        private string[] InitializeCities()
        {
            Cities = new List<City>
            {
                new City
                {
                    Name = "Казань",
                    Latitude = "55.795793",
                    Longitude = "49.106585"
                },
                new City
                {
                    Name = "Ижевск",
                    Latitude = "56.852775",
                    Longitude = "53.211463"
                },
                new City
                {
                    Name = "Москва",
                    Latitude = "55.755773",
                    Longitude = "37.617761"
                }
            };

            return Cities.Select(x => x.Name).ToArray();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // Добавление
                db.WeatherInfos.Add(weatherInfo);
                db.SaveChanges();

                MessageBox.Show("Сохранено!");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTimer.Stop();
            Interval = (int)(60000 * float.Parse((string)refreshCombo.SelectedItem));
            Form1_Load(sender, e);
        }
    }
}
