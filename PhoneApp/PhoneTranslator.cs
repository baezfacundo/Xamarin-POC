using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PhoneApp
{
    public class PhoneTranslator
    {
        string Letters = "ABCDEFGHIJKMOPQRSTUVWXYZ";
        string Numbers = "222333444555666777788899999";

        public string ToNumber(string alfanumericPhoneNumber)
        {
            var numericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alfanumericPhoneNumber))
            {
                alfanumericPhoneNumber = alfanumericPhoneNumber.ToUpper();
                foreach (var c in alfanumericPhoneNumber)
                {
                    if ("0123456789".Contains(c))
                    {
                        numericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var Index = Letters.IndexOf(c);
                        if(Index >=0)
                        {
                            numericPhoneNumber.Append(Numbers[Index]);
                        }
                    }
                }
                return numericPhoneNumber.ToString();
            }
            return string.Empty;
        }
    }
   
}