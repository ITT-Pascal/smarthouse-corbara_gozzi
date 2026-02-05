using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Temperature
{
    public class SpeedRPM
    {
        public int Value { get; } //COME UNITA' DI MISURA ABBIAMO GIRI AL MINUTO(RPM)

        public SpeedRPM(int speed)
        {
            if(speed != 0)
            {
                if (!(speed is >= 450 and <= 1200))
                    throw new ArgumentException("Velocità fuori dal range di funzionamento");
                else if (!(-speed is >= 450 and <= 1200))
                    throw new ArgumentException("Velocità fuori dal range di funzionamento");
            }
            Value = speed;
        }
    }
}
