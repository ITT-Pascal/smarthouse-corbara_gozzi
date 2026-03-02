namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects
{
    public class Password
    {
        private const int passwordLenght = 8;
        public string Word { get; }

        public Password(string str)
        {
            //PASSWORD LUNGA ALMENO 8 CHAR E CHE CONTIENE ALMENO LETTERA MAIUSC e MINUSC e CHAR SPECIALE
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException("Password: There is no char", nameof(str));
            if (str.Contains(' '))
                throw new ArgumentException("Password: Password can't contain spaces[ ]", nameof(str));
            if (str.StartsWith('.'))
                throw new ArgumentException("Password: Password can't start with points[.]", nameof(str));
            if (!str.Any(char.IsUpper) || !str.Any(char.IsLower) || !str.Any(char.IsLetterOrDigit))
                throw new ArgumentException("Password: Password must have letters[minusc and maiusc] and at least one special char", nameof(str));
            if (str.Length <= passwordLenght)
                throw new ArgumentException("Password: Password must have a lenght at least of 8", nameof(str));
            Word = str;
        }
        public static Password NewPassword(string str)
        {
            return new Password(str);
        }

    }
}
