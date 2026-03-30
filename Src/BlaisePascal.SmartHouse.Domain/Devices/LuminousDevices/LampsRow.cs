using System.Xml.Linq;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public sealed class LampsRow: AbstractDevice, ILamp, INullable
    {
        //     -------ATTRIBUTES AND PROPERTY-------
        public List<Lamp> LampRow { get; private set; }

        //        ------CONSTRUCTORS------
        public LampsRow()
        { 
            LampRow = []; 
        }

        //          ------METHODS------

        public void CheckIsNotNull(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
        }

        //--SWITCH METHODS--

        public void SwitchOn()
        {
            foreach(Lamp lamp in LampRow) 
            {
                lamp?.SwitchOn(); 
                //? = SE E' NULL, NON FA SWITCH ON
            }
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Accende lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id)
        {
            FindLampBy(id).SwitchOn();
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            LampRow.First(lamp => lamp.Name == name).SwitchOn();
            LastModifierAtUtc = DateTime.Now;
        }
        public void SwitchOff()
        {
            foreach (Lamp lamp in LampRow)
            {
                lamp?.SwitchOff();
            }
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Spegne lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id) 
        {
            FindLampBy(id).SwitchOff();
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name)
        {
            LampRow.First(lamp => lamp.Name == name).SwitchOff();
            LastModifierAtUtc = DateTime.Now;
        }

        public override void Toggle()
        {
            foreach (Lamp lamp in LampRow)
                lamp.Toggle();
            LastModifierAtUtc = DateTime.Now;
        }

        //--ADDER/REMOVER METHODS--

        public void AddLamp(Lamp lamp) 
        {
            CheckIsNotNull(lamp);
            LampRow.Add(lamp);
            LastModifierAtUtc = DateTime.Now;
        }
        public void AddLampIn(int position, Lamp lamp) 
        {
            CheckIsNotNull(lamp);
            if (position < 0 || position >= LampRow.Count)
                throw new ArgumentOutOfRangeException(nameof(position), "Position: Position out of range");
            if (LampRow[position] != null)
                throw new ArgumentException("Position: There is already a lamp", nameof(position));
            LampRow.Insert(position, lamp);
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(Guid id) 
        {
            LampRow.RemoveAt(GetIdxOfLampBy(id));
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(DeviceName name)
        {
            RemoveLampBy(LampRow.First(lamp => lamp.Name == name).ID);
            LastModifierAtUtc = DateTime.Now;
        }
        public void RemoveLampAt(int position)
        {
            if (position < 0 || position >= LampRow.Count)
                throw new ArgumentOutOfRangeException(nameof(position), "Position: Position out of range");
            LampRow.RemoveAt(position);
            LastModifierAtUtc = DateTime.Now;
        }

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityTo(Intensity intensity)
        {
            foreach(Lamp lamp in LampRow)
                lamp?.SetIntensityTo(intensity);
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampBy(Guid id, Intensity intensity) 
        {
            FindLampBy(id).SetIntensityTo(intensity);
            LastModifierAtUtc = DateTime.Now;
        }

        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampBy(DeviceName name, Intensity intensity)
        {
            LampRow.First(lamp => lamp.Name == name).SetIntensityTo(intensity);
            LastModifierAtUtc = DateTime.Now;
        }
        public void IncreaseBy()
        {
            foreach (Lamp lamp in LampRow)
                lamp?.IncreaseBy();
            LastModifierAtUtc = DateTime.Now;
        }
        public void DecreaseBy()
        {
            foreach (Lamp lamp in LampRow)
                lamp?.DecreaseBy();
            LastModifierAtUtc = DateTime.Now;
        }

        //--DETECTIONER METHODS--

        public List<Lamp>? FindLampWithMaxIntensity() 
        {
            List<Lamp> lamps = [];
            foreach(Lamp lamp in LampRow)
            {
                if (lamp.Intensity.Percentage == Intensity.maxPercentage)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<Lamp>? FindLampWithMinIntensity()
        {
            List<Lamp> lamps = [];
            foreach (Lamp lamp in LampRow)
            {
                if (lamp.Intensity.Percentage == Intensity.minPercentage)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<Lamp>? FindLampsByIntensityRange(int min, int max)
        {
            List<Lamp> lamps = [];
            foreach(Lamp lamp in LampRow)
            {
                if (lamp.Intensity.Percentage >= min && lamp.Intensity.Percentage <= max)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<Lamp>? FindAllOn()
        {
            List<Lamp> lamps = [];
            foreach (Lamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.On)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<Lamp>? FindAllOff()
        {
            List<Lamp> lamps = [];
            foreach (Lamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.Off)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public Lamp FindLampBy(Guid id)
        {
            return LampRow[GetIdxOfLampBy(id)];
        }
        //Metodo privato per poter individuare l'index di una lamp in base al guid
        private int GetIdxOfLampBy(Guid id)
        {
            int pos = LampRow.FindIndex(lamp => lamp.ID == id);
            if (pos == -1)
                throw new ArgumentException("ID: Id not identified", nameof(id));
            return pos;
        }

        //--SORTER METHODS--

        //IL PARAMETRO INDICA SE DEVE ESSERE IN ORDINE CRESCENTE O DECRESCENTE
        public List<Lamp> SortByIntensity(bool ascending)
        {
            if (ascending)
                return [.. LampRow.OrderBy(lamp => lamp.Intensity.Percentage)];
            else
                return [.. LampRow.OrderByDescending(lamp => lamp.Intensity.Percentage)]; // [.. <expression>] == <expression>.ToList()
        }

    }
}