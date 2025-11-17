using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {
        //Costante per impostare max brightness alla creazione
        private const int maxBrightnessOfLamp = 70;

        public EcoLamp()
        {
            IsOn = false;
            Brightness = 0;
            ID = new Guid();
            MaxBrightness = maxBrightnessOfLamp;
        }
        public EcoLamp(Guid Id)
        {
            IsOn = false;
            Brightness = 0;
            MaxBrightness = maxBrightnessOfLamp;
            ID = Id;
        }
        public EcoLamp(Guid Id, string name)
        {
            IsOn = false;
            Brightness = 0;
            MaxBrightness = maxBrightnessOfLamp;
            ID = Id;
            Name = name;
        }

        public override void TurnOn()
        {
            IsOn = true;
            Brightness = MaxBrightness/2;
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
        /// <summary>
        /// Cambia la brightness massima, dato che è un'eco lampada
        /// </summary>
        /// <param name="newMaxBrightness"></param>
        public void ChangeMaxBrightness(int newMaxBrightness)
        {
            MaxBrightness = BrightnessGestor.ValidateNewMaxBrightness(newMaxBrightness);
        }
    }
}
