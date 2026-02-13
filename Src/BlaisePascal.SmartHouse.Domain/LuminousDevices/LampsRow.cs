using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVClasses;
using BlaisePascal.SmartHouse.Domain.Luminous;
using BlaisePascal.SmartHouse.Domain.Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public class LampsRow
    {
        //     -------ATTRIBUTES AND PROPERTY-------
        public List<AbstractLamp> LampRow { get; private set; }

        //        ------CONSTRUCTORS------
        public LampsRow()
        { 
            LampRow = []; 
        }

        //          ------METHODS------

        //--SWITCH METHODS--

        public void SwitchOn()
        {
            foreach(AbstractLamp lamp in LampRow) 
            { 
                lamp.SwitchOn(); 
            }
        }

        /// <summary>
        /// Accende lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id)
        {
            FindLampBy(id).SwitchOn();
        }

        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            foreach (AbstractLamp lamp in LampRow)
                if (lamp.Name == name)
                    SwitchOnBy(lamp.ID);
        }
        public void SwitchOff()
        {
            foreach (AbstractLamp lamp in LampRow)
            {
                lamp.SwitchOff();
            }
        }

        /// <summary>
        /// Spegne lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id) 
        {
            FindLampBy(id).SwitchOff();
        }

        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name)
        {
            foreach (AbstractLamp lamp in LampRow)
                if (lamp.Name == name)
                    SwitchOffBy(lamp.ID);
        }

        //--ADDER/REMOVER METHODS--

        public void AddLamp(AbstractLamp lamp) 
        { 
            LampRow.Add(lamp);
        }
        public void AddLampIn(int position, AbstractLamp lamp) 
        {
            if (position < 0 || position >= LampRow.Count)
                throw new ArgumentException($"Position[{position}]: Position out of range");
            if (LampRow[position] != null)
                throw new Exception($"Position[{position}]: Position out of range");
            LampRow.Insert(position, lamp);
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(Guid id) 
        {
            LampRow.RemoveAt(GetIdxOfLampBy(id));
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(DeviceName name)
        {
            foreach (AbstractLamp lamp in LampRow)
                if (lamp.Name == name)
                    RemoveLampBy(lamp.ID);
        }
        public void RemoveLampAt(int position)
        {
            if (position < 0 || position >= LampRow.Count)
                throw new ArgumentException($"Position[{position}]: Position out of range");
            LampRow.RemoveAt(position);
        }

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityForAllLampsTo(Intensity intensity)
        {
            foreach(AbstractLamp lamp in LampRow)
                lamp.SetIntensityTo(intensity);
        }

        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampBy(Guid id, Intensity intensity) 
        {
            FindLampBy(id).SetIntensityTo(intensity);
        }

        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampBy(DeviceName name, Intensity intensity)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(lamp.Name == name)
                    lamp.SetIntensityTo(intensity);
            }
        }

        //--DETECTIONER METHODS--

        public List<AbstractLamp>? FindLampWithMaxIntensity() 
        {
            List<AbstractLamp> lamps = [];
            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value == Intensity.maxPercentage)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<AbstractLamp>? FindLampWithMinIntensity()
        {
            List<AbstractLamp> lamps = [];
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value == Intensity.minPercentage)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<AbstractLamp>? FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lamps = [];
            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value >= min && lamp.Intensity.Value <= max)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<AbstractLamp>? FindAllOn()
        {
            List<AbstractLamp> lamps = [];
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.On)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public List<AbstractLamp>? FindAllOff()
        {
            List<AbstractLamp> lamps = [];
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.Off)
                    lamps.Add(lamp);
            }
            if (lamps.Count == 0)
                return null;
            return lamps;
        }
        public AbstractLamp FindLampBy(Guid id)
        {
            return LampRow[GetIdxOfLampBy(id)];
        }
        //Metodo privato per poter individuare l'index di una lamp in base al guid
        private int GetIdxOfLampBy(Guid id)
        {
            List<Guid> GuidList = [];
            foreach (AbstractLamp lamp in LampRow)
                GuidList.Add(lamp.ID);
            if (Array.IndexOf([.. GuidList], id) == -1)
                throw new ArgumentException($"ID[{id}]: Id not identified");
            return Array.IndexOf([.. GuidList], id);
        }

        //--SORTER METHODS--

        //IL PARAMETRO INDICA SE DEVE ESSERE IN ORDINE CRESCENTE O DECRESCENTE
        public List<AbstractLamp> SortByIntensity(bool ascending)
        {
            if (ascending)
                return [.. LampRow.OrderBy(lamp => lamp.Intensity.Value)];
            else
                return [.. LampRow.OrderByDescending(lamp => lamp.Intensity.Value)]; // [.. <expression>] == <expression>.ToList()
        }
    }
}