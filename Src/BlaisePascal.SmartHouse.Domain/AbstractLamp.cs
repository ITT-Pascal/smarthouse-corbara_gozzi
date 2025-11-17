namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public bool IsOn { get; set; }
        public int Brightness { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int MaxBrightness { get; set; }
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void ChangeBrightness(int brightnessAdded);
    }
}
