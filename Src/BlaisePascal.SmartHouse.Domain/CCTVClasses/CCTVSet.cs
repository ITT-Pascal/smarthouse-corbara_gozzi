using System;
using BlaisePascal.SmartHouse.Domain.LampClasses;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTVSet
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> CCTVset { get; private set; }
        private string? AdminPassword;

        //------CONSTRUCTORS------
        public CCTVSet() { CCTVset = new List<CCTV>(); }
        public CCTVSet(string adminPassword)
        {
            CCTVset = new List<CCTV>();
            AdminPassword = adminPassword;
        }

        //------METHODS------
        public void AddCCTV(CCTV camera) 
        { 
            CCTVset.Add(camera); 
        }

        public void AddCCTV(CCTV camera, int pos)
        {
            CCTVset.Insert(pos, camera);
        }

        public void RemoveCCTV(int pos, string adminPassword)
        {
            if (AdminPassword == adminPassword)
                CCTVset.RemoveAt(pos);
            else
                throw new ArgumentException("Password errata");
        }
        private int GetPositionOfCCTV(Guid id)
        {
            int pos = 0;
            for (int i = 0; i < CCTVset.Count; i++)
            {
                if (CCTVset[i].ID == id)
                    pos = i;
            }
            return pos;
        }
        public void RemoveCCTV(Guid id, string adminPassword)
        {
            if (AdminPassword == adminPassword)
                CCTVset.Remove(CCTVset[GetPositionOfCCTV(id)]);
            else
                throw new ArgumentException("Password errata");
        }
        public void RemoveCCTV(string name, string adminPassword)
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
        public void SwitchOn(Guid guid) 
        { 
            CCTVset[GetPositionOfCCTV(guid)].SwitchOn(); 
        }

        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOn(string name)
        {
            foreach (CCTV cam in CCTVset)
            {
                if (GetCCTVWithName(name).Contains(cam))
                    cam.SwitchOn();
            }
        }
        private List<CCTV> GetCCTVWithName(string name)
        {
            List<CCTV> cams = new List<CCTV>();
            foreach (CCTV cam in CCTVset)
            {
                if (cam.Name == name)
                    cams.Add(cam);
            }
            return cams;
        }
        public void SwitchOff(string adminPassword)
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
        public void SwitchOff(Guid guid, string adminPassword)
        {
            if (AdminPassword == adminPassword)
                CCTVset[GetPositionOfCCTV(guid)].SwitchOff();
            else
                throw new ArgumentException("Password errata");
        }

        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOff(string name, string adminPassword)
        {
            if (AdminPassword == adminPassword)
            {
                foreach (CCTV cam in CCTVset)
                {
                    if (GetCCTVWithName(name).Contains(cam))
                        cam.SwitchOff();
                }
            }
            else
                throw new ArgumentException("Password errata");
        }
        
        //CAMBIA L'ANGOLO DI TUTTE LE TELECAMERE
        public void ChangeAllCCTVDegrees(int degrees)
        {
            foreach(CCTV cam in CCTVset)
            {
                if (cam.DeviceStatus == DeviceStatus.On)
                    cam.SetCCTVDegrees(degrees);
            }
        }

        //CAMBIA L'ANGOLO SOLO PER QUELLA CON IL GUID CRRISPONDENTE
        public void ChangeCCTVDegrees(Guid id, int degrees)
        {
            if (CCTVset[GetPositionOfCCTV(id)].DeviceStatus == DeviceStatus.On)
                CCTVset[GetPositionOfCCTV(id)].SetCCTVDegrees(degrees);
        }

        //CAMBIA L'ANGOLO PER QUELLE CON IL NOME CRRISPONDENTE
        public void ChangeCCTVDegrees(string name, int degrees)
        {
            foreach (CCTV cam in CCTVset)
            {
                if (GetCCTVWithName(name).Contains(cam))
                    cam.SetCCTVDegrees(degrees);
            }
        }
    }
}
