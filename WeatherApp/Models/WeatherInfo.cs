using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherInfo
    {
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Температура (°C)
        /// </summary>
        public string Temp { get; set; }

        /// <summary>
        /// Ощущаемая температура (°C).	
        /// </summary>
        public string FeelLike { get; set; }

        /// <summary>
        /// Описание погоды.	
        /// </summary>
        public string Сondition { get; set; }

        /// <summary>
        /// Скорость ветра (в м/с)
        /// </summary>
        public string WindSpeed { get; set; }

        /// <summary>
        /// Направление ветра	
        /// </summary>
        public string WindDir { get; set; }

        /// <summary>
        /// Давление (в мм рт. ст.)
        /// </summary>
        public string PressureMm { get; set; }

        /// <summary>
        /// Влажность воздуха (в процентах).
        /// </summary>
        public string Humidity { get; set; }

        /// <summary>
        /// Светлое или темное время суток.
        /// </summary>
        public string Daytime { get; set; }

        /// <summary>
        /// Время года в данном населенном пункте
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Тип осадков
        /// </summary>
        public string PrecType { get; set; }

        /// <summary>
        /// Облачность
        /// </summary>
        public string Cloudness { get; set; }

        /// <summary>
        /// Время сервера в формате Unixtime
        /// </summary>
        public DateTime Now { get; set; }

        public static string GetCondition(string condition)
        {
            switch (condition)
            {
                case "clear":
                    return "ясно";

                case "partly-cloudy":
                    return "малооблачно";

                case "cloudy":
                    return "облачно с прояснениями";

                case "overcast":
                    return "пасмурно";

                case "drizzle":
                    return "морось";

                case "light-rain":
                    return "небольшой дождь";

                case "rain":
                    return "дождь";

                case "moderate-rain":
                    return "умеренно сильный дождь";

                case "heavy-rain":
                    return "сильный дождь";

                case "continuous-heavy-rain":
                    return "длительный сильный дождь";

                case "showers":
                    return "ливень";

                case "wet-snow":
                    return "дождь со снегом";

                case "light-snow":
                    return "небольшой снег";

                case "snow":
                    return "снег";

                case "snow-showers":
                    return "снегопад";

                case "hail":
                    return "град";

                case "thunderstorm":
                    return "гроза";

                case "thunderstorm-with-rain":
                    return "дождь с грозой";

                case "thunderstorm-with-hail":
                    return " гроза с градом";

                default:
                    return "";
            }
        }

        public static string GetWindDir(string windDir)
        {
            switch (windDir)
            {
                case "nw":
                    return "северо-западное";

                case "n":
                    return "северное";

                case "ne":
                    return "северо-восточное";

                case "e":
                    return "восточное";

                case "se":
                    return "юго-восточное";

                case "s":
                    return "южное";

                case "sw":
                    return "юго-западное";

                case "w":
                    return "западное";

                case "с":
                    return "штиль";

                default:
                    return "";
            }
        }

        public static string GetDayTime(string dayTime)
        {
            switch (dayTime)
            {
                case "d":
                    return "светлое время суток";

                case "n":
                    return "темное время суток";

                default:
                    return "";
            }
        }

        public static string GetSeason(string season)
        {
            switch (season)
            {
                case "summer":
                    return "лето";

                case "autumn":
                    return "осень";

                case "winter":
                    return "зима";

                case "spring":
                    return "весна";

                default:
                    return "";
            }
        }

        public static string GetPrecType(string precType)
        {
            switch (precType)
            {
                case "0":
                    return "без осадков";

                case "1":
                    return "дождь";

                case "2":
                    return "дождь со снегом";

                case "3":
                    return "снег";

                case "4":
                    return "град";

                default:
                    return "";
            }
        }

        public static string GetCloudness(string cloudness)
        {
            switch (cloudness)
            {
                case "0":
                    return "ясно";

                case "0,25":
                    return "малооблачно";

                case "0,5":
                    return "облачно с прояснениями";

                case "0,75":
                    return " облачно с прояснениями";

                case "1":
                    return "пасмурно";

                default:
                    return "";
            }
        }
    }
}
