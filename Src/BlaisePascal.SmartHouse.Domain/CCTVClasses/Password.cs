using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Inserire caratteri");
            if (value.Contains(' ') || value.Contains('.'))
                throw new ArgumentException("Impossibile password con spazi o punti");
            if (value.ToString().Length < 10)
                throw new ArgumentException("Inserire password con almeno 10 caratteri");
            Value = $"{value}";
        }

    }
}
