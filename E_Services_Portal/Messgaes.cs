using static Devart.Common.Utils;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace E_Services_Portal
{
   
    public class Messgaes
    {
        private Dictionary<string, string> codes;
        public Messgaes()
        {
            codes = new Dictionary<string, string>()
        {
            {"0000","Success" },
            {"1001", "DB issue please try again later" },
            {"1002", "Email address is already registered." },
             {"1003", "User Not Found" },
                { "1004","Username is required."},
                { "1005","Password is required."},
                     { "1006","Password must be alphanumeric."},
                { "1007","Email is not valid."},
                { "1008","Phone number should be numeric."},
                { "1009","Please enter a phone number."}
            // add more codes and descriptions as needed
        };
        }
        public string Describe(string code)
        {
            if (codes.ContainsKey(code))
            {
                return codes[code];
            }
            else
            {
                return "Unknown code.";
            }
        }
    }
}
