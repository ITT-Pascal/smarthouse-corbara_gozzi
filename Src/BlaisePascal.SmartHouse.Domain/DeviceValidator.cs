namespace BlaisePascal.SmartHouse.Domain
{
    public static class DeviceValidator
    {
        private const int minValueOfDevices = 1;
        //VALIDA INTENSITA' IN ABSTRACT LAMP
        public static int ValidateNewIntensity(int newIntensity, int maxBrightness)
        {
            if (newIntensity < minValueOfDevices)
                throw new ArgumentException("Negative number can't be avariable");
            else if (newIntensity > maxBrightness)
                throw new ArgumentException("Can't be a number greater than max brightness of lamp");
            return newIntensity;
        }

        //VALIDA LA VELOCITA' NELL'AIR CONDITIONER
        public static int ValidateAcSpeed(int amount, int maxSpeed)
        {
            if (amount > maxSpeed)
                return maxSpeed;
            else if (amount < minValueOfDevices)
                return minValueOfDevices;
            else
                return amount;
        }

        //VALIDA LA TEMPERATURA TARGET NEL THERMOSTAT
        public static int ValidateTargetTemperature(int temp)
        {
            int maxTemp = 36; //TEMPERATURA PER NON CAUSARE DANNI CORPOREI
            if (temp > maxTemp)
                return maxTemp;
            else if (temp < minValueOfDevices)
                return minValueOfDevices;
            else
                return temp;
        }

        //VALIDA GRADI NELLA CCTV
        public static int ValidateDegrees(int degrees)
        {
            if (degrees < 0)
                throw new ArgumentOutOfRangeException();
            else if (degrees > 360)
                throw new ArgumentOutOfRangeException();
            else
                return degrees;
        }
    }
}
