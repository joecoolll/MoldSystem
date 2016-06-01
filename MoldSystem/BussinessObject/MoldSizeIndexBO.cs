using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class MoldSizeIndexBO
    {
        private int? _sizeindexID;
        private int? _newsizeindexID;
        private string _sizeindexName;

        public int? SizeIndexID
        {
            get
            {
                return _sizeindexID;
            }
            set
            {
                _sizeindexID = value;
            }
        }

        public int? NewSizeIndexID
        {
            get
            {
                return _newsizeindexID;
            }
            set
            {
                _newsizeindexID = value;
            }
        }

        public string SizeIndexName
        {
            get
            {
                return _sizeindexName;
            }
            set
            {
                _sizeindexName = value;
            }
        }
    }
}
