using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public class Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Inserire caratteri");
            if(value.Contains(' ') || value.Contains('.'))
                throw new ArgumentException("Impossibile nome con spazi o punti");
            Value = $"{value}";
        }

    }
}
