using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class DifficultyIndexBL
    {
        public List<DifficultyIndexBO> GetDiffiIndex(DifficultyIndexBO criteria)
        {
            try
            {
                DifficultyIndexDA objDifficultyIndexDA = new DifficultyIndexDA();
                return objDifficultyIndexDA.GetDiffiIndex(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertDiffiIndex(DifficultyIndexBO newData)
        {
            try
            {
                DifficultyIndexDA objDifficultyIndexDA = new DifficultyIndexDA();
                objDifficultyIndexDA.InsertDiffiIndex(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDiffiIndex(DifficultyIndexBO updateData)
        {
            try
            {
                DifficultyIndexDA objDifficultyIndexDA = new DifficultyIndexDA();
                objDifficultyIndexDA.UpdateDiffiIndex(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDiffiIndex(DifficultyIndexBO deleteData)
        {
            try
            {
                DifficultyIndexDA objDifficultyIndexDA = new DifficultyIndexDA();
                objDifficultyIndexDA.DeleteDiffiIndex(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
