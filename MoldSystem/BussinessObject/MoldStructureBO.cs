using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldStructureBO
    {
        private int? _moldstructureID;
        private int? _newmoldstructureID;
        private string _moldstructureName;

        public int? MoldStructureID
        {
            get
            {
                return _moldstructureID;
            }
            set
            {
                _moldstructureID = value;
            }
        }

        public int? NewMoldStructureID
        {
            get
            {
                return _newmoldstructureID;
            }
            set
            {
                _newmoldstructureID = value;
            }
        }

        public string MoldStructureName
        {
            get
            {
                return _moldstructureName;
            }
            set
            {
                _moldstructureName = value;
            }
        }
    }
}
