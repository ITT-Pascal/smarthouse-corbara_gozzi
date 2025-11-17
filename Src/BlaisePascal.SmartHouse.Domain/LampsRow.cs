using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsRow
    {
        public List<AbstractLamp> _lampsRow { get; set; }

        public LampsRow() 
        { 
            _lampsRow = new List<AbstractLamp>();
        }

        public void SwitchOn()
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].IsOn = true;
            }
        }
        /// <summary>
        /// Accende lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOn(Guid guid)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].ID == guid)
                {
                    _lampsRow[i].IsOn = true;
                }
            }
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
                    _lampsRow[i].IsOn = true;
                }
            }
        }
        public void SwitchOff()
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].IsOn = true;
            }
        }
        /// <summary>
        /// Spegne lampada in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOff(Guid guid)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].ID == guid)
                {
                    _lampsRow[i].IsOn = true;
                }
            }
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
                    _lampsRow[i].IsOn = true;
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
        /// <summary>
        /// Elimina lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void RemoveLamp(Guid Id)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].ID == Id)
                    _lampsRow.RemoveAt(i);
            }
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
                _lampsRow[i].Brightness = BrightnessGestor.ValidateNewBrightness(intensity, _lampsRow[i].MaxBrightness);
            }
        }
        /// <summary>
        /// Cambia inenistà lampada in base all'ID
        /// </summary>
        /// <param name="Id"></param>
        public void SetIntensityForLamp(int intensity, Guid Id)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].ID == Id)
                    _lampsRow[i].Brightness = BrightnessGestor.ValidateNewBrightness(intensity, _lampsRow[i].MaxBrightness);
            }
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
                    _lampsRow[i].Brightness = BrightnessGestor.ValidateNewBrightness(intensity, _lampsRow[i].MaxBrightness);
                }
            }
        }
    }
}
