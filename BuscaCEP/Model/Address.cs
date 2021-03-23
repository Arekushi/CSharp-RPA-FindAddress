using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BuscaCEP.Model
{
    public class Address
    {
        public Address(List<String> values)
        {
            Street = values[0];
            District = values[1];
            Locality = values[2].Split('/')[0];
            UF = values[2].Split('/')[1];
            CEP = values[3];

            IsValid = !string.IsNullOrWhiteSpace(District);
        }

        public Address(IList<IWebElement> values)
        {
            Street = values[0].Text;
            District = values[1].Text;
            Locality = values[2].Text.Split('/')[0];
            UF = values[2].Text.Split('/')[1];
            CEP = values[3].Text;

            IsValid = !string.IsNullOrWhiteSpace(District);
        }

        public String Street { get; set; }
        public String District { get; set; }
        public String Locality { get; set; }
        public String UF { get; set; }
        public String CEP { get; set; }
        public Boolean IsValid { get; set; }
    }
}
