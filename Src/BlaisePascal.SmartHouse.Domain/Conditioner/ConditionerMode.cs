
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.AirConditioner
{
    public enum ModeTypes
    {
        COOL, FAN, HEAT, CUSTOM
    }
    public class ConditionerMode
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public Guid ID { get; set; }
        public DeviceStatus ConditionerStatus { get; set; }
        public string Name { get; set; }
        public int PowerIntensity { get; set; }
        public int Heat { get; set; }
        public ModeTypes Status { get; set; }

        //------CONSTRUCTORS------
        public ConditionerMode()
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = new Guid();
            Name = "Conditioner";
        }

        public ConditionerMode(string name, Guid guid)
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = guid;
            Name = name;
        }

        //------METHODS------
        public virtual void StartStatus()
        {
            Status = ModeTypes.FAN;
            Heat = 20;
            PowerIntensity = 5;
            ConditionerStatus = DeviceStatus.On;
        }

        public virtual void CustomMode()
        {
            Heat = 25;
        }
    }
}
