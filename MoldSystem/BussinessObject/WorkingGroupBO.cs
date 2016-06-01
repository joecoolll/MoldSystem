using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class WorkingGroupBO
    {
        private int? _workgroupID;
        private int? _newworkgroupID;
        private string _workgroupName;

        public int? WorkGroupID
        {
            get
            {
                return _workgroupID;
            }
            set
            {
                _workgroupID = value;
            }
        }

        public int? NewWorkGroupID
        {
            get
            {
                return _newworkgroupID;
            }
            set
            {
                _newworkgroupID = value;
            }
        }

        public string WorkGroupName
        {
            get
            {
                return _workgroupName;
            }
            set
            {
                _workgroupName = value;
            }
        }
    }
}
