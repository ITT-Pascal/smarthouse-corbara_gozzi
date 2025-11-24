using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LAMP
{
    public class LampsRow
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public List<AbstractLamp> _lampsRow { get; set; }

        //------CONSTRUCTORS------
        public LampsRow() 
        { 
            _lampsRow = new List<AbstractLamp>();
        }

        //------METHODS------
        public void SwitchOn()
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].lampStatus = DeviceStatus.On;
            }
        }
        /// <summary>
        /// Accende lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOn(Guid guid)
        {
            _lampsRow[GetPositionOfLamp(guid)].SwitchOn();
        }
        /// <summary>
        /// Accende lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOn(string name)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Name == name)
                {
                    _lampsRow[i].SwitchOn();
                }
            }
        }
        public void SwitchOff()
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].SwitchOff();
            }
        }
        /// <summary>
        /// Spegne lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOff(Guid guid)
        {
            _lampsRow[GetPositionOfLamp(guid)].SwitchOff();
        }
        /// <summary>
        /// Spegne lampada in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOff(string name)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Name == name)
                {
                    _lampsRow[i].SwitchOff();
                }
            }
        }
        public void AddLamp(AbstractLamp lamp) 
        { 
            _lampsRow.Add(lamp);
        }
        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            _lampsRow.Insert(position, lamp);
        }
        //Metodo privato per poter individuare una lamp in base al guid
        private int GetPositionOfLamp(Guid id)
        {
            int pos = 0;
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].ID == id)
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
            _lampsRow.RemoveAt(GetPositionOfLamp(Id));
        }
        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLamp(string name)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Name == name)
                    _lampsRow.RemoveAt(i);
            }
        }
        public void RemoveLampInPosition(int position)
        {
            _lampsRow.RemoveAt(position);
        }
        
        public void SetIntensityForAllLamps(int intensity)
        {
            for (int i = 0; i > _lampsRow.Count(); i++)
            {
                _lampsRow[i].SetIntensity(intensity);
            }
        }
        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, Guid Id)
        {
            _lampsRow[GetPositionOfLamp(Id)].SetIntensity(intensity);
        }
        /// <summary>
        /// Cambia inenistà lampada in base al nome
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, string name)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Name == name)
                {
                    _lampsRow[i].SetIntensity(intensity);
                }
            }
        }
    }
}
