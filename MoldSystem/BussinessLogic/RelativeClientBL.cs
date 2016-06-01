using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class RelativeClientBL
    {
        public List<RelativeClientBO> GetRelativeClient(RelativeClientBO criteria)
        {
            try
            {
                RelativeClientDA objRelativeClientDA = new RelativeClientDA();
                return objRelativeClientDA.GetRelativeClient(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertRelativeClient(RelativeClientBO newData)
        {
            try
            {
                RelativeClientDA objRelativeClientDA = new RelativeClientDA();
                objRelativeClientDA.InsertRelativeClient(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateRelativeClient(RelativeClientBO updateData)
        {
            try
            {
                RelativeClientDA objRelativeClientDA = new RelativeClientDA();
                objRelativeClientDA.UpdateRelativeClient(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRelativeClient(RelativeClientBO deleteData)
        {
            try
            {
                RelativeClientDA objRelativeClientDA = new RelativeClientDA();
                objRelativeClientDA.DeleteRelativeClient(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
