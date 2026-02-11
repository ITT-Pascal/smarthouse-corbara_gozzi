using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Thermic
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
                    throw new ArgumentException("Velocità fuori dal range di funzionamento");
            }
            Value = speed;
        }
        public static SpeedRPM NewSpeed(int val)
        {
            return new SpeedRPM(val);
        }

    }
}
