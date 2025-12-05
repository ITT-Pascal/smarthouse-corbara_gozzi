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
        public List<AbstractLamp> LampRow { get; set; }

        //------CONSTRUCTORS------
        public LampsRow(){ LampRow = new List<AbstractLamp>(); }

        //------METHODS------
        public void SwitchOn()
        {
            for (int i = 0; i < LampRow.Count; i++)
                LampRow[i].SwitchOn();
        }
        /// <summary>
        /// Accende lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOn(Guid guid)
        { 
            if (GetPositionOfLamp(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetPositionOfLamp(guid)].SwitchOn();
        }
        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOn(string name)
        {
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Name == name)
                    LampRow[i].SwitchOn();
            }
        }
        public void SwitchOff()
        {
            for (int i = 0; i < LampRow.Count; i++)
                LampRow[i].SwitchOff();
        }
        /// <summary>
        /// Spegne lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOff(Guid guid) 
        {
            if (GetPositionOfLamp(guid) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow[GetPositionOfLamp(guid)].SwitchOff();
        }
        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOff(string name)
        {
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Name == name)
                    LampRow[i].SwitchOff();
            }
        }
        public void AddLamp(AbstractLamp lamp) 
        { 
            LampRow.Add(lamp);
        }
        public void AddLampInPosition(AbstractLamp lamp, int position) {LampRow.Insert(position, lamp);}
        //Metodo privato per poter individuare una lamp in base al guid
        private int GetPositionOfLamp(Guid id)
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
            if (GetPositionOfLamp(Id) == -1)
                throw new ArgumentException("Guid not found");
            else
                LampRow.RemoveAt(GetPositionOfLamp(Id));
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
            for (int i = 0; i < LampRow.Count; i++)
                if (LampRow[i].DeviceStatus == DeviceStatus.On)
                    LampRow[i].SetIntensity(intensity);
        }
        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, Guid Id) 
        {
            if (GetPositionOfLamp(Id) == -1)
                throw new ArgumentException("Guid not found");
            else if (LampRow[GetPositionOfLamp(Id)].DeviceStatus == DeviceStatus.On)
                LampRow[GetPositionOfLamp(Id)].SetIntensity(intensity);
        }
        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, string name)
        {
            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Name == name)
                {
                    if (LampRow[i].DeviceStatus == DeviceStatus.On)
                        LampRow[i].SetIntensity(intensity);
                }
            }
        }
        public AbstractLamp ?FindLampWithMaxIntensity() 
        {
            int i = 0;
            bool isLampFound = false;
            while (!isLampFound && i < LampRow.Count) 
            {
                if (LampRow[i].DeviceStatus == DeviceStatus.On)
                {
                    if (LampRow[i] is Lamp)
                        isLampFound = LampRow[i].Intensity == 100;
                    else if (LampRow[i] is EcoLamp)
                        isLampFound = LampRow[i].Intensity == 70;
                    i++;
                }
            }
            if (isLampFound)
                return LampRow[i];
            else
                return null;
        }
        public AbstractLamp? FindLampWithMinIntensity()
        {
            int i = 0;
            bool isLampFound = false;
            while (!isLampFound && i < LampRow.Count)
            {
                if (LampRow[i].DeviceStatus == DeviceStatus.On)
                {
                    isLampFound = LampRow[i].Intensity == 1;
                }
            }
            if (isLampFound)
                return LampRow[i];
            else
                return null;
        }
        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].Intensity >= min && LampRow[i].Intensity <= max)
                    ListOfLamp.Add(LampRow[i]);
            }
            return ListOfLamp;
        }
        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].DeviceStatus == DeviceStatus.On)
                    ListOfLamp.Add(LampRow[i]);
            }
            return ListOfLamp;
        }
        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> ListOfLamp = new List<AbstractLamp>();

            for (int i = 0; i < LampRow.Count; i++)
            {
                if (LampRow[i].DeviceStatus == DeviceStatus.Off)
                    ListOfLamp.Add(LampRow[i]);
            }
            return ListOfLamp;
        }
        public AbstractLamp? FindLampById(Guid id)
        {
            if (GetPositionOfLamp(id) == -1)
            {
                return null;
            } else
            {
                return LampRow[GetPositionOfLamp(id)];
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