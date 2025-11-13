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
            
        public void AddLamp(AbstractLamp lamp) 
        { 
            _lampsRow.Add(lamp);
        }

        public void RemoveLamp(int position)
        {
            _lampsRow.RemoveAt(position - 1);                          
        }

        public void TurnOnAllLamps()
        {
            for(int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].IsOn = true;
            }
        }

        public void TurnOffAllLamps()
        {
            for (int i = 0; i < _lampsRow.Count; i++)
            {
                _lampsRow[i].IsOn = true;
            }
        }

    }
}
