using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldingMaterialBL
    {
        public List<MoldingMaterialBO> GetMoldingMat(MoldingMaterialBO criteria)
        {
            try
            {
                MoldingMaterialDA objMoldingMaterialDA = new MoldingMaterialDA();
                return objMoldingMaterialDA.GetMoldingMat(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldingMat(MoldingMaterialBO newData)
        {
            try
            {
                MoldingMaterialDA objMoldingMaterialDA = new MoldingMaterialDA();
                objMoldingMaterialDA.InsertMoldingMat(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldingMat(MoldingMaterialBO updateData)
        {
            try
            {
                MoldingMaterialDA objMoldingMaterialDA = new MoldingMaterialDA();
                objMoldingMaterialDA.UpdateMoldingMat(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldingMat(MoldingMaterialBO deleteData)
        {
            try
            {
                MoldingMaterialDA objMoldingMaterialDA = new MoldingMaterialDA();
                objMoldingMaterialDA.DeleteMoldingMat(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
