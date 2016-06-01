using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class DocumentStatusBO
    {
        private int? _documentstatusID;
        private int? _newdocumentstatusID;
        private string _documentstatusDetail;

        public int? DocumentStatusID
        {
            get
            {
                return _documentstatusID;
            }
            set
            {
                _documentstatusID = value;
            }
        }

        public int? NewDocumentStatusID
        {
            get
            {
                return _newdocumentstatusID;
            }
            set
            {
                _newdocumentstatusID = value;
            }
        }

        public string DocumentStatusDetail
        {
            get
            {
                return _documentstatusDetail;
            }
            set
            {
                _documentstatusDetail = value;
            }
        }
    }
}
