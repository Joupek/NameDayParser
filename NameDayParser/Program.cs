using System;
using System.Collections.Generic;
using System.IO;
using System.Configuration;

namespace NameDayParser
{
    class Program
    {
        private static  Dictionary<string, string> _nameDays;
      

        static void Main(string[] args)
        {
           //_nameDays = new Dictionary<string, string>();
            try
            {
                if (args.Length < 1 || args.Length > 1)
                {
                     throw new Exception("Give date in format dd.MM.yyyy");
                }
                var datearg = args[0];
                if (NameDay.IsDateTime(datearg))
                {
                    var seekdate = DateTime.Parse(datearg);
                    var nameDay = new NameDay();
                    var result = nameDay.FindNameDay(seekdate.ToString("dd.MM."));
                    if(!string.IsNullOrEmpty(result))
                        Console.WriteLine(result);
                    else
                        Console.WriteLine("No Data");

                }
                else
                   throw new Exception("Given Date in not valid format");
                
            }
            catch (Exception  e)
            {
                Console.WriteLine(e);
            }
               
        }
       
    }
    
}
