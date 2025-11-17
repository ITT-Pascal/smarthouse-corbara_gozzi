using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp:AbstractLamp
    {
        //Costanti per impostare max brightness alla creazione e per inserire brightness all'accensione
        private const int brightnessAtOn = 50;
        private const int maxBrightnessOfLamp = 100;
        public Lamp()
        {
            IsOn = false;
            Brightness = 0;
            ID = new Guid();
            MaxBrightness = maxBrightnessOfLamp;
        }
        public Lamp(string name)
        {
            IsOn = false;
            Brightness = 0;
            ID = new Guid();
            Name = name;
            MaxBrightness = maxBrightnessOfLamp;
        }
        public Lamp(Guid Id, string name)
        {
            IsOn = false;
            Brightness = 0;
            ID = Id;
            Name = name;
            MaxBrightness = maxBrightnessOfLamp;
        }

        public override void TurnOn()
        {
            IsOn = true;
            Brightness = brightnessAtOn;
        }
        public override void TurnOff()
        {  
            IsOn = false;
            Brightness = 0;
        }
        public override void ChangeBrightness(int brightnessToAdd)
        {
            if (IsOn)
            {
                Brightness = BrightnessGestor.ValidateNewBrightness(brightnessToAdd, Brightness, MaxBrightness);
            }
        }
    }
}
