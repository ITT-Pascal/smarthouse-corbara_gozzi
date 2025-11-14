namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; set; }
        public int Brightness { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int MinValueOfBrightness { get; set; }
        public int MaxValueOfBrightness { get; set; }
        public int BrightnessValueAtTurnOn { get; set; }
        public Lamp(string name)
        {
            IsOn = false;
            Brightness = 0;
            Guid = new Guid();
            Name = name;
            MinValueOfBrightness = 1;
            MaxValueOfBrightness = 100;
            BrightnessValueAtTurnOn = 50;
        }
        public Lamp(Guid guid, string name)
        {
            IsOn = false;
            Brightness = 0;
            Guid = guid;
            Name = name;
            MinValueOfBrightness = 1;
            MaxValueOfBrightness = 100;
            BrightnessValueAtTurnOn = 50;
        }



        public virtual void TurnOn()
        {
            IsOn = true;
            Brightness = BrightnessValueAtTurnOn;
        }

        public virtual void TurnOff()
        {  
            IsOn = false;
            Brightness = 0;
        }

        public virtual void ChangeBrightness(Lamp lamp, int brightnessValue)
        {
            if (IsOn)
            {
                Brightness = BrightnessValidator.ValidateBrightness(brightnessValue, lamp);
            }
        }
    }
}
