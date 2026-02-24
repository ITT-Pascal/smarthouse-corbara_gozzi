using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices
{
    public sealed class CCTVSet: AbstractDevice, INullable
    {
        // -------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> SetOfCCTV { get; private set; }
        private Password AdminPassword { get; }
        public bool AccessPermission { get; private set; } = false;

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
        
        public void AccessToSistem(Password Try)
        {
            if(Try == AdminPassword)
                AccessPermission = true;
            else
                throw new ArgumentException($"Password: Wrong password", nameof(Try));
        }
        private void CheckAccessPermission()
        {
            if (!AccessPermission)
                throw new InvalidOperationException($"Access denied: You don't have permission to access the system");
            //ERRORE CHE INDICA L'INCOMPATIBILITA' DI UNO STATO ALLA CHIAMATA DEL METODO

        }
        public void CheckIsNotNull(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
        }

		//--GETTER METHODS--

		private int GetPositionOfCCTVBy(Guid id)
        {
            CheckAccessPermission();
			List<Guid> GuidList = [];
            foreach (CCTV cam in SetOfCCTV)
                GuidList.Add(cam.ID);
            if (Array.IndexOf([.. GuidList], id) == -1)   // [.. GuidList] <= (GuidList.ToArray())
                throw new ArgumentException($"ID: Id not identified", nameof(id));
            return Array.IndexOf([.. GuidList], id);
        }

        //--ADD/REMOVE METHODS--

        public void AddCCTV(CCTV camera) 
        {
            CheckIsNotNull(camera);
			CheckAccessPermission();
			SetOfCCTV.Add(camera); 
        }
        public void AddCCTVIn(int position, CCTV camera)
        {
            CheckAccessPermission();
            if (position < 0 || position >= SetOfCCTV.Count)
                throw new ArgumentOutOfRangeException(nameof(position), $"Position: Position out of range");
            if (SetOfCCTV[position] != null)
                throw new ArgumentException($"Position: Cannot add CCTV in positions already taken", nameof(position));
            SetOfCCTV.Insert(position, camera);
        }
        public void RemoveCCTVAt(int position)
        {
            if (position < 0 || position >= SetOfCCTV.Count)
                throw new ArgumentOutOfRangeException(nameof(position), $"Position: Position out of range");
            CheckAccessPermission();
			SetOfCCTV.RemoveAt(position);
        }
        public void RemoveCCTVBy(Guid id)
        {
			CheckAccessPermission();
			SetOfCCTV.Remove(SetOfCCTV[GetPositionOfCCTVBy(id)]);
        }
        public void RemoveCCTVBy(DeviceName name)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    RemoveCCTVBy(cam.ID);
        }

        //--SWITCH METHODS--
        public void SwitchOn(Password Try)
        {
            AccessToSistem(Try);
			foreach (CCTV cam in SetOfCCTV)
                cam.SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOnBy(Guid id) 
        {
            CheckAccessPermission();
            SetOfCCTV[GetPositionOfCCTVBy(id)].SwitchOn();
        }

        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOnBy(DeviceName name)
        {
            CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    SwitchOnBy(cam.ID);
        }

        public override void SwitchOff()
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                cam.SwitchOff();
            AccessPermission = false;
        }   

        /// <summary>
        /// Spegne telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOffBy(Guid id)
        {
			CheckAccessPermission();
            SetOfCCTV[GetPositionOfCCTVBy(id)].SwitchOff();
        }

        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOffBy(DeviceName name)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    SwitchOffBy(cam.ID);
        }

        //--CHANGER METHODS--

        //CAMBIA L'ANGOLO DI TUTTE LE TELECAMERE
        public void ChangeAllCCTVDegreesTo(Degrees newDegrees)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                cam.SetCCTVDegreesTo(newDegrees);
        }

        //CAMBIA L'ANGOLO SOLO PER QUELLA CON IL GUID CORRISPONDENTE
        public void ChangeCCTVDegreesBy(Guid id, Degrees degrees)
        {
			CheckAccessPermission();
			SetOfCCTV[GetPositionOfCCTVBy(id)].SetCCTVDegreesTo(degrees);
        }

        //CAMBIA L'ANGOLO PER QUELLE CON IL NOME CRRISPONDENTE
        public void ChangeCCTVDegreesBy(DeviceName name, Degrees degrees)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    ChangeCCTVDegreesBy(cam.ID, degrees);
        }

        public void ChangeAllCCTVZoomTo(Zoom zoom)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                cam.SetCCTVZoomTo(zoom);
        }

        public void ChangeCCTVZoomBy(Guid id, Zoom zoom)
        {
			CheckAccessPermission();
			SetOfCCTV[GetPositionOfCCTVBy(id)].SetCCTVZoomTo(zoom);
        }
        public void ChangeCCTVZoomBy(DeviceName name, Zoom zoom)
        {
			CheckAccessPermission();
			foreach (CCTV cam in SetOfCCTV)
                if (cam.Name == name)
                    ChangeCCTVZoomBy(cam.ID, zoom);
        }
    }
}
