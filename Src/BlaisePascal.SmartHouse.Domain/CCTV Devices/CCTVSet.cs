using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.CCTVClasses
{
    public class CCTVSet
    {
        // -------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> CCTVset { get; private set; }
        private Password AdminPassword { get; }

        //    ------CONSTRUCTORS------
        public CCTVSet() 
        {
            CCTVset = [];
            AdminPassword = Password.NewPassword("1234567890");
        }
        public CCTVSet(Password adminPassword)
        {
            CCTVset = [];
            AdminPassword = adminPassword;
        }

        //     ------METHODS------

        /// <summary>
        /// Metodo che lancia errore se la password è sbagliata
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private void IsPasswordCorrect(Password Try)
        {
            if (Try != AdminPassword)
                throw new ArgumentException("Password: Incorrect try");
        }

        //--GETTER METHODS--

        private int GetPositionOfCCTVBy(Guid id)
        {
            List<Guid> GuidList = [];
            foreach (CCTV cam in CCTVset)
                GuidList.Add(cam.ID);
            if (Array.IndexOf([.. GuidList], id) == -1)   // [.. GuidList] <= (GuidList.ToArray())
                throw new ArgumentException("ID: Id not identified");
            return Array.IndexOf([.. GuidList], id);
        }

        //--ADD/REMOVE METHODS--

        public void AddCCTV(CCTV camera) 
        { 
            CCTVset.Add(camera); 
        }
        public void AddCCTVIn(int position, CCTV camera)
        {
            if (position < 0 || position >= CCTVset.Count)
                throw new ArgumentException("Position out of range");
            if (CCTVset[position] != null)
                throw new Exception("Position not empty");
            CCTVset.Insert(position, camera);
        }
        public void RemoveCCTVAt(int position, Password password)
        {
            if (position < 0 || position >= CCTVset.Count)
                throw new ArgumentException("Position out of range");
            IsPasswordCorrect(password);
            CCTVset.RemoveAt(position);
        }
        public void RemoveCCTVBy(Guid id, Password password)
        {
            IsPasswordCorrect(password);
            CCTVset.Remove(CCTVset[GetPositionOfCCTVBy(id)]);
        }
        public void RemoveCCTVBy(DeviceName name, Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in CCTVset)
                if (cam.Name == name)
                    RemoveCCTVBy(cam.ID, password);
        }

        //--SWITCH METHODS--
        public void SwitchOn()
        {
            foreach (CCTV cam in CCTVset)
                cam.SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id) 
        {
            CCTVset[GetPositionOfCCTVBy(id)].SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            foreach (CCTV cam in CCTVset)
                if (cam.Name == name)
                    SwitchOnBy(cam.ID);
        }

        public void SwitchOff(Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in CCTVset)
                cam.SwitchOff();
        }   

        /// <summary>
        /// Spegne telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id, Password password)
        {
            IsPasswordCorrect(password);
            CCTVset[GetPositionOfCCTVBy(id)].SwitchOff();
        }

        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name, Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in CCTVset)
                if (cam.Name == name)
                    SwitchOffBy(cam.ID, password);
        }

        //--CHANGER METHODS--

        //CAMBIA L'ANGOLO DI TUTTE LE TELECAMERE
        public void ChangeAllCCTVDegreesInto(Degrees newDegrees)
        {
            foreach (CCTV cam in CCTVset)
                if (cam.DeviceStatus == DeviceStatus.On)
                    cam.SetCCTVDegreesInto(newDegrees);
        }

        //CAMBIA L'ANGOLO SOLO PER QUELLA CON IL GUID CORRISPONDENTE
        public void ChangeCCTVDegreesBy(Guid id, Degrees degrees)
        {
            if (CCTVset[GetPositionOfCCTVBy(id)].DeviceStatus == DeviceStatus.On)
                CCTVset[GetPositionOfCCTVBy(id)].SetCCTVDegreesInto(degrees);
        }

        //CAMBIA L'ANGOLO PER QUELLE CON IL NOME CRRISPONDENTE
        public void ChangeCCTVDegreesBy(DeviceName name, Degrees degrees)
        {
            foreach (CCTV cam in CCTVset)
                if (cam.Name == name)
                    if (cam.DeviceStatus == DeviceStatus.On)
                        ChangeCCTVDegreesBy(cam.ID, degrees);
        }
    }
}
