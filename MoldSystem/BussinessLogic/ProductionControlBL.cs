using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class ProductionControlBL
    {
        public List<ProductionControlBO> GetProdCon(ProductionControlBO criteria)
        {
            try
            {
                ProductionControlDA objProductionControlDA = new ProductionControlDA();
                return objProductionControlDA.GetProdCon(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertProdCon(ProductionControlBO newData)
        {
            try
            {
                ProductionControlDA objProductionControlDA = new ProductionControlDA();
                objProductionControlDA.InsertProdCon(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProdCon(ProductionControlBO updateData)
        {
            try
            {
                ProductionControlDA objProductionControlDA = new ProductionControlDA();
                objProductionControlDA.UpdateProdCon(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProdCon(ProductionControlBO deleteData)
        {
            try
            {
                ProductionControlDA objProductionControlDA = new ProductionControlDA();
                objProductionControlDA.DeleteProdCon(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
