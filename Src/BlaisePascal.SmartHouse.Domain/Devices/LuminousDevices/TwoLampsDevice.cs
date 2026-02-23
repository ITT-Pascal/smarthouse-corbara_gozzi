using BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminousDevices
{
    public sealed class TwoLampsDevice(AbstractLamp firstLamp, AbstractLamp secondLamp)
    {
        //   -------ATTRIBUTES AND PROPERTY-------
        public AbstractLamp FirstLamp { get; private set; } = firstLamp;
        public AbstractLamp SecondLamp { get; private set; } = secondLamp;

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
        public void SwitchOnAllLamps()
        {
            FirstLamp.SwitchOn();
            SecondLamp.SwitchOn();
        }
        public void SwitchOffAllLamps()
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

        //--CHANGER INTENSITY METHODS--

        public void SetIntensityOfLampsTo(Intensity intensity)
        {
            FirstLamp.SetIntensityTo(intensity);
            SecondLamp.SetIntensityTo(intensity);
        }
    }
}
