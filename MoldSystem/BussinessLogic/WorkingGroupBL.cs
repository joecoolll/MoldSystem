using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class WorkingGroupBL
    {
        public List<WorkingGroupBO> GetWorkGroup(WorkingGroupBO criteria)
        {
            try
            {
                WorkingGroupDA objWorkingGroupDA = new WorkingGroupDA();
                return objWorkingGroupDA.GetWorkGroup(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertWorkGroup(WorkingGroupBO newData)
        {
            try
            {
                WorkingGroupDA objWorkingGroupDA = new WorkingGroupDA();
                objWorkingGroupDA.InsertWorkGroup(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorkGroup(WorkingGroupBO updateData)
        {
            try
            {
                WorkingGroupDA objWorkingGroupDA = new WorkingGroupDA();
                objWorkingGroupDA.UpdateWorkGroup(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorkGroup(WorkingGroupBO deleteData)
        {
            try
            {
                WorkingGroupDA objWorkingGroupDA = new WorkingGroupDA();
                objWorkingGroupDA.DeleteWorkGroup(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
