using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldCostItemBL
    {
        public List<MoldCostItemBO> GetMoldCostItem(MoldCostItemBO criteria)
        {
            try
            {
                MoldCostItemDA objMoldCostItemDA = new MoldCostItemDA();
                return objMoldCostItemDA.GetMoldCostItem(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldCostItem(MoldCostItemBO newData)
        {
            try
            {
                MoldCostItemDA objMoldCostItemDA = new MoldCostItemDA();
                objMoldCostItemDA.InsertMoldCostItem(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldCostItem(MoldCostItemBO updateData)
        {
            try
            {
                MoldCostItemDA objMoldCostItemDA = new MoldCostItemDA();
                objMoldCostItemDA.UpdateMoldCostItem(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldCostItem(MoldCostItemBO deleteData)
        {
            try
            {
                MoldCostItemDA objMoldCostItemDA = new MoldCostItemDA();
                objMoldCostItemDA.DeleteMoldCostItem(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
