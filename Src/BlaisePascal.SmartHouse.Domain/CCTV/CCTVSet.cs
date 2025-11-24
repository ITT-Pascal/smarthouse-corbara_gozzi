using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.LAMP;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public class CCTVSet
    {
        //-------ATTRIBUTES AND PROPERTY-------
        public List<CCTV> CCTVset { get; set; }
        private string ?AdminPassword;

        //------CONSTRUCTORS------
        public CCTVSet()
        {
            CCTVset = new List<CCTV>();
        }
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
        public void RemoveCCTV(int pos)
        {
            CCTVset.RemoveAt(pos);
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
        public void RemoveCCTV(Guid id)
        {
            CCTVset.Remove(CCTVset[GetPositionOfCCTV(id)]);
        }
        public void RemoveCCTV(string name)
        {
            for (int i = 0; i < CCTVset.Count; i++)
            {
                if (CCTVset[i].CameraName == name)
                    CCTVset.RemoveAt(i);
            }
        }
        public void SwitchOn()
        {
            for (int i = 0; i < CCTVset.Count; i++)
            {
                CCTVset[i].SwitchOnCCTV();
            }
        }
        /// <summary>
        /// Accende telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOn(Guid guid)
        {
            CCTVset[GetPositionOfCCTV(guid)].SwitchOnCCTV();
        }
        /// <summary>
        /// Accende telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOn(string name)
        {
            for (int i = 0; i < CCTVset.Count; i++)
            {
                if (CCTVset[i].CameraName == name)
                {
                    CCTVset[i].SwitchOnCCTV();
                }
            }
        }
        public void SwitchOff()
        {
            for (int i = 0; i < CCTVset.Count; i++)
            {
                CCTVset[i].SwitchOffCCTV();
            }
        }
        /// <summary>
        /// Spegne telecamera in base all'ID
        /// </summary>
        /// <param name="guid"></param>
        public void SwitchOff(Guid guid)
        {
            CCTVset[GetPositionOfCCTV(guid)].SwitchOffCCTV();
        }
        /// <summary>
        /// Spegne telecamera in base al nome
        /// </summary>
        /// <param name="name"></param>
        public void SwitchOff(string name)
        {
            for (int i = 0; i < CCTVset.Count; i++)
            {
                if (CCTVset[i].CameraName == name)
                {
                    CCTVset[i].SwitchOffCCTV();
                }
            }
        }
    }
}
