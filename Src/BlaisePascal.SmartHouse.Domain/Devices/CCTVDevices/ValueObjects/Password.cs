namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects
{
    public class Password
    {
        private const int passwordLenght = 8;
        public string String { get; }

        public Password(string str)
        {
            //PASSWORD LUNGA ALMENO 8 CHAR E CHE CONTIENE ALMENO LETTERA MAIUSC e MINUSC e CHAR SPECIALE
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentException($"Password[{str}]: There is no char");
            if (str.Contains(' '))
                throw new ArgumentException($"Password[{str}]: Password can't contain spaces[ ]");
            if (str.StartsWith('.'))
                throw new ArgumentException($"Password[{str}]: Password can't start with points[.]");
            if (!str.Any(char.IsUpper) || !str.Any(char.IsLower) || !str.Any(char.IsLetterOrDigit))
                throw new ArgumentException($"Password[{str}]: Password must have letters[minusc and maiusc] and at least one special char");
            if (str.Length <= passwordLenght)
                throw new ArgumentException($"Password[{str}]: Password must have a lenght at least of 8");
            String = str;
        }
        public static Password NewPassword(string str)
        {
            return new Password(str);
        }

    }
}
