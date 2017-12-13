using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayParser
{
    public class NameDay
    {
        private string _path;
        private Dictionary<string, string> _nameDays;

        public NameDay()
        {
            _nameDays = new Dictionary<string, string>();
            var appSettings = ConfigurationManager.AppSettings;
            _path = appSettings["Path"] ?? throw new Exception("Path key is missing in application file");
            ReadFile();
        }
        private void ReadFile()
        {
            using (var reader = new StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var namedayparts = line.Split(';');
                    if (validateRow(namedayparts))
                    {
                        if (!_nameDays.ContainsKey(namedayparts[0]))
                            _nameDays.Add(namedayparts[0], namedayparts[1]);

                    }
                    else
                        throw new Exception("Row data is not valid");

                }
            }
        }
        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }
        public string FindNameDay(string date)
        {
            if (_nameDays.ContainsKey(date))
            {
                return _nameDays[date];
            }
            else
            {
                return string.Empty;
            }
        }
        private bool validateRow(string[] line)
        {   
            if (line.Length == 2 && !string.IsNullOrEmpty(line[0]) && !string.IsNullOrEmpty(line[1]))
            {

                return true;
            }
            return false;

        }
    }
}
