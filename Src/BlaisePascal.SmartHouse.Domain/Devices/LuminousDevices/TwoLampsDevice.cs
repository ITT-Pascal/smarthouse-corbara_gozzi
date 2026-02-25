using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public sealed class TwoLampsDevice(Lamp firstLamp, Lamp secondLamp): ILamp
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public Lamp FirstLamp { get; private set; } = firstLamp;
        public Lamp SecondLamp { get; private set; } = secondLamp;

        //       ------METHODS------

        //--SWITCH METHODS--

        public void SwitchOnFirstLamp() 
        {
            FirstLamp.SwitchOn();
        }
        public void SwitchOnSecondLamp() 
        {
            SecondLamp.SwitchOn(); 
        }
        public void SwitchOn()
        {
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();
        }
        public void SwitchOff()
        {
            FirstLamp.SwitchOff();
            SecondLamp.SwitchOff();
        }
        public void SwitchOffFirstLamp() 
        { 
            FirstLamp.SwitchOff(); 
        }
        public void SwitchOffSecondLamp()
        { 
            SecondLamp.SwitchOff(); 
        }
        public void Toggle()
        {
            FirstLamp.Toggle();
            SecondLamp.Toggle();
        }

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityTo(Intensity intensity)
        {
            FirstLamp.SetIntensityTo(intensity);
            SecondLamp.SetIntensityTo(intensity);
        }
        public void IncreaseBy()
        {
            FirstLamp.IncreaseBy();
            SecondLamp.IncreaseBy();
        }
        public void DecreaseBy()
        {
            FirstLamp.DecreaseBy();
            SecondLamp.DecreaseBy();
        }
    }
}
