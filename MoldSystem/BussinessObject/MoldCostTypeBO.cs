using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldCostTypeBO
    {
        private int? _moldcosttypeID;
        private int? _newmoldcosttypeID;
        private string _moldcosttypeDetail;

        public int? MoldCostTypeID
        {
            get
            {
                return _moldcosttypeID;
            }
            set
            {
                _moldcosttypeID = value;
            }
        }

        public int? NewMoldCostTypeID
        {
            get
            {
                return _newmoldcosttypeID;
            }
            set
            {
                _newmoldcosttypeID = value;
            }
        }

        public string MoldCostTypeDetail
        {
            get
            {
                return _moldcosttypeDetail;
            }
            set
            {
                _moldcosttypeDetail = value;
            }
        }
    }
}
