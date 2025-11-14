namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp:AbstractLamp
    {
        private const int minValueOfMaxBrightness = 1;
        private const int maxValueOfMaxBrightness = 100;
        private const int brightnessValueAtTurnOn = 50;
        public Lamp(string name)
        {
            IsOn = false;
            Brightness = 0;
            Guid = new Guid();
            Name = name;
        }
        public Lamp(Guid guid, string name)
        {
            IsOn = false;
            Brightness = 0;
            Guid = guid;
            Name = name;
        }

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Brightness = brightnessValueAtTurnOn;
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
            {
                Brightness = Math.Max(Brightness + brightnessValue, minValueOfMaxBrightness);
                Brightness = Math.Min(Brightness, maxValueOfMaxBrightness);
            }
        }
    }
}
