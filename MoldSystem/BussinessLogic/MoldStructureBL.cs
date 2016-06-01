using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class MoldStructureBL
    {
        public List<MoldStructureBO> GetMoldStructure(MoldStructureBO criteria)
        {
            try
            {
                MoldStructureDA objMoldStructureDA = new MoldStructureDA();
                return objMoldStructureDA.GetMoldStructure(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertMoldStructure(MoldStructureBO newData)
        {
            try
            {
                MoldStructureDA objMoldStructureDA = new MoldStructureDA();
                objMoldStructureDA.InsertMoldStructure(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMoldStructure(MoldStructureBO updateData)
        {
            try
            {
                MoldStructureDA objMoldStructureDA = new MoldStructureDA();
                objMoldStructureDA.UpdateMoldStructure(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMoldStructure(MoldStructureBO deleteData)
        {
            try
            {
                MoldStructureDA objMoldStructureDA = new MoldStructureDA();
                objMoldStructureDA.DeleteMoldStructure(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
