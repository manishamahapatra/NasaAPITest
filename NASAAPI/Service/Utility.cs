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
        public static string ParseDateTime(string date)
        {
            DateTime d= DateTime.Parse(date);
            return d.ToString("yyyy-MM-dd");
        }
        public static string GetImageFileName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string fileName = "";

            if (parts.Length > 0)
                fileName = parts[parts.Length - 1];
            else
                fileName = hrefLink;

            return fileName;
        }

    }
}