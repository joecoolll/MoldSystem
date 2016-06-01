using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldMaterialBO
    {
        private int? _moldmatID;
        private int? _newmoldmatID;
        private string _moldmatName;

        public int? MoldMatID
        {
            get
            {
                return _moldmatID;
            }
            set
            {
                _moldmatID = value;
            }
        }

        public int? NewMoldMatID
        {
            get
            {
                return _newmoldmatID;
            }
            set
            {
                _newmoldmatID = value;
            }
        }

        public string MoldMatName
        {
            get
            {
                return _moldmatName;
            }
            set
            {
                _moldmatName = value;
            }
        }
    }
}
