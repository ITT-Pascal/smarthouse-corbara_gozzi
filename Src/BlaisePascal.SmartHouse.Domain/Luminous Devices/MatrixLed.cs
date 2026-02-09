using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class MatrixLed: AbstractDevice, IToggable
    {
        private int size = 10;

        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp[,] LampMatrix { get; private set; }

        //       ------CONSTRUCTORS------
        public MatrixLed()
        {
            LampMatrix = new Lamp[size, size];
        }

        //        ------METHODS------

        //--ON/OFF METHODS--

        public sealed override void SwitchOn()
        {
            base.SwitchOn();
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    LampMatrix[rows, cols].SwitchOn();
                }
            }
        }
        public sealed override void SwitchOff()
        {
            base.SwitchOff();
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    LampMatrix[rows, cols].SwitchOff();
                }
            }
        }

        //--CHANGER INTENSITY METHODS--

        /// <summary>
        /// Cambia la luminosità a tutte le lampade
        /// </summary>
        /// <param name="intensity"></param>
        public void SetIntensityTo(Intensity intensity)
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    LampMatrix[rows, cols].SetIntensityTo(intensity);
                }
            }
        }
    }
}
