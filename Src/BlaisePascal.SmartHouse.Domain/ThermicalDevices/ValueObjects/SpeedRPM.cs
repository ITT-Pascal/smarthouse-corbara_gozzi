using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ThermicalDevices.ValueObjects
{
    public class SpeedRPM
    {
        private const int minSpeed = 450;
        private const int maxSpeed = 1200;
        public int Value { get; } //COME UNITA' DI MISURA ABBIAMO GIRI AL MINUTO(RPM)

        public SpeedRPM(int speed)
        {
            if(speed != 0)
            {
                if (!(Math.Abs(speed) is >= minSpeed and <= maxSpeed))
                    throw new ArgumentException($"AcSpeed[{speed}]: Speed out of operating range[out of 450..1200 / -1200..-450]");
            }
            Value = speed;
        }
        public static SpeedRPM NewSpeed(int val)
        {
            return new SpeedRPM(val);
        }

    }
}
