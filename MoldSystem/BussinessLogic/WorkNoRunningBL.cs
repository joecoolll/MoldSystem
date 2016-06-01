using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class WorkNoRunningBL
    {
        public List<WorkNoRunningBO> GetWorkNoRunning(WorkNoRunningBO criteria)
        {
            try
            {
                WorkNoRunningDA objWorkNoRunningDA = new WorkNoRunningDA();
                return objWorkNoRunningDA.GetWorkNoRunning(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertWorkNoRunning(WorkNoRunningBO newData)
        {
            try
            {
                WorkNoRunningDA objWorkNoRunningDA = new WorkNoRunningDA();
                objWorkNoRunningDA.InsertWorkNoRunning(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateWorkNoRunning(WorkNoRunningBO updateData)
        {
            try
            {
                WorkNoRunningDA objWorkNoRunningDA = new WorkNoRunningDA();
                objWorkNoRunningDA.UpdateWorkNoRunning(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteWorkNoRunning(WorkNoRunningBO deleteData)
        {
            try
            {
                WorkNoRunningDA objWorkNoRunningDA = new WorkNoRunningDA();
                objWorkNoRunningDA.DeleteWorkNoRunning(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
