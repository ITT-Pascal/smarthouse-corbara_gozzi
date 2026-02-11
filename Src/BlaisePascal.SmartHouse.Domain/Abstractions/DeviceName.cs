using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain.Abstractions
{
    public class DeviceName
    {
        public string Value { get; }

        public DeviceName(string value)
        {
            //CONTROLLO CHE IL NOME NON SIA VUOTO E CHE NON ABBIA PUNTI O SPAZI
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("DeviceName: There is no char");
            if(value.Contains(' ') || value.Contains('.'))
                throw new ArgumentException("DeviceName: Name can't contain spaces[ ] or points[.]");
            Value = value;
        }
        public static DeviceName NewDeviceName(string value)
        {
            return new DeviceName(value);
        }

    }
}
