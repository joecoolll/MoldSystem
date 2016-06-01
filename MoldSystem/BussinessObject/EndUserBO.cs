using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class EndUserBO
    {
        private int? _enduserID;
        private int? _newenduserID;
        private string _enduserName;

        public int? EndUserID
        {
            get
            {
                return _enduserID;
            }
            set
            {
                _enduserID = value;
            }
        }

        public int? NewEndUserID
        {
            get
            {
                return _newenduserID;
            }
            set
            {
                _newenduserID = value;
            }
        }

        public string EndUserName
        {
            get
            {
                return _enduserName;
            }
            set
            {
                _enduserName = value;
            }
        }
    }
}
