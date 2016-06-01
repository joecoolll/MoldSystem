using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class Worklist3BL
    {
        public List<Worklist3BO> GetWorklist3(Worklist3BO criteria)
        {
            try
            {
                Worklist3DA objWorklist3DA = new Worklist3DA();
                return objWorklist3DA.GetWorklist3(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertWorklist3(Worklist3BO newData)
        {
            try
            {
                Worklist3DA objWorklist3DA = new Worklist3DA();
                objWorklist3DA.InsertWorklist3(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorklist3(Worklist3BO updateData)
        {
            try
            {
                Worklist3DA objWorklist3DA = new Worklist3DA();
                objWorklist3DA.UpdateWorklist3(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorklist3(Worklist3BO deleteData)
        {
            try
            {
                Worklist3DA objWorklist3DA = new Worklist3DA();
                objWorklist3DA.DeleteWorklist3(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
