using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class GateSystemBL
    {
        public List<GateSystemBO> GetGateSys(GateSystemBO criteria)
        {
            try
            {
                GateSystemDA objGateSystemDA = new GateSystemDA();
                return objGateSystemDA.GetGateSys(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertGateSys(GateSystemBO newData)
        {
            try
            {
                GateSystemDA objGateSystemDA = new GateSystemDA();
                objGateSystemDA.InsertGateSys(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateGateSys(GateSystemBO updateData)
        {
            try
            {
                GateSystemDA objGateSystemDA = new GateSystemDA();
                objGateSystemDA.UpdateGateSys(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteGateSys(GateSystemBO deleteData)
        {
            try
            {
                GateSystemDA objGateSystemDA = new GateSystemDA();
                objGateSystemDA.DeleteGateSys(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
