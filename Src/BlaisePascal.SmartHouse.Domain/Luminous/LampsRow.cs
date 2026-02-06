using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVClasses;
using BlaisePascal.SmartHouse.Domain.Luminous;
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
            LampRow = new List<AbstractLamp>(); 
        }

        //          ------METHODS------

        //--GETTER METHODS--

        //Metodo privato per poter individuare una o più lamp in base al nome
        private List<AbstractLamp> GetLampsWithName(DeviceName name)
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.Name == name)
                    lamps.Add(lamp);
            }
            return lamps;
        }

        //Metodo privato per poter individuare una lamp in base al guid
        private int GetIdxOfLampBy(Guid id)
        {
            List<Guid> GuidList = new List<Guid>();
            foreach (AbstractLamp lamp in LampRow)
                GuidList.Add(lamp.ID);
            return Array.IndexOf(GuidList.ToArray(), id);
        }

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
        public void SwitchOnBy(Guid guid)
        { 
            if (GetIdxOfLampBy(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetIdxOfLampBy(guid)].SwitchOn();
        }

        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(GetLampsWithName(name).Contains(lamp))
                    lamp.SwitchOn();
            }
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
        public void SwitchOffBy(Guid guid) 
        {
            if (GetIdxOfLampBy(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetIdxOfLampBy(guid)].SwitchOff();
        }

        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name)
        {
            foreach (AbstractLamp lamp in LampRow)
            {
                if (GetLampsWithName(name).Contains(lamp))
                    lamp.SwitchOff();
            }
        }

        //--ADDER/REMOVER METHODS--

        public void AddLamp(AbstractLamp lamp) 
        { 
            LampRow.Add(lamp);
        }
        public void AddLampIn(int position, AbstractLamp lamp) 
        {
            LampRow.Insert(position, lamp);
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(Guid Id) 
        {
            if (GetIdxOfLampBy(Id) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow.RemoveAt(GetIdxOfLampBy(Id));
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLampBy(DeviceName name)
        {
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Name == name)
                    LampRow.RemoveAt(i);
            }
        }
        public void RemoveLampAt(int position) 
        {
            LampRow.RemoveAt(position);
        }

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityForAllLampsTo(Intensity intensity)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(lamp.DeviceStatus == DeviceStatus.On)
                {
                    lamp.SetIntensityTo(intensity);
                }
            }
        }

        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampWith(Guid Id, Intensity intensity) 
        {
            if (GetIdxOfLampBy(Id) == -1)
                throw new ArgumentException("Guid not found");
            if (LampRow[GetIdxOfLampBy(Id)].DeviceStatus == DeviceStatus.On)
                LampRow[GetIdxOfLampBy(Id)].SetIntensityTo(intensity);
        }

        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLampWith(DeviceName name, Intensity intensity)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(lamp.Name == name && lamp.DeviceStatus == DeviceStatus.On)
                    lamp.SetIntensityTo(intensity);
            }
        }

        //--DETECTIONER METHODS--

        public AbstractLamp ?FindLampWithMaxIntensity() 
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value == lamp.Intensity.maxPercentage)
                    return lamp;
            }
            return null;
        }
        public AbstractLamp? FindLampWithMinIntensity()
        {
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value == lamp.Intensity.minPercentage)
                    return lamp;
            }
            return null;
        }
        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();
            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity.Value >= min && lamp.Intensity.Value <= max)
                    ListOfLamp.Add(lamp);
            }
            return ListOfLamp;
        }
        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            foreach( AbstractLamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.On)
                    ListOfLamp.Add(lamp);
            }
            return ListOfLamp;
        }
        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.DeviceStatus == DeviceStatus.Off)
                    ListOfLamp.Add(lamp);
            }
            return ListOfLamp;
        }
        public AbstractLamp? FindLampBy(Guid id)
        {
            if (GetIdxOfLampBy(id) == -1)
            {
                return null;
            } else
            {
                return LampRow[GetIdxOfLampBy(id)];
            }
        }

        //--SORTER METHODS--

        //IL PARAMETRO INDICA SE DEVE ESSERE IN ORDINE DECRESCENTE
        public List<AbstractLamp> SortByIntensity(bool descending)
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();
            LampsRow HelpList = new LampsRow();
            HelpList.LampRow.Add(LampRow[0]);
            if (descending)
            {
                for (int i = 1; i < LampRow.Count; i++)
                {
                    int j = 0;
                    while (LampRow[i].Intensity.Value < HelpList.LampRow[j].Intensity.Value && j < HelpList.LampRow.Count)
                        j++;
                    HelpList.AddLampIn(j, LampRow[i]);
                }
            }
            else 
            {
                for (int i = 1; i < LampRow.Count; i++)
                {
                    int j = 0;
                    while (LampRow[i].Intensity.Value > HelpList.LampRow[j].Intensity.Value && j < HelpList.LampRow.Count)
                        j++;
                    HelpList.AddLampIn(j, LampRow[i]);
                }
            }    
            for (int i = 0; i < HelpList.LampRow.Count; i++)
                ListOfLamp.Add(HelpList.LampRow[i]);
            return ListOfLamp;
        }
    }
}