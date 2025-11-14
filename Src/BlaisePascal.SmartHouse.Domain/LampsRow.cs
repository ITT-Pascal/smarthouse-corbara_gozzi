using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsRow
    {
        public List<Lamp> _lampsRow { get; set; }

        public LampsRow() 
        { 
            _lampsRow = new List<Lamp>();
        }
            
        public void AddLamp(Lamp lamp) 
        { 
            _lampsRow.Add(lamp);
        }
        //TODO: Add AddLampAtPosition

        public void RemoveLamp()
        {
            _lampsRow.RemoveAt(_lampsRow.Count()-1);                          
        }
        public void RemoveLampAtPosition(int position)
        {
            _lampsRow.RemoveAt(position);
        }

        public void SwitchOn()
        {
            for(int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].IsOn = true;
            }
        }
        public void SwitchOn(Guid guid)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Guid == guid)
                {
                    _lampsRow[i].IsOn = true;
                }
            }
        }
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
        public void SwitchOff(Guid guid)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Guid == guid)
                {
                    _lampsRow[i].IsOn = true;
                }
            }
        }
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
        public void SettingIntAllLamps(int brightness)
        {
            for (int i = 0; i > _lampsRow.Count(); i++)
            {
                _lampsRow[i].Brightness = brightness;
            }
        }
        public void SettingIntForLamp(int brightness, Guid guid)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Guid == guid)
                {
                    _lampsRow[i].Brightness = brightness;
                }
            }
        }
        public void SettingIntForLamp(int brightness, string name)
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                if (_lampsRow[i].Name == name)
                {
                    _lampsRow[i].Brightness = brightness;
                }
            }
        }


    }
}
