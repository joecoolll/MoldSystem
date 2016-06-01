using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldMaterialBL
    {
        public List<MoldMaterialBO> GetMoldMat(MoldMaterialBO criteria)
        {
            try
            {
                MoldMaterialDA objMoldMaterialDA = new MoldMaterialDA();
                return objMoldMaterialDA.GetMoldMat(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldMat(MoldMaterialBO newData)
        {
            try
            {
                MoldMaterialDA objMoldMaterialDA = new MoldMaterialDA();
                objMoldMaterialDA.InsertMoldMat(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldMat(MoldMaterialBO updateData)
        {
            try
            {
                MoldMaterialDA objMoldMaterialDA = new MoldMaterialDA();
                objMoldMaterialDA.UpdateMoldMat(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldMat(MoldMaterialBO deleteData)
        {
            try
            {
                MoldMaterialDA objMoldMaterialDA = new MoldMaterialDA();
                objMoldMaterialDA.DeleteMoldMat(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
