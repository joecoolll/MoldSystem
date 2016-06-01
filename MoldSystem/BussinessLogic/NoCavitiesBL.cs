using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class NoCavitiesBL
    {
        public List<NoCavitiesBO> GetNoCav(NoCavitiesBO criteria)
        {
            try
            {
                NoCavitiesDA objNoCavitiesDA = new NoCavitiesDA();
                return objNoCavitiesDA.GetNoCav(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertNoCav(NoCavitiesBO newData)
        {
            try
            {
                NoCavitiesDA objNoCavitiesDA = new NoCavitiesDA();
                objNoCavitiesDA.InsertNoCav(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateNoCav(NoCavitiesBO updateData)
        {
            try
            {
                NoCavitiesDA objNoCavitiesDA = new NoCavitiesDA();
                objNoCavitiesDA.UpdateNoCav(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteNoCav(NoCavitiesBO deleteData)
        {
            try
            {
                NoCavitiesDA objNoCavitiesDA = new NoCavitiesDA();
                objNoCavitiesDA.DeleteNoCav(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
