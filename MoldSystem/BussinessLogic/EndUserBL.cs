using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class EndUserBL
    {
        public List<EndUserBO> GetEndUser(EndUserBO criteria)
        {
            try
            {
                EndUserDA objEndUserDA = new EndUserDA();
                return objEndUserDA.GetEndUser(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEndUser(EndUserBO newData)
        {
            try
            {
                EndUserDA objEndUserDA = new EndUserDA();
                objEndUserDA.InsertEndUser(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEndUser(EndUserBO updateData)
        {
            try
            {
                EndUserDA objEndUserDA = new EndUserDA();
                objEndUserDA.UpdateEndUser(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEndUser(EndUserBO deleteData)
        {
            try
            {
                EndUserDA objEndUserDA = new EndUserDA();
                objEndUserDA.DeleteEndUser(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
