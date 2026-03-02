namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects
{
    public class Degrees
    {
        public const uint minDegrees = 0;
        public const uint maxDegrees = 360;
        public uint Angle { get; }

        public Degrees(uint angle)
        {
            if (angle > maxDegrees)
                throw new ArgumentOutOfRangeException(nameof(angle), $"Degrees: Invalid Degrees value[out of 0..360]");
            Angle = angle;
        }
        public static Degrees NewDegrees(uint angle)
        {
            return new Degrees(angle);
        }
        public static Degrees NewZeroDegrees()
        {
            return new Degrees(0);
        }
        public static Degrees NewHalfDegrees()
        {
            return new Degrees(180);
        }
        public static Degrees NewMaxDegrees()
        {
            return new Degrees(360);
        }

        //OVERRIDE DEGLI OPERATORI + E - PER AVER UINT SENZA PROBLEMI DI OVER O UNDERFLOW
        public static Degrees operator +(Degrees degree, uint jump)
        {
            if (degree.Angle + jump > maxDegrees)
                return NewDegrees(degree.Angle + jump - maxDegrees);
            return NewDegrees(degree.Angle + jump);
        }
        public static Degrees operator -(Degrees degree, uint jump)
        {
            if (degree.Angle - jump < minDegrees)
                return NewDegrees(maxDegrees + degree.Angle - jump);
            return NewDegrees(degree.Angle - jump);
        }
    }
}
