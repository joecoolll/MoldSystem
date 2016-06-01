using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class NewModBL
    {
        public List<NewModBO> GetNewMod(NewModBO criteria)
        {
            try
            {
                NewModDA objNewModDA = new NewModDA();
                return objNewModDA.GetNewMod(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertNewMod(NewModBO newData)
        {
            try
            {
                NewModDA objNewModDA = new NewModDA();
                objNewModDA.InsertNewMod(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateNewMod(NewModBO updateData)
        {
            try
            {
                NewModDA objNewModDA = new NewModDA();
                objNewModDA.UpdateNewMod(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNewMod(NewModBO deleteData)
        {
            try
            {
                NewModDA objNewModDA = new NewModDA();
                objNewModDA.DeleteNewMod(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
