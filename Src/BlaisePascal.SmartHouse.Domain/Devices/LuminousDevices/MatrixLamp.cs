using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public class MatrixLamp: AbstractDevice, IToggable, INullable
    {
        private const int size = 10;

        //    -------ATTRIBUTES AND PROPERTY-------
        public Lamp[,] LampMatrix { get; private set; }

        //       ------CONSTRUCTORS------
        public MatrixLamp()
        {
            LampMatrix = new Lamp[size, size];
        }

        //        ------METHODS------

        //--CHECK METHODS--

        private static void AreIdxsInRange(uint row, uint col)
        {
            if (row >= size || col >= size)
                throw new ArgumentException($"Indexes[{row},{col}]: Spotted index out of matrix range");
        }

        //--ADD AND REMOVE METHODS--

        public void AddLampInPosition(uint row, uint col, Lamp lamp)
        {
            CheckIsNotNull(lamp);
            AreIdxsInRange(row, col);
            if (LampMatrix[row, col] == null)
                LampMatrix[row, col] = lamp;
            else
                throw new ArgumentException($"Indexes[{row},{col}]: Cannot add lamp in positions already taken");
        }
        public void RemoveLampInPosition(uint row, uint col)
        {
            AreIdxsInRange(row, col);
            LampMatrix[row, col] = null;
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
        public void Toggle()
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    LampMatrix[rows, cols].Toggle();
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
        public void SetIntensityInPosition(uint row, uint col, Intensity intensity)
        {
            AreIdxsInRange(row, col);
            LampMatrix[row, col].SetIntensityTo(intensity);
        }

        public void CheckIsNotNull(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
        }
    }
}
