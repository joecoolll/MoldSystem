using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class CustomerBO
    {
        private int? _customerID;
        private int? _newcustomerID;
        private string _customerCode;
        private string _customerName;

        public int? CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
            }
        }

        public int? NewCustomerID
        {
            get
            {
                return _newcustomerID;
            }
            set
            {
                _newcustomerID = value;
            }
        }

        public string CustomerCode
        {
            get
            {
                return _customerCode;
            }
            set
            {
                _customerCode = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                _customerName = value;
            }
        }
    }
}
