using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldCostItemBO
    {
        private int? _moldcostitemID;
        private int? _newmoldcostitemID;
        private string _moldcostitemDetail;

        public int? MoldCostItemID
        {
            get
            {
                return _moldcostitemID;
            }
            set
            {
                _moldcostitemID = value;
            }
        }

        public int? NewMoldCostItemID
        {
            get
            {
                return _newmoldcostitemID;
            }
            set
            {
                _newmoldcostitemID = value;
            }
        }

        public string MoldCostItemDetail
        {
            get
            {
                return _moldcostitemDetail;
            }
            set
            {
                _moldcostitemDetail = value;
            }
        }
    }
}
