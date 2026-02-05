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
            //PASSWORD LUNGA ALMENO 8 CHAR E CHE CONTIENE ALMENO LETTERA MAIUSC e MINUSC e CHAR SPECIALE
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Inserire caratteri");
            if (value.Contains(' '))
                throw new ArgumentException("Impossibile password con spazi");
            if (value.StartsWith('.'))
                throw new ArgumentException("Impossibile password con punti iniziali");
            if (!value.Any(char.IsUpper) || !value.Any(char.IsLower) || !value.Any(char.IsLetterOrDigit))
                throw new ArgumentException("La password deve contenere almeno una lettera minuscola, una maiuscola e carattere speciale ");
            if (value.Length <= 8)
                throw new ArgumentException("Inserire password con almeno 8 caratteri");
            Value = $"{value}";
        }

    }
}
