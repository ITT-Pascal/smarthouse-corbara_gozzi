using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LampClasses
{
    public class LampsRow
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public List<AbstractLamp> LampRow { get; private set; }

        //------CONSTRUCTORS------
        public LampsRow()
        { 
            LampRow = new List<AbstractLamp>(); 
        }

        //------METHODS------
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
        public void SwitchOn(Guid guid)
        { 
            if (GetIdxOfLamp(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetIdxOfLamp(guid)].SwitchOn();
        }

        //Metodo privato per poter individuare una o più lamp in base al nome
        private List<AbstractLamp> GetLampsWithName(string name)
        {
            List<AbstractLamp> lamps = new List<AbstractLamp>();
            foreach(AbstractLamp lamp in LampRow) 
            { 
                if(lamp.Name == name)
                    lamps.Add(lamp);
            }
            return lamps;
        }
        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOn(string name)
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
        public void SwitchOff(Guid guid) 
        {
            if (GetIdxOfLamp(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetIdxOfLamp(guid)].SwitchOff();
        }

        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOff(string name)
        {
            foreach (AbstractLamp lamp in LampRow)
            {
                if (GetLampsWithName(name).Contains(lamp))
                    lamp.SwitchOff();
            }
        }

        public void AddLamp(AbstractLamp lamp) 
        { 
            LampRow.Add(lamp);
        }
        public void AddLampInPosition(AbstractLamp lamp, int position) 
        {
            LampRow.Insert(position, lamp);
        }

        //Metodo privato per poter individuare una lamp in base al guid
        private int GetIdxOfLamp(Guid id)
        {
            int pos = -1;
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].ID == id)
                    pos = i;
            }
            return pos;
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLamp(Guid Id) 
        {
            if (GetIdxOfLamp(Id) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow.RemoveAt(GetIdxOfLamp(Id));
        }

        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLamp(string name)
        {
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Name == name)
                    LampRow.RemoveAt(i);
            }
        }
        public void RemoveLampInPosition(int position) 
        {
            LampRow.RemoveAt(position);
        }
        
        public void SetIntensityForAllLamps(int intensity)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(lamp.DeviceStatus == DeviceStatus.On)
                {
                    lamp.SetIntensity(intensity);
                }
            }
        }

        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, Guid Id) 
        {
            if (GetIdxOfLamp(Id) == -1)
                throw new ArgumentException("Guid not found");
            else if (LampRow[GetIdxOfLamp(Id)].DeviceStatus == DeviceStatus.On)
                LampRow[GetIdxOfLamp(Id)].SetIntensity(intensity);
        }

        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, string name)
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if(lamp.Name == name && lamp.DeviceStatus == DeviceStatus.On)
                    lamp.SetIntensity(intensity);
            }
        }
        public AbstractLamp ?FindLampWithMaxIntensity() 
        {
            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity == lamp.MaxIntensity)
                    return lamp;
            }
            return null;
        }
        public AbstractLamp? FindLampWithMinIntensity()
        {
            foreach (AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity == lamp.MinIntensity)
                    return lamp;
            }
            return null;
        }
        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            foreach(AbstractLamp lamp in LampRow)
            {
                if (lamp.Intensity >= min && lamp.Intensity <= max)
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
        public AbstractLamp? FindLampById(Guid id)
        {
            if (GetIdxOfLamp(id) == -1)
            {
                return null;
            } else
            {
                return LampRow[GetIdxOfLamp(id)];
            }
        }
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
                    while (LampRow[i].Intensity < HelpList.LampRow[j].Intensity && j < HelpList.LampRow.Count)
                        j++;
                    HelpList.AddLampInPosition(LampRow[i], j);
                }
            }
            else 
            {
                for (int i = 1; i < LampRow.Count; i++)
                {
                    int j = 0;
                    while (LampRow[i].Intensity > HelpList.LampRow[j].Intensity && j < HelpList.LampRow.Count)
                        j++;
                    HelpList.AddLampInPosition(LampRow[i], j);
                }
            }    
            for (int i = 0; i < HelpList.LampRow.Count; i++)
                ListOfLamp.Add(HelpList.LampRow[i]);
            return ListOfLamp;
        }
    }
}