using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess; // for acessing DataAccess class
using BussinessObject; // for acessing bussiness object class

namespace Bussinesslogic
{
    public class CustomerBL
    {
        public List<CustomerBO> GetCustomer(CustomerBO criteria)
        {
            try
            {
                CustomerDA objCustomerDA = new CustomerDA();
                return objCustomerDA.GetCustomer(criteria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertCustomer(CustomerBO newData)
        {
            try
            {
                CustomerDA objCustomerDA = new CustomerDA();
                objCustomerDA.InsertCustomer(newData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateCustomer(CustomerBO updateData)
        {
            try
            {
                CustomerDA objCustomerDA = new CustomerDA();
                objCustomerDA.UpdateCustomer(updateData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCustomer(CustomerBO deleteData)
        {
            try
            {
                CustomerDA objCustomerDA = new CustomerDA();
                objCustomerDA.DeleteCustomer(deleteData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
