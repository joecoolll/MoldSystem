using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class Worklist3BO
    {
        private string _workno;
        private string _newworkno;
        private string _partname;
        private string _clientname;

        public string WorkNo
        {
            get
            {
                return _workno;
            }
            set
            {
                _workno = value;
            }
        }

        public string NewWorkNo
        {
            get
            {
                return _newworkno;
            }
            set
            {
                _newworkno = value;
            }
        }

        public string PartName
        {
            get
            {
                return _partname;
            }
            set
            {
                _partname = value;
            }
        }

        public string ClientName
        {
            get
            {
                return _clientname;
            }
            set
            {
                _clientname = value;
            }
        }
    }
}
