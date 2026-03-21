using System.Runtime.CompilerServices;
using BlaisePascal.SmartHouse.Domain.Devices.Abstractions;
using BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTVDevices
{
    public sealed class CCTVSet: AbstractDevice, INullable, ISwitchable
    {
        // -------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> SetOfCCTV { get; private set; }
        public Password AdminPassword { get; }
        public bool AccessPermission { get; private set; } = false;

		//    ------CONSTRUCTORS------
		public CCTVSet() 
        {
            SetOfCCTV = [];
            AdminPassword = Password.NewPassword("Ale6767?");
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
            if (Try.Word == AdminPassword.Word)
                AccessPermission = true;
            else
                throw new ArgumentException("Password: Wrong password", nameof(Try));
        }
        private void CheckAccessPermission()
        {
            if (!AccessPermission)
                throw new InvalidOperationException("Access denied: You don't have permission to access the system");
            //ERRORE CHE INDICA L'INCOMPATIBILITA' DI UNO STATO ALLA CHIAMATA DEL METODO
        }
        public void CheckIsNotNull(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
        }
        public void CheckIsInRange(int position)
        {
            if (position < 0 || position > SetOfCCTV.Count)
                throw new ArgumentOutOfRangeException(nameof(position), "Position: Position out of range");
        }


        //--GETTER METHODS--

        private int GetPositionOfCCTVBy(Guid id)
        {
            CheckAccessPermission();
            int pos = SetOfCCTV.FindIndex(cam => cam.ID == id);
            if (pos == -1)
                throw new InvalidOperationException("ID: Id not identified");
            return pos;
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
            CheckIsNotNull(camera);
            CheckIsInRange(position);
            SetOfCCTV.Insert(position, camera);
        }
        public void RemoveCCTVAt(int position)
        {
            CheckAccessPermission();
            CheckIsInRange(position);
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
            RemoveCCTVBy(SetOfCCTV.First(cam => cam.Name.DevName == name.DevName).ID);
        }

        //--SWITCH METHODS--
        public override void SwitchOn()
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
            SetOfCCTV.First(cam => cam.Name == name).SwitchOn();
            //CERCA IL PRIMO ELEMENTO cam CHE SODDISFI LA CONDIZIONE, SENNO' LANCIA INVALID OP EXC
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
            SetOfCCTV.First(cam => cam.Name == name).SwitchOff();
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
            SetOfCCTV.First(cam => cam.Name == name).SetCCTVDegreesTo(degrees);
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
            SetOfCCTV.First(cam => cam.Name == name).SetCCTVZoomTo(zoom);
        }
    }
}
