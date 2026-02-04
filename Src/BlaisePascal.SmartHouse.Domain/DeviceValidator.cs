namespace BlaisePascal.SmartHouse.Domain
{
    public static class DeviceValidator
    {
        private const int minValueOfDevices = 1;
      

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
}
