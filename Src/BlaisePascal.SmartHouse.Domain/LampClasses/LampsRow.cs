using System;
using System.Collections.Generic;
using System.Linq;
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
        public void SwitchOn(Guid guid){ LampRow[GetPositionOfLamp(guid)].SwitchOn();}
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
        public void SwitchOff(Guid guid) {LampRow[GetPositionOfLamp(guid)].SwitchOff();}
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
        public void AddLamp(AbstractLamp lamp) { LampRow.Add(lamp);}
        public void AddLampInPosition(AbstractLamp lamp, int position) {LampRow.Insert(position, lamp);}
        //Metodo privato per poter individuare una lamp in base al guid
        private int GetPositionOfLamp(Guid id)
        {
            int pos = 0;
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
        public void RemoveLamp(Guid Id) {LampRow.RemoveAt(GetPositionOfLamp(Id));}
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
        public void RemoveLampInPosition(int position) {LampRow.RemoveAt(position);}
        
        public void SetIntensityForAllLamps(int intensity)
        {
            for (int i = 0; i < LampRow.Count; i++)
                if (LampRow[i].LampStatus == DeviceStatus.On)
                    LampRow[i].SetIntensity(intensity);
        }
        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, Guid Id) 
        {
            if (LampRow[GetPositionOfLamp(Id)].LampStatus == DeviceStatus.On)
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
                    if (LampRow[i].LampStatus == DeviceStatus.On)
                        LampRow[i].SetIntensity(intensity);
                }
            }
        }
    }
}
