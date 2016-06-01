using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    [Serializable]
    public class NoCavitiesBO
    {
        private int? _nocavID;
        private int? _newnocavID;
        private string _nocavDetail;

        public int? NoCavID
        {
            get
            {
                return _nocavID;
            }
            set
            {
                _nocavID = value;
            }
        }

        public int? NewNoCavID
        {
            get
            {
                return _newnocavID;
            }
            set
            {
                _newnocavID = value;
            }
        }

        public string NoCavDetail
        {
            get
            {
                return _nocavDetail;
            }
            set
            {
                _nocavDetail = value;
            }
        }
    }
}
