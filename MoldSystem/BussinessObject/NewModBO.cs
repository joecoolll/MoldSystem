using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class NewModBO
    {
        private int? _newmodID;
        private int? _newnewmodID;
        private string _newmodDetail;

        public int? NewModID
        {
            get
            {
                return _newmodID;
            }
            set
            {
                _newmodID = value;
            }
        }

        public int? NewNewModID
        {
            get
            {
                return _newnewmodID;
            }
            set
            {
                _newnewmodID = value;
            }
        }

        public string NewModDetail
        {
            get
            {
                return _newmodDetail;
            }
            set
            {
                _newmodDetail = value;
            }
        }
    }
}
