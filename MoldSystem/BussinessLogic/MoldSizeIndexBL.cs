using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldSizeIndexBL
    {
        public List<MoldSizeIndexBO> GetSizeIndex(MoldSizeIndexBO criteria)
        {
            try
            {
                MoldSizeIndexDA objMoldSizeIndexDA = new MoldSizeIndexDA();
                return objMoldSizeIndexDA.GetSizeIndex(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertSizeIndex(MoldSizeIndexBO newData)
        {
            try
            {
                MoldSizeIndexDA objMoldSizeIndexDA = new MoldSizeIndexDA();
                objMoldSizeIndexDA.InsertSizeIndex(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateSizeIndex(MoldSizeIndexBO updateData)
        {
            try
            {
                MoldSizeIndexDA objMoldSizeIndexDA = new MoldSizeIndexDA();
                objMoldSizeIndexDA.UpdateSizeIndex(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSizeIndex(MoldSizeIndexBO deleteData)
        {
            try
            {
                MoldSizeIndexDA objMoldSizeIndexDA = new MoldSizeIndexDA();
                objMoldSizeIndexDA.DeleteSizeIndex(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
