using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class InjectionMachineBO
    {
        private int? _injectionmachID;
        private int? _newinjectionmachID;
        private string _injectionmachName;

        public int? InjectionMachID
        {
            get
            {
                return _injectionmachID;
            }
            set
            {
                _injectionmachID = value;
            }
        }

        public int? NewInjectionMachID
        {
            get
            {
                return _newinjectionmachID;
            }
            set
            {
                _newinjectionmachID = value;
            }
        }

        public string InjectionMachName
        {
            get
            {
                return _injectionmachName;
            }
            set
            {
                _injectionmachName = value;
            }
        }
    }
}
