namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp:AbstractLamp
    {
        public bool IsOn { get; set; }
        //INTENSITA' LUMINOSA
        public int Brightness { get; set; }

        public Lamp()
        {
            IsOn = false;
            Brightness = 0;
        }

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Brightness = 50;
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Brightness = 0;
            }
        }

        public override void ChangeBrightness(int brightnessValue)
        { 
            if (IsOn)
            { //50-10= 40, 50-70= -20
                Brightness = Math.Max(Brightness + brightnessValue, 1);
                Brightness = Math.Min(Brightness, 100);
            }

        }


    }
}
