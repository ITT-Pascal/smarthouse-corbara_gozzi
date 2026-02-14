using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using BlaisePascal.SmartHouse.Domain.Abstractions;
using BlaisePascal.SmartHouse.Domain.CCTVDevices.ValueObjects;
using BlaisePascal.SmartHouse.Domain.LampClasses;
using BlaisePascal.SmartHouse.Domain.Shared;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevices
{
    public class CCTVSet
    {
        // -------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> SetOfCCTV { get; private set; }
        private Password AdminPassword { get; }

        //    ------CONSTRUCTORS------
        public CCTVSet() 
        {
            SetOfCCTV = [];
            AdminPassword = Password.NewPassword("1234567890");
        }
        public CCTVSet(Password adminPassword)
        {
            SetOfCCTV = [];
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
                throw new ArgumentException($"Password[{Try}]: Incorrect try");
        }

        //--GETTER METHODS--

        private int GetPositionOfCCTVBy(Guid id)
        {
            List<Guid> GuidList = [];
            foreach (CCTV cam in SetOfCCTV)
                GuidList.Add(cam.ID);
            if (Array.IndexOf([.. GuidList], id) == -1)   // [.. GuidList] <= (GuidList.ToArray())
                throw new ArgumentException($"ID[{id}]: Id not identified");
            return Array.IndexOf([.. GuidList], id);
        }

        //--ADD/REMOVE METHODS--

        public void AddCCTV(CCTV camera) 
        { 
            SetOfCCTV.Add(camera); 
        }
        public void AddCCTVIn(int position, CCTV camera)
        {
            if (position < 0 || position >= SetOfCCTV.Count)
                throw new ArgumentException($"Position[{position}]: Position out of range");
            if (SetOfCCTV[position] != null)
                throw new Exception($"Position[{position}]: Cannot add CCTV in positions already taken");
            SetOfCCTV.Insert(position, camera);
        }
        public void RemoveCCTVAt(int position, Password password)
        {
            if (position < 0 || position >= SetOfCCTV.Count)
                throw new ArgumentException($"Position[{position}]: Position out of range");
            IsPasswordCorrect(password);
            SetOfCCTV.RemoveAt(position);
        }
        public void RemoveCCTVBy(Guid id, Password password)
        {
            IsPasswordCorrect(password);
            SetOfCCTV.Remove(SetOfCCTV[GetPositionOfCCTVBy(id)]);
        }
        public void RemoveCCTVBy(DeviceName name, Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    RemoveCCTVBy(cam.ID, password);
        }

        //--SWITCH METHODS--
        public void SwitchOn()
        {
            foreach (CCTV cam in SetOfCCTV)
                cam.SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id) 
        {
            SetOfCCTV[GetPositionOfCCTVBy(id)].SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    SwitchOnBy(cam.ID);
        }

        public void SwitchOff(Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in SetOfCCTV)
                cam.SwitchOff();
        }   

        /// <summary>
        /// Spegne telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id, Password password)
        {
            IsPasswordCorrect(password);
            SetOfCCTV[GetPositionOfCCTVBy(id)].SwitchOff();
        }

        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name, Password password)
        {
            IsPasswordCorrect(password);
            foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    SwitchOffBy(cam.ID, password);
        }

        //--CHANGER METHODS--

        //CAMBIA L'ANGOLO DI TUTTE LE TELECAMERE
        public void ChangeAllCCTVDegreesTo(Degrees newDegrees)
        {
            foreach (CCTV cam in SetOfCCTV)
                cam.SetCCTVDegreesTo(newDegrees);
        }

        //CAMBIA L'ANGOLO SOLO PER QUELLA CON IL GUID CORRISPONDENTE
        public void ChangeCCTVDegreesBy(Guid id, Degrees degrees)
        {
            SetOfCCTV[GetPositionOfCCTVBy(id)].SetCCTVDegreesTo(degrees);
        }

        //CAMBIA L'ANGOLO PER QUELLE CON IL NOME CRRISPONDENTE
        public void ChangeCCTVDegreesBy(DeviceName name, Degrees degrees)
        {
            foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    ChangeCCTVDegreesBy(cam.ID, degrees);
        }

        public void ChangeAllCCTVZoomTo(Zoom zoom)
        {
            foreach (CCTV cam in SetOfCCTV)
                cam.SetCCTVZoomTo(zoom);
        }

        public void ChangeCCTVZoomBy(Guid id, Zoom zoom)
        {
            SetOfCCTV[GetPositionOfCCTVBy(id)].SetCCTVZoomTo(zoom);
        }
        public void ChangeCCTVZoomBy(DeviceName name, Zoom zoom)
        {
            foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    ChangeCCTVZoomBy(cam.ID, zoom);
        }
    }
}
