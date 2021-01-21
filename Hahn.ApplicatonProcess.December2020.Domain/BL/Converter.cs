using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hahn.ApplicatonProcess.December2020.Domain    
{
    public static class Converter
    {
        public static string Base64Encode(object obj)
        {
            string plainText = JsonConvert.SerializeObject(obj);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static object GenApplicantId(object obj)
        {
            try
            {
                var rand = new Random();
                var applicant = (Applicant)obj;
                applicant.ID = rand.Next().ToString();
                return applicant;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
