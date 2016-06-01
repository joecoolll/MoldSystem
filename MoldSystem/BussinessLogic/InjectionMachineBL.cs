using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class InjectionMachineBL
    {
        public List<InjectionMachineBO> GetInjectionMach(InjectionMachineBO criteria)
        {
            try
            {
                InjectionMachineDA objInjectionMachineDA = new InjectionMachineDA();
                return objInjectionMachineDA.GetInjectionMach(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertInjectionMach(InjectionMachineBO newData)
        {
            try
            {
                InjectionMachineDA objInjectionMachineDA = new InjectionMachineDA();
                objInjectionMachineDA.InsertInjectionMach(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateInjectionMach(InjectionMachineBO updateData)
        {
            try
            {
                InjectionMachineDA objInjectionMachineDA = new InjectionMachineDA();
                objInjectionMachineDA.UpdateInjectionMach(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteInjectionMach(InjectionMachineBO deleteData)
        {
            try
            {
                InjectionMachineDA objInjectionMachineDA = new InjectionMachineDA();
                objInjectionMachineDA.DeleteInjectionMach(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
