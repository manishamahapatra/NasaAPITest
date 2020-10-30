using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace NasaAPIProject.NASAAPI.Service
{
    public static  class Utility
    {
        public static string convertToDate(string date)
        {
            DateTime dateTime=DateTime.Parse(date);

            return null;
        }
        public static string[] GetAllDates()
        {
            
            string[] dates=File.ReadAllLines(@"..\NASAAPI\dates.txt");

            return dates;
        }
        public static DateTime ParseDateTime(string date)
        {
            return !DateTime.TryParse(date, out var result) ? DateTime.MinValue : result;
        }
    }
}