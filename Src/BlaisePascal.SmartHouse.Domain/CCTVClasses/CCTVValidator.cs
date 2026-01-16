using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public static class CCTVValidator
    {
        public static int ValidateDegrees(int degrees)
        {
            if (degrees < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (degrees > 360)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return degrees;
            }
        }
    }
}
