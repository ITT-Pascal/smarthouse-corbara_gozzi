using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.Luminous_Devices;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.Luminous
{
    public class MatrixLed: AbstractDevice, IToggable
    {
        private const int size = 10;

        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp[,] LampMatrix { get; private set; }

        //       ------CONSTRUCTORS------
        public MatrixLed()
        {
            LampMatrix = new Lamp[size, size];
        }

        //        ------METHODS------

        //--ADD AND REMOVE METHODS--

        public void AddLampInPosition(uint rows, uint cols, Lamp lamp)
        {
            if (rows >= LampMatrix.GetLength(0) || cols >= LampMatrix.GetLength(1))
                throw new ArgumentOutOfRangeException("Index out of matrix");
            if (LampMatrix[rows, cols] == null)
                LampMatrix[rows, cols] = lamp;
            else
                throw new ArgumentException("There is already a lamp");
        }
        public void RemoveLampInPosition(uint rows, uint cols)
        {
            if (rows >= LampMatrix.GetLength(0) || cols >= LampMatrix.GetLength(1))
                throw new ArgumentOutOfRangeException("Index out of matrix");
            if (LampMatrix[rows, cols] == null)
                throw new ArgumentException("There is nothing");
            else
                LampMatrix[rows, cols] = null;
        }

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
        //ACCENDE UNA SI E UNA NO, TIPO SCACCHIERA
        public void SwitchOnLikeChessboard()
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if ((rows + cols) % 2 == 0)
                        LampMatrix[rows, cols].SwitchOn();
                    else
                        LampMatrix[rows, cols].SwitchOff();
                }
            }
        }
        public sealed override void Toggle()
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    LampMatrix[rows, cols].Toggle();
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
        public void SetIntensityInPosition(uint rowsIdx, uint colsIdx, Intensity intensity)
        {
            if (rowsIdx >= LampMatrix.GetLength(0) || colsIdx >= LampMatrix.GetLength(1))
                throw new ArgumentOutOfRangeException("Index out of matrix");
            LampMatrix[rowsIdx, colsIdx].SetIntensityTo(intensity);
        }
    }
}
