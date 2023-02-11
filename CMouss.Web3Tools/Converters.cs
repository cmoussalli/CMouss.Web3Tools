using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CMouss.Web3Tools
{
    public static class Converters
    {
        public static string HexadecimalToDecimalString(string hexadecimalString)
        {
            List<int> dec = new List<int> { 0 };   // decimal result

            foreach (char c in hexadecimalString)
            {
                int carry = Convert.ToInt32(c.ToString(), 16);
                // initially holds decimal value of current hex digit;
                // subsequently holds carry-over for multiplication

                for (int i = 0; i < dec.Count; ++i)
                {
                    int val = dec[i] * 16 + carry;
                    dec[i] = val % 10;
                    carry = val / 10;
                }

                while (carry > 0)
                {
                    dec.Add(carry % 10);
                    carry /= 10;
                }
            }

            var chars = dec.Select(d => (char)('0' + d));
            var cArr = chars.Reverse().ToArray();
            return new string(cArr);
        }

        public static string DecimalToHexadecimalString(string decimalString)
        {
            var bigNumber = BigInteger.Parse(decimalString);
            var b = bigNumber.ToString("X");
            return b;
        }

    }
}
