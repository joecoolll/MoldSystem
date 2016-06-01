using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class RelativeClientBO
    {
        private int? _relativeclientID;
        private int? _newrelativeclientID;
        private string _relativeclientName;

        public int? RelativeClientID
        {
            get
            {
                return _relativeclientID;
            }
            set
            {
                _relativeclientID = value;
            }
        }

        public int? NewRelativeClientID
        {
            get
            {
                return _newrelativeclientID;
            }
            set
            {
                _newrelativeclientID = value;
            }
        }

        public string RelativeClientName
        {
            get
            {
                return _relativeclientName;
            }
            set
            {
                _relativeclientName = value;
            }
        }
    }
}
