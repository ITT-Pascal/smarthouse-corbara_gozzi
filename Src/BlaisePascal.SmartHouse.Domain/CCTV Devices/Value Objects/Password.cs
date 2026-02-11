using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class Password
    {
        private const int passwordLenght = 8;
        public string Value { get; }

        public Password(string value)
        {
            //PASSWORD LUNGA ALMENO 8 CHAR E CHE CONTIENE ALMENO LETTERA MAIUSC e MINUSC e CHAR SPECIALE
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Password: There is no char");
            if (value.Contains(' '))
                throw new ArgumentException("Password: Password can't contain spaces[ ]");
            if (value.StartsWith('.'))
                throw new ArgumentException("Password: Password can't start with points[.]");
            if (!value.Any(char.IsUpper) || !value.Any(char.IsLower) || !value.Any(char.IsLetterOrDigit))
                throw new ArgumentException("Password: Password must have letters[minusc and maiusc] and at least one special char");
            if (value.Length <= passwordLenght)
                throw new ArgumentException("Password: Password must have a lenght at least of 8");
            Value = value;
        }
        public static Password NewPassword(string val)
        {
            return new Password(val);
        }

    }
}
