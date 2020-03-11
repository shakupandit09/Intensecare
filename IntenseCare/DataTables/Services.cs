using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IntenseCare.Models
{
    public class Services
    {
        static Random R = new Random(0001);
        public static string GeneratePIN()
        {
            string PIN;
            PIN = R.Next(1111, 9999).ToString();
            return PIN;
        }
    }
}