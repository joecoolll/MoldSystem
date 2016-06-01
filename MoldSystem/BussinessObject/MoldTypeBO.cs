using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldTypeBO
    {
        private int? _moldtypeID;
        private int? _newmoldtypeID;
        private string _moldtypeDetail;

        public int? MoldTypeID
        {
            get
            {
                return _moldtypeID;
            }
            set
            {
                _moldtypeID = value;
            }
        }

        public int? NewMoldTypeID
        {
            get
            {
                return _newmoldtypeID;
            }
            set
            {
                _newmoldtypeID = value;
            }
        }

        public string MoldTypeDetail
        {
            get
            {
                return _moldtypeDetail;
            }
            set
            {
                _moldtypeDetail = value;
            }
        }
    }
}
