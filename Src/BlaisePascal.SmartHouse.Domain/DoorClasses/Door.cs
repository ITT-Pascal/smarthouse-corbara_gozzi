using BlaisePascal.SmartHouse.Domain.ConditionerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using System.Runtime.InteropServices;

namespace BlaisePascal.SmartHouse.Domain.DoorClasses
{
    public class Door: AbstractDevice
    {
        public DMode DoorStatus { get; set; }
        public int Code { get; set; }        

        public Door(int code)
        {
            DoorStatus = DMode.CLOSEDANDLOCKED;
            ID = new Guid();
            Name = "Conditioner";
            Code = code;
        }

        public Door(string name,int code)
        {
            DoorStatus = DMode.CLOSEDANDLOCKED;
            Code = code;
            Name = name;
        }

        public Door(string name, Guid guid , int code)
        {
            DoorStatus = DMode.CLOSEDANDLOCKED;
            ID = guid;
            Name = name;
            Code = code;
        }

        public void OpenDoor()
        {
            if(DoorStatus == DMode.CLOSEDANDUNLOCKED)
            {
                DoorStatus = DMode.OPEN;
            } else if(DoorStatus == DMode.CLOSEDANDLOCKED) {
                throw new ArgumentException("For Open the locked door you need to insert the code");
            } else
            {
                DoorStatus = DMode.OPEN;
            }

        }

        public void OpenDoor(int codeValidator)
        {
            if (DoorStatus == DMode.CLOSEDANDUNLOCKED)
            {
                DoorStatus = DMode.OPEN;
            }
            else if (DoorStatus == DMode.CLOSEDANDLOCKED)
            {
                if(codeValidator == Code)
                {
                    DoorStatus = DMode.OPEN;
                }
                else
                {
                    throw new ArgumentException("The Code Is Wrong");
                }
            }
            else
            {
                DoorStatus = DMode.OPEN;
            }
        }

        public void CloseDoor()
        {
            if(DoorStatus == DMode.OPEN)
            {
                DoorStatus = DMode.CLOSEDANDUNLOCKED;
            }
            else
            {
                throw new ArgumentException("If You want to close the door it has to be opened , remember to insert right code");
            }
        }

        public void LockDoor(int codeValidator)
        {
            if (DoorStatus == DMode.CLOSEDANDUNLOCKED && codeValidator == Code)
            {
                DoorStatus = DMode.CLOSEDANDLOCKED;
            } else
            {
                throw new ArgumentException("If You want to lock the door it has to be closed , remember to insert right code");
            }
        }

        public void UnlockLockDoor(int codeValidator)
        {
            if (DoorStatus == DMode.CLOSEDANDLOCKED && codeValidator == Code)
            {
                DoorStatus = DMode.CLOSEDANDUNLOCKED;
            }
            else
            {
                throw new ArgumentException("If You want to unlock the door it has to be locked , remember to insert right code");
            }
        }
              
        

       
    }
}
