using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldTypeBL
    {
        public List<MoldTypeBO> GetMoldType(MoldTypeBO criteria)
        {
            try
            {
                MoldTypeDA objMoldTypeDA = new MoldTypeDA();
                return objMoldTypeDA.GetMoldType(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldType(MoldTypeBO newData)
        {
            try
            {
                MoldTypeDA objMoldTypeDA = new MoldTypeDA();
                objMoldTypeDA.InsertMoldType(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldType(MoldTypeBO updateData)
        {
            try
            {
                MoldTypeDA objMoldTypeDA = new MoldTypeDA();
                objMoldTypeDA.UpdateMoldType(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldType(MoldTypeBO deleteData)
        {
            try
            {
                MoldTypeDA objMoldTypeDA = new MoldTypeDA();
                objMoldTypeDA.DeleteMoldType(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
