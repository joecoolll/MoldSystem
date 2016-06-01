using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class WorkNoRunningBO
    {
        private int? _id;
        private int? _newid;
        private string _startworkno;
        private int? _datayear;

        public int? ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public int? NewID
        {
            get
            {
                return _newid;
            }
            set
            {
                _newid = value;
            }
        }

        public string StartWorkNo
        {
            get
            {
                return _startworkno;
            }
            set
            {
                _startworkno = value;
            }
        }

        public int? DataYear
        {
            get
            {
                return _datayear;
            }
            set
            {
                _datayear = value;
            }
        }
    }
}
