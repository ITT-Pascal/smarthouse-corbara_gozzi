using System;
using System.Drawing;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.LampClasses;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTVSet
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> CCTVset { get; private set; }
        private Password AdminPassword;

        //------CONSTRUCTORS------
        public CCTVSet() 
        { 
            CCTVset = new List<CCTV>();
            AdminPassword = new Password("1234567890");
        }
        public CCTVSet(Password adminPassword)
        {
            CCTVset = new List<CCTV>();
            AdminPassword = adminPassword;
        }

        //------METHODS------
        public void AddCCTV(CCTV camera) 
        { 
            CCTVset.Add(camera); 
        }

        public void AddCCTVIn(int position, CCTV camera)
        {
            CCTVset.Insert(position, camera);
        }

        public void RemoveCCTVAt(int position, Password adminPassword)
        {
            if (AdminPassword == adminPassword)
                CCTVset.RemoveAt(position);
            else
                throw new ArgumentException("Password errata");
        }
        private int GetPositionOfCCTVBy(Guid id)
        {
            List<Guid> GuidList = new List<Guid>();
            foreach (CCTV cam in CCTVset)
                GuidList.Add(cam.ID);
            return Array.IndexOf(GuidList.ToArray(), id);
        }
        public void RemoveCCTVBy(Guid id, Password adminPassword)
        {
            if (AdminPassword != adminPassword)
                throw new ArgumentException("Password errata");
            if(GetPositionOfCCTVBy(id) == -1)
                throw new ArgumentException("ID assente");
            CCTVset.Remove(CCTVset[GetPositionOfCCTVBy(id)]);
        }
        public void RemoveCCTVBy(Name name, Password adminPassword)
        {
            if (AdminPassword == adminPassword)
            {
                for (int i = 0; i < CCTVset.Count; i++)
                {
                    if (CCTVset[i].Name == name)
                        CCTVset.RemoveAt(i);
                }
            }
            else
                throw new ArgumentException("Password errata");
        }
        public void SwitchOn()
        {
            foreach (CCTV cam in CCTVset)
            {
                cam.SwitchOn();
            }
        }

        /// <summary>
        /// Accende telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id) 
        {
            if (GetPositionOfCCTVBy(id) == -1)
                throw new ArgumentException("ID assente");
            CCTVset[GetPositionOfCCTVBy(id)].SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(Name name)
        {
            foreach (CCTV cam in CCTVset)
            {
                if (GetCCTVWith(name).Contains(cam))
                    cam.SwitchOn();
            }
        }
        private List<CCTV> GetCCTVWith(Name name)
        {
            List<CCTV> cams = new List<CCTV>();
            foreach (CCTV cam in CCTVset)
            {
                if (cam.Name == name)
                    cams.Add(cam);
            }
            return cams;
        }
        public void SwitchOff(Password adminPassword)
        {
            if (AdminPassword == adminPassword)
                foreach (CCTV cam in CCTVset)
                {
                    cam.SwitchOff();
                }
            else
                throw new ArgumentException("Password errata");
        }

        /// <summary>
        /// Spegne telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id, Password adminPassword)
        {
            if (GetPositionOfCCTVBy(id) == -1)
                throw new ArgumentException("ID assente");
            if(AdminPassword != adminPassword)
                throw new ArgumentException("Password errata");
            CCTVset[GetPositionOfCCTVBy(id)].SwitchOff();
        }

        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(Name name, Password adminPassword)
        {
            if (AdminPassword == adminPassword)
            {
                foreach (CCTV cam in CCTVset)
                {
                    if (GetCCTVWith(name).Contains(cam))
                        cam.SwitchOff();
                }
            }
            else
                throw new ArgumentException("Password errata");
        }
        
        //CAMBIA L'ANGOLO DI TUTTE LE TELECAMERE
        public void ChangeAllCCTVDegreesInto(Degrees newDegrees)
        {
            foreach(CCTV cam in CCTVset)
            {
                if (cam.DeviceStatus == DeviceStatus.On)
                    cam.SetCCTVDegreesInto(newDegrees);
            }
        }

        //CAMBIA L'ANGOLO SOLO PER QUELLA CON IL GUID CORRISPONDENTE
        public void ChangeCCTVDegreesBy(Guid id, Degrees degrees)
        {
            if (GetPositionOfCCTVBy(id) == -1)
                throw new ArgumentException("ID assente");
            if (CCTVset[GetPositionOfCCTVBy(id)].DeviceStatus == DeviceStatus.On)
                CCTVset[GetPositionOfCCTVBy(id)].SetCCTVDegreesInto(degrees);
        }

        //CAMBIA L'ANGOLO PER QUELLE CON IL NOME CRRISPONDENTE
        public void ChangeCCTVDegreesBy(Name name, Degrees degrees)
        {
            foreach (CCTV cam in CCTVset)
            {
                if (GetCCTVWith(name).Contains(cam))
                    cam.SetCCTVDegreesInto(degrees);
            }
        }
    }
}
