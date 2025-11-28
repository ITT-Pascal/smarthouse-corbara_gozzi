using BlaisePascal.SmartHouse.Domain.Conditioner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Door
{
    public class Door
    {
        public Guid ID { get; set; }
        public DMode DoorStatus { get; set; }
        public string Name { get; set; }
        public int Heat { get; set; }

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
