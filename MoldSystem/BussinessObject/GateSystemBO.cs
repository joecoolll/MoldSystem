using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class GateSystemBO
    {
        private int? _gatesysID;
        private int? _newgatesysID;
        private string _gatesysName;

        public int? GateSysID
        {
            get
            {
                return _gatesysID;
            }
            set
            {
                _gatesysID = value;
            }
        }

        public int? NewGateSysID
        {
            get
            {
                return _newgatesysID;
            }
            set
            {
                _newgatesysID = value;
            }
        }

        public string GateSysName
        {
            get
            {
                return _gatesysName;
            }
            set
            {
                _gatesysName = value;
            }
        }
    }
}
