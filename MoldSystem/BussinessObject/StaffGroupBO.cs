using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class StaffGroupBO
    {
        private int? _staffgroupID;
        private int? _newstaffgroupID;
        private string _staffgroupName;

        public int? StaffGroupID
        {
            get
            {
                return _staffgroupID;
            }
            set
            {
                _staffgroupID = value;
            }
        }

        public int? NewStaffGroupID
        {
            get
            {
                return _newstaffgroupID;
            }
            set
            {
                _newstaffgroupID = value;
            }
        }
        
        public string StaffGroupName
        {
            get
            {
                return _staffgroupName;
            }
            set
            {
                _staffgroupName = value;
            }
        }
    }
}
