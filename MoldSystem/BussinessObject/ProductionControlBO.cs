using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class ProductionControlBO
    {
        private int? _prodconID;
        private int? _newprodconID;
        private string _prodconName;

        public int? ProdConID
        {
            get
            {
                return _prodconID;
            }
            set
            {
                _prodconID = value;
            }
        }

        public int? NewProdConID
        {
            get
            {
                return _newprodconID;
            }
            set
            {
                _newprodconID = value;
            }
        }

        public string ProdConName
        {
            get
            {
                return _prodconName;
            }
            set
            {
                _prodconName = value;
            }
        }
    }
}
