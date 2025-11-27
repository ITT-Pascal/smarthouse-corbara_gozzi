using BlaisePascal.SmartHouse.Domain.AirConditioner;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain
{
    public enum ModeTypes
    {
        COOL, FAN, HEAT, CUSTOM, OFF
    }
    public class AirConditioners : ConditionerMode
    {
        private const int minPower = 10;
        private const int maxPower = 10;
        private const int minHeat = 5;
        private const int maxHeat = 45;

        //------CONSTRUCTORS------
        public AirConditioners()
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = new Guid();
            Name = "Conditioner";
        }

        public AirConditioners(string name, Guid guid) : base(name, guid)
        {
            ConditionerStatus = DeviceStatus.Off;
            ID = guid;
            Name = name;
        }

        //------METHODS------
        public void SwitchOn()
        {
            this.StartStatus();
        }

        public void SwitchOn(string name)
        {
            this.StartStatus();
        }

        public void SwitchOn(Guid guid)
        {
            this.StartStatus();
        }

        public void SwitchOff()
        {
            ConditionerStatus = DeviceStatus.Off;
            Heat = 0;
            PowerIntensity = 0;
        }

        public void ChangePower(int amount)
        {
            if (ConditionerStatus == DeviceStatus.On)
                PowerIntensity = Math.Min(maxPower, amount);
            PowerIntensity = Math.Max(minPower, amount);
        }

        public void ChangeMode(ModeTypes mode)
        {
            if (ConditionerStatus == DeviceStatus.On)
            {
                if (mode == ModeTypes.FAN)
                {
                    Heat = 20;
                }
                else if (mode == ModeTypes.COOL)
                {
                    Heat = 10;
                }
                else if (mode == ModeTypes.HEAT)
                {
                    Heat = 30;
                }
                else if (mode == ModeTypes.CUSTOM)
                {
                    this.CustomMode();
                }
            }
        }

        public virtual void ChangeHeatCustomMode(int heat)
        {
            Heat = Math.Min(maxHeat, heat);
            Heat = Math.Max(minHeat, heat);
        }

        public DeviceStatus State()
        {
            return ConditionerStatus;
        }

        public ModeTypes ModeState()
        {
            return (ModeTypes)Status;
        }
    }




}

