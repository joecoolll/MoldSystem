using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class DifficultyIndexBO
    {
        private int? _diffiindexID;
        private int? _newdiffiindexID;
        private string _diffiindexName;

        public int? DiffiIndexID
        {
            get
            {
                return _diffiindexID;
            }
            set
            {
                _diffiindexID = value;
            }
        }

        public int? NewDiffiIndexID
        {
            get
            {
                return _newdiffiindexID;
            }
            set
            {
                _newdiffiindexID = value;
            }
        }

        public string DiffiIndexName
        {
            get
            {
                return _diffiindexName;
            }
            set
            {
                _diffiindexName = value;
            }
        }
    }
}
