using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldCostTypeBL
    {
        public List<MoldCostTypeBO> GetMoldCostType(MoldCostTypeBO criteria)
        {
            try
            {
                MoldCostTypeDA objMoldCostTypeDA = new MoldCostTypeDA();
                return objMoldCostTypeDA.GetMoldCostType(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldCostType(MoldCostTypeBO newData)
        {
            try
            {
                MoldCostTypeDA objMoldCostTypeDA = new MoldCostTypeDA();
                objMoldCostTypeDA.InsertMoldCostType(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldCostType(MoldCostTypeBO updateData)
        {
            try
            {
                MoldCostTypeDA objMoldCostTypeDA = new MoldCostTypeDA();
                objMoldCostTypeDA.UpdateMoldCostType(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldCostType(MoldCostTypeBO deleteData)
        {
            try
            {
                MoldCostTypeDA objMoldCostTypeDA = new MoldCostTypeDA();
                objMoldCostTypeDA.DeleteMoldCostType(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
