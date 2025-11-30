using BlaisePascal.SmartHouse.Domain.ConditionerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;

namespace BlaisePascal.SmartHouse.Domain.Door
{
    public class Door: AbstractDevice
    {
        public DMode DoorStatus { get; set; }

        public Door()
        {
            DoorStatus = DMode.CLOSEDANDLOCKED;
            ID = new Guid();
            Name = "Conditioner";
        }

        public Door(string name, Guid guid)
        {
            DoorStatus = DMode.CLOSEDANDLOCKED;
            ID = guid;
            Name = name;
        }

        public void OpenDoor()
        {
        
        }
    }
}
