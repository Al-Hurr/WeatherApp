using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public static class RequestClass
    {
        public const string _api = "89c47b39-a986-4876-bfad-613d50650288";

        static string _lat { get; set; }
        static string _lon { get; set; }
        static string _lang { get; set; }
        static string _extra { get; set; }

        static string _url = "";

        public static WeatherInfo GetWeather(string lat, string lon, string lang, string extra)
        {
            _url = $"https://api.weather.yandex.ru/v2/forecast?lat={lat}&lon={lon}&lang={lang}&extra={extra}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers["X-Yandex-API-Key"] = _api;
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            JObject valuePairs = JObject.Parse(response);

            WeatherInfo weatherInfo = new WeatherInfo()
            {
                CityName = valuePairs["geo_object"]["locality"]["name"].ToString(),
                Now = DateTime.Parse(valuePairs["now_dt"].ToString()),
                Temp = valuePairs["fact"]["temp"].ToString(),
                FeelLike = valuePairs["fact"]["feels_like"].ToString(),
                Сondition = WeatherInfo.GetCondition(valuePairs["fact"]["condition"].ToString()),
                WindSpeed = valuePairs["fact"]["wind_speed"].ToString(),
                WindDir = WeatherInfo.GetWindDir(valuePairs["fact"]["wind_dir"].ToString()),
                PressureMm = valuePairs["fact"]["pressure_mm"].ToString(),
                Humidity = valuePairs["fact"]["humidity"].ToString(),
                Daytime =  WeatherInfo.GetDayTime(valuePairs["fact"]["daytime"].ToString()),
                Season = WeatherInfo.GetSeason(valuePairs["fact"]["season"].ToString()),
                PrecType = WeatherInfo.GetPrecType(valuePairs["fact"]["prec_type"].ToString()),
                Cloudness = WeatherInfo.GetCloudness(valuePairs["fact"]["cloudness"].ToString())
            };
            return weatherInfo;
        }
    }
}
