using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldingMaterialBO
    {
        private int? _moldingmatID;
        private int? _newmoldingmatID;
        private string _moldingmatName;

        public int? MoldingMatID
        {
            get
            {
                return _moldingmatID;
            }
            set
            {
                _moldingmatID = value;
            }
        }

        public int? NewMoldingMatID
        {
            get
            {
                return _newmoldingmatID;
            }
            set
            {
                _newmoldingmatID = value;
            }
        }

        public string MoldingMatName
        {
            get
            {
                return _moldingmatName;
            }
            set
            {
                _moldingmatName = value;
            }
        }
    }
}
